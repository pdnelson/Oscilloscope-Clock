using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace Oscilloscope_Clock
{
    public class OscilloscopeWavePlayer
    {
        private SoundPlayer TimeDisplay;
        private MemoryStream MS;
        private BinaryWriter BW;
        public bool IsPlaying;

        public OscilloscopeWavePlayer()
        {
            IsPlaying = false;
        }

        /// <summary>
        /// Generates a wave based on parameters.
        /// This is intended to run async.
        /// </summary>
        /// <param name="points">Point list being converted to a wave file.</param>
        public void BuildWave(List<Point> points)
        {
            // Byte size of the Wave we are going to be creating
            int bytes = points.Count * 4;

            MS = new MemoryStream(44 + bytes);

            BW = new BinaryWriter(MS);

            //* BEGIN HEADER *//

            //  Specifies the "RIFF" section
            BW.Write(Encoding.ASCII.GetBytes("RIFF"), 0, 4);

            // Chunk size
            BW.Write(BitConverter.GetBytes(36 + bytes));

            // Specifies the format, which is "WAVE"
            BW.Write(Encoding.ASCII.GetBytes("WAVE"), 0, 4);

            // Sub-chunk
            BW.Write(Encoding.ASCII.GetBytes("fmt "), 0, 4);

            // Sub-chunk size
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

            //* END HEADER *//

            // Write each point to the Wave file
            foreach (Point sample in points)
            {
                BW.Write(Convert.ToInt16(sample.Y));
                BW.Write(Convert.ToInt16(sample.X));
            }

            // Prepare Wave to be played
            BW.Flush();
            MS.Seek(0, SeekOrigin.Begin);

        }

        public void PlayWave()
        {
            IsPlaying = true;
            using (TimeDisplay = new SoundPlayer(MS))
            {
                TimeDisplay.PlayLooping();
            }
        }

        public void StopWave()
        {
            IsPlaying = false;
            TimeDisplay.Stop();
            BW.Dispose();
            MS.Dispose();
        }
    }
}
