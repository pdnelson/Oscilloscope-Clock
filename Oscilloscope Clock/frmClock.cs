using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Oscilloscope_Clock
{
    public partial class frmClock : Form
    {
        Thread runningThread;
        ScopeGraphics Graphics;
        OscilloscopeWavePlayer WavePlayer;
        bool IsRunning;

        public frmClock()
        {
            InitializeComponent();

            WavePlayer = new OscilloscopeWavePlayer();

            IsRunning = true;

            Graphics = new ScopeGraphics();
            Graphics.CharacterSize = 6;
            Graphics.CharacterSpacing = 15;

            runningThread = new Thread(ClockSuperLoop);
        }
        
        private void frmClock_Load(object sender, EventArgs e)
        {
            runningThread.Start();
        }

        protected override void OnClosed(EventArgs e)
        {
            WavePlayer.StopWave();
            WavePlayer.Dispose();
            IsRunning = false;
            runningThread.Join();
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
                    List<Point> newPoints = Graphics.GetPointsFromAsciiString(newTime);

                    WavePlayer.BuildAndPlayWaveAsync(newPoints);
                }
                Thread.Sleep(250);
            }
        }
    }
}
