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
        Thread runningThread;
        ScopeGraphics Graphics;
        OscilloscopeWavePlayer WavePlayer;
        bool IsRunning;

        public frmClock()
        {
            InitializeComponent();

            WavePlayer = new OscilloscopeWavePlayer();

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

            Graphics = new ScopeGraphics();
            Graphics.CharacterSize = 8;
            Graphics.CharacterSpacing = 12;

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

        // This should be used if the time changes or if a setting changes that yields a different display
        public void RestartClockWithNewTime(String newTime)
        {
            List<Point> newPoints = Graphics.GetPointsFromAsciiString(newTime);

            if (newPoints != null)
            {
                lblError.Text = "";
                if (WavePlayer.IsPlaying) WavePlayer.StopWave();

                Thread wavePlayingThread = new Thread(() =>
                {
                    WavePlayer.BuildWave(newPoints);
                    WavePlayer.PlayWave();
                });

                wavePlayingThread.Start();
            }
            else
            {
                lblError.Text = 
                    "Error: The font size is too large for the selected" +
                    "\ncharacter spacing.";
            }
        }

        public void EndClockSuperLoopAndExit()
        {
            WavePlayer.StopWave();
            IsRunning = false;
            runningThread.Join();
        }
    }
}
