using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Media;

namespace Oscilloscope_Clock
{
    public partial class frmClock : Form
    {
        // GLOBAL VARIABLES
        BackgroundWorker displayWorker;
        Thread runningThread;
        SoundPlayer display;
        List<Point> time;
        ScopeGraphics graphics;
        Boolean running;

        // INITIALIZATION
        public frmClock()
        {
            InitializeComponent();

            // starts running
            running = true;

            // initialize the time and ASCII class
            time = new List<Point>();
            graphics = new ScopeGraphics();

            // clock display worker
            displayWorker = new BackgroundWorker();
            displayWorker.DoWork += new DoWorkEventHandler(displayWorker_DoWork);
            displayWorker.WorkerSupportsCancellation = true;

            // clock running thread
            runningThread = new Thread(run);
        }

        // LOAD FORM
        private void frmClock_Load(object sender, EventArgs e)
        {
            runningThread.Start();
        }

        // CLOSE FORM
        protected override void OnClosed(EventArgs e)
        {
            running = false;
            runningThread.Join();
        }

        // GENERATES WAVE BASED ON PARAMETERS
        // takes in two lists of points
        // intended to be utilized with a BackgroundWorker
        // TODO: Move this into its own class
        public void genWave(List<Point> points)
        {
            // number of samples and size
            int samples = 441 * 30 / 10;
            int bytes = samples * 4;

            // a counter for the number of samples written
            int sampWritten = 0;

            using (MemoryStream MS = new MemoryStream(44 + bytes))
            {
                using (BinaryWriter BW = new BinaryWriter(MS))
                {
                    // WRITING THE WAVE HEADER

                    //  specifies the "RIFF" part
                    BW.Write(Encoding.ASCII.GetBytes("RIFF"), 0, 4);

                    // "chunk" size
                    BW.Write(BitConverter.GetBytes(36 + bytes));

                    // specifies the format, which is "WAVE"
                    BW.Write(Encoding.ASCII.GetBytes("WAVE"), 0, 4);

                    // "Sub-chunk"
                    BW.Write(Encoding.ASCII.GetBytes("fmt "), 0, 4);

                    // "Sub-chunk" size
                    BW.Write(BitConverter.GetBytes(16), 0, 4);

                    // Format; does not indicate compression
                    BW.Write(0X20001);

                    // Number of channels (TWO)
                    BW.Write(44100);

                    // Sample rate
                    BW.Write(176400);

                    // Bit rate
                    BW.Write(0X100004);

                    // Block Align
                    BW.Write(0X61746164);

                    // Bits/sample
                    BW.Write(bytes);

                    short Sample = 5;

                    // loops the array inside the wave
                    int i = 0;
                    while (sampWritten < samples)
                    {
                        // writes X and Y data on appropriate channels
                        Sample = System.Convert.ToInt16(800 * points[i].Y);
                        BW.Write(Sample);
                        Sample = System.Convert.ToInt16(675 * points[i].X);
                        BW.Write(Sample);

                        if (i >= (points.Count - 1)) i = 0;
                        else i++;
                        sampWritten++;
                    }



                    // end-of-the-day clean-up stuff
                    BW.Flush();
                    MS.Seek(0, SeekOrigin.Begin);

                    // plays the shiny, new wave file
                    using (display = new SoundPlayer(MS))
                    {
                        display.PlayLooping();
                    }
                }
            }

        }

        // CLOCK DISPLAY WORKER
        // this is always running in the background
        public void displayWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            genWave(time);
        }

        // CLOCK ACTIONS
        // the clock will always run as long as "running" is true
        public void run()
        {
            // Stores the new time
            String newTime = "";

            // Clock update timer
            int sleep = 60 - Int32.Parse(DateTime.Now.ToString("ss"));

            // Always is running while the window is open
            while (running)
            {
                if (!newTime.Equals(DateTime.Now.ToString("HH:mm")))
                {
                    // Update the display
                    if (displayWorker.IsBusy) display.Stop();
                    newTime = DateTime.Now.ToString("HH:mm");
                    time.Clear();
                    time.AddRange(graphics.getString(newTime));
                    displayWorker.RunWorkerAsync();

                    // Clock will update every 60 seconds on every iteration after the first
                    Thread.Sleep(1000 * sleep);
                    if(sleep != 60) sleep = 60;
                }

            }
        }
    }
}
