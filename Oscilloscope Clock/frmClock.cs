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
        BackgroundWorker TimeDisplayWorker;
        SoundPlayer TimeDisplay;
        Thread runningThread;
        List<Point> TimePoints;
        ScopeGraphics Graphics;
        bool IsRunning;

        public frmClock()
        {
            InitializeComponent();

            cboTimeConvention.SelectedIndex = 1;

            // Populate the character spacing combo box
            for(int i = 12; i <= 30; i++)
            {
                cboCharSpacing.Items.Add(i);
            }
            cboCharSpacing.SelectedIndex = 0;

            // Populate the font size combo box
            for(int i = 1; i <= 9; i++)
            {
                cboFontSize.Items.Add(i);
            }
            cboFontSize.SelectedIndex = 7;

            IsRunning = true;

            TimePoints = new List<Point>();
            Graphics = new ScopeGraphics();
            Graphics.CharacterSize = 8;
            Graphics.CharacterSpacing = 12;

            TimeDisplayWorker = new BackgroundWorker();
            TimeDisplayWorker.DoWork += new DoWorkEventHandler(TimeDisplayWorker_DoWork);
            TimeDisplayWorker.WorkerSupportsCancellation = true;

            runningThread = new Thread(ClockSuperLoop);
        }
        
        private void frmClock_Load(object sender, EventArgs e)
        {
            runningThread.Start();
        }

        protected override void OnClosed(EventArgs e)
        {
            EndClockSuperLoopAndExit();
        }

        private void cboFontSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            // If Graphics is null, then the program has not fully started up yet
            if (Graphics != null)
            {
                Graphics.CharacterSize = cboFontSize.SelectedIndex + 1;
                RestartClockWithNewTime(DateTime.Now.ToString("HH:mm"));
            }
        }

        private void cboCharSpacing_SelectedIndexChanged(object sender, EventArgs e)
        {
            // If Graphics is null, then the program has not fully started up yet
            if (Graphics != null)
            {
                Graphics.CharacterSpacing = cboCharSpacing.SelectedIndex + 12;
                RestartClockWithNewTime(DateTime.Now.ToString("HH:mm"));
            }
        }

        /// <summary>
        /// Generates a wave based on parameters.
        /// This is intended to run async.
        /// </summary>
        /// <param name="points">Point list being converted to a wave file.</param>
        public void CreateAndRunWave(List<Point> points)
        {
            // Byte size of the Wave we are going to be creating
            int bytes = points.Count * 4;

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

                    foreach (Point sample in points)
                    {
                        BW.Write(Convert.ToInt16(sample.Y));
                        BW.Write(Convert.ToInt16(sample.X));
                    }

                    // end-of-the-day clean-up stuff
                    BW.Flush();
                    MS.Seek(0, SeekOrigin.Begin);

                    // plays the shiny, new wave file
                    using (TimeDisplay = new SoundPlayer(MS))
                    {
                        TimeDisplay.PlayLooping();
                    }
                }
            }

        }

        /// <summary>
        /// This is constantly updating the time and displaying the new time. 
        /// The clock will always run as long as "running" is true.
        /// </summary>
        public void ClockSuperLoop()
        {
            // Stores the new time
            String newTime = "";

            // Always is running while the window is open
            while (IsRunning)
            {
                if (!newTime.Equals(DateTime.Now.ToString("HH:mm")))
                {
                    // Update the display
                    newTime = DateTime.Now.ToString("HH:mm");
                    RestartClockWithNewTime(newTime);
                }
                Thread.Sleep(250);
            }
        }

        public void TimeDisplayWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            CreateAndRunWave(TimePoints);
        }

        // This should be used if the time changes or if a setting changes that yields a different display
        public void RestartClockWithNewTime(String newTime)
        {
            if (TimeDisplayWorker != null)
            {
                List<Point> newPoints = Graphics.GetPointsFromAsciiString(newTime);

                if (newPoints != null)
                {
                    lblError.Text = "";
                    if (TimeDisplayWorker.IsBusy) TimeDisplay.Stop();
                    TimePoints.Clear();
                    TimePoints.AddRange(newPoints);
                    TimeDisplayWorker.RunWorkerAsync();
                }
                else
                {
                    lblError.Text = 
                        "Error: The font size is too large for the selected" +
                        "\ncharacter spacing.";
                }
            }
        }

        public void EndClockSuperLoopAndExit()
        {
            TimeDisplay.Stop();
            IsRunning = false;
            runningThread.Join();
        }
    }
}
