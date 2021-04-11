using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Oscilloscope_Clock
{
    class ScopeGraphics
    {
        private List<Point>[] ASCII;
        private int Range;
        
        public ScopeGraphics()
        {
            // We are only filling in the numbers in the ASCII table and a colon for now
            ASCII = new List<Point>[128];

            for (int i = 0; i < 128; i++)
            {
                ASCII[i] = new List<Point>();
            }
            
            SetZero();
            SetOne();
            SetTwo();
            SetThree();
            SetFour();
            SetFive();
            SetSix();
            SetSeven();
            SetEight();
            SetNine();
            SetColon();
        }

        /// <summary>
        /// Corresponds to ASCII 0
        /// </summary>
        private void SetZero()
        {
            for (int i = -10; i < 0; i++) ASCII[48].Add(new Point(i, 0));
            for (int i = 0; i < 20; i++) ASCII[48].Add(new Point(0, i));
            for (int i = 0; i > -10; i--) ASCII[48].Add(new Point(i, 20));
            for (int i = 20; i > 0; i--) ASCII[48].Add(new Point(-10, i));
            for (int i = -20; i < 2; i += 2) ASCII[48].Add(new Point((i / 2), i + 20));
            TraceToOrigin(ASCII[48]);
        }

        /// <summary>
        /// Corresponds to ASCII 1
        /// </summary>
        private void SetOne()
        {
            for (int i = -10; i < 0; i++) ASCII[49].Add(new Point(i, 0));
            for (int i = 0; i > -4; i -= 2) ASCII[49].Add(new Point(i, 0));
            for (int i = 0; i < 20; i++) ASCII[49].Add(new Point(-4, i));
            for (int i = -4; i > -8; i--) ASCII[49].Add(new Point(i, 20));
            TraceToOrigin(ASCII[49]);
        }

        /// <summary>
        /// Corresponds to ASCII 2
        /// </summary>
        private void SetTwo()
        {
            for (int i = 0; i > -10; i--) ASCII[50].Add(new Point(i, 0));
            for (int i = 0; i < 10; i++) ASCII[50].Add(new Point(-10, i));
            for (int i = -10; i < 0; i++) ASCII[50].Add(new Point(i, 10));
            for (int i = 10; i < 20; i++) ASCII[50].Add(new Point(0, i));
            for (int i = 0; i > -10; i--) ASCII[50].Add(new Point(i, 20));
            TraceToOrigin(ASCII[50]);
        }

        /// <summary>
        /// Corresponds to ASCII 3
        /// </summary>
        private void SetThree()
        {
            for (int i = -10; i < 0; i++) ASCII[51].Add(new Point(i, 0));
            for (int i = 0; i < 10; i++) ASCII[51].Add(new Point(0, i));
            for (int i = 0; i > -8; i--) ASCII[51].Add(new Point(i, 10));
            for (int i = -8; i < 0; i += 2) ASCII[51].Add(new Point(i, 10));
            for (int i = 10; i < 20; i++) ASCII[51].Add(new Point(0, i));
            for (int i = 0; i > -10; i--) ASCII[51].Add(new Point(i, 20));
            TraceToOrigin(ASCII[51]);
        }

        /// <summary>
        /// Corresponds to ASCII 4
        /// </summary>
        private void SetFour()
        {
            ASCII[52].Add(new Point(0, 0));
            ASCII[52].Add(new Point(0, 0));
            ASCII[52].Add(new Point(0, 0));
            ASCII[52].Add(new Point(0, 0));
            for (int i = 0; i < 20; i++) ASCII[52].Add(new Point(0, i));
            for (int i = 20; i > 10; i -= 2) ASCII[52].Add(new Point(0, i));
            for (int i = 0; i > -10; i--) ASCII[52].Add(new Point(i, 10));
            for (int i = 10; i < 20; i++) ASCII[52].Add(new Point(-10, i));
            TraceToOrigin(ASCII[52]);
        }

        /// <summary>
        /// Corresponds to ASCII 5
        /// </summary>
        private void SetFive()
        {
            for (int i = -10; i < 0; i++) ASCII[53].Add(new Point(i, 0));
            for (int i = 0; i < 10; i++) ASCII[53].Add(new Point(0, i));
            for (int i = 0; i > -10; i--) ASCII[53].Add(new Point(i, 10));
            for (int i = 10; i < 20; i++) ASCII[53].Add(new Point(-10, i));
            for (int i = -10; i < 0; i++) ASCII[53].Add(new Point(i, 20));
            TraceToOrigin(ASCII[53]);
        }

        /// <summary>
        /// Corresponds to ASCII 6
        /// </summary>
        private void SetSix()
        {
            for (int i = -10; i < 0; i++) ASCII[54].Add(new Point(i, 0));
            for (int i = 0; i < 10; i++) ASCII[54].Add(new Point(0, i));
            for (int i = 0; i > -10; i--) ASCII[54].Add(new Point(i, 10));
            for (int i = 10; i > 0; i--) ASCII[54].Add(new Point(-10, i));
            for (int i = 10; i < 20; i++) ASCII[54].Add(new Point(-10, i));
            for (int i = -10; i < 0; i++) ASCII[54].Add(new Point(i, 20));
            TraceToOrigin(ASCII[54]);
        }

        /// <summary>
        /// Corresponds to ASCII 7
        /// </summary>
        private void SetSeven()
        {
            ASCII[55].Add(new Point(0, 0));
            ASCII[55].Add(new Point(0, 0));
            ASCII[55].Add(new Point(0, 0));
            ASCII[55].Add(new Point(0, 0));
            for (int i = 0; i < 20; i++) ASCII[55].Add(new Point(0, i));
            for (int i = 0; i > -10; i--) ASCII[55].Add(new Point(i, 20));
            TraceToOrigin(ASCII[55]);
        }

        /// <summary>
        /// Corresponds to ASCII 8
        /// </summary>
        private void SetEight()
        {
            for (int i = -10; i < 0; i++) ASCII[56].Add(new Point(i, 0));
            for (int i = 0; i < 20; i++) ASCII[56].Add(new Point(0, i));
            for (int i = 0; i > -10; i--) ASCII[56].Add(new Point(i, 20));
            for (int i = 20; i > 10; i--) ASCII[56].Add(new Point(-10, i));
            for (int i = -10; i < 0; i++) ASCII[56].Add(new Point(i, 10));
            for (int i = 0; i > -10; i--) ASCII[56].Add(new Point(i, 10));
            for (int i = 10; i > 0; i--) ASCII[56].Add(new Point(-10, i));
            TraceToOrigin(ASCII[56]);
        }

        /// <summary>
        /// Corresponds to ASCII 9
        /// </summary>
        private void SetNine()
        {
            for (int i = -10; i < 0; i++) ASCII[57].Add(new Point(i, 0));
            for (int i = 0; i < 20; i++) ASCII[57].Add(new Point(0, i));
            for (int i = 0; i > -10; i--) ASCII[57].Add(new Point(i, 20));
            for (int i = 20; i > 10; i--) ASCII[57].Add(new Point(-10, i));
            for (int i = -10; i < 0; i++) ASCII[57].Add(new Point(i, 10));
            TraceToOrigin(ASCII[57]);
        }

        /// <summary>
        /// Corresponds to ASCII :
        /// </summary>
        private void SetColon()
        {
            for (int i = 0; i < 20; i++) ASCII[58].Add(new Point((int)(2 * Math.Cos(i) - 5), (int)(2 * Math.Sin(i)) + 3));
            for (int i = 0; i < 20; i++) ASCII[58].Add(new Point((int)(2 * Math.Cos(i) - 5), (int)(2 * Math.Sin(i)) + 17));
            TraceToOrigin(ASCII[58]);
        }


        /// <summary>
        /// Traces a point list back to its origin.
        /// </summary>
        private void TraceToOrigin(List<Point> p)
        {
            for (int i = p.Count - 1; i > -1; i--)
            {
                p.Add(new Point(p[i].X, p[i].Y));
            }
        }
        
        /// <summary>
        /// Converts a character to a point array.
        /// </summary>
        /// <param name="c">Character desired to be converted to a point array.</param>
        /// <returns>Point array corresponding to the character.</returns>
        public List<Point> GetAsciiChar(Char c)
        {
            return ASCII[(int)c];
        }
        
        /// <summary>
        /// Converts ASCII string to a point array
        /// </summary>
        /// <param name="s">String desired to be converted to a point array.</param>
        /// <returns>Point array corresponding to the string.</returns>
        public List<Point> GetAsciiString(String s)
        {
            List<Point> sPoints = new List<Point>();
            List<Point> nextChar = new List<Point>();
            Range = 0;

            // X and Y offset values for character placement
            int xMove = 0;
            int yMove = 0;
            foreach (char c in s)
            {
                if ((int)c != 13)
                {
                    // loads the next character into nextChar
                    nextChar.AddRange(GetAsciiChar(c));

                    for (int i = 0; i < (nextChar.Count); i++)
                    {
                        // pushes all the coordinates of nextChar according to the offset
                        nextChar[i] = new Point((nextChar[i].X + xMove), (nextChar[i].Y + yMove));

                        // determines what the largest coordinate is
                        if (Math.Abs(nextChar[i].X) > Range) Range = nextChar[i].X;
                        if (Math.Abs(nextChar[i].Y) > Range) Range = nextChar[i].Y;
                    }

                    // adds nextChar to the output list if it is within the range
                    sPoints.AddRange(nextChar);
                    nextChar.Clear();

                    // add to offset to position next character
                    xMove += 12;
                }

                // if the character is enter, updates X and Y offset
                else
                {
                    xMove = -12;
                    yMove -= 24;
                }
            }

            return sPoints;
        }

        /// <summary>
        /// Calculates the largest X or Y axis range based on the font size provided.
        /// </summary>
        /// <param name="size">Font size.</param>
        /// <returns>Largest axis range.</returns>
        public int GetRange(int size)
        {
            return Range * size * 100;
        }
    }
}
