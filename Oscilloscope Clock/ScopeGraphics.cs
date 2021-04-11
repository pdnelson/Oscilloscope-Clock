using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Oscilloscope_Clock
{
    public class ScopeGraphics
    {
        private int range;

        // 0
        private List<Point> setZero()
        {
            List<Point> points = new List<Point>();

            for (int i = -10; i < 0; i++)       points.Add(new Point(i, 0));
            for (int i = 0; i < 20; i++)        points.Add(new Point(0, i));
            for (int i = 0; i > -10; i--)       points.Add(new Point(i, 20));
            for (int i = 20; i > 0; i--)        points.Add(new Point(-10, i));
            for (int i = -20; i < 2; i += 2)    points.Add(new Point((i / 2), i + 20));

            trace(ref points);

            return points;
        }

        // 1
        private List<Point> setOne()
        {
            List<Point> points = new List<Point>();

            for (int i = -10; i < 0; i++)       points.Add(new Point(i, 0));
            for (int i = 0; i > -4; i -= 2)     points.Add(new Point(i, 0));
            for (int i = 0; i < 20; i++)        points.Add(new Point(-4, i));
            for (int i = -4; i > -8; i--)       points.Add(new Point(i, 20));

            trace(ref points);

            return points;
        }

        // 2
        private List<Point> setTwo()
        {
            List<Point> points = new List<Point>();

            for (int i = 0; i > -10; i--)       points.Add(new Point(i, 0));
            for (int i = 0; i < 10; i++)        points.Add(new Point(-10, i));
            for (int i = -10; i < 0; i++)       points.Add(new Point(i, 10));
            for (int i = 10; i < 20; i++)       points.Add(new Point(0, i));
            for (int i = 0; i > -10; i--)       points.Add(new Point(i, 20));

            trace(ref points);

            return points;
        }

        // 3
        private List<Point> setThree()
        {
            List<Point> points = new List<Point>();

            for (int i = -10; i < 0; i++)       points.Add(new Point(i, 0));
            for (int i = 0; i < 10; i++)        points.Add(new Point(0, i));
            for (int i = 0; i > -8; i--)        points.Add(new Point(i, 10));
            for (int i = -8; i < 0; i += 2)     points.Add(new Point(i, 10));
            for (int i = 10; i < 20; i++)       points.Add(new Point(0, i));
            for (int i = 0; i > -10; i--)       points.Add(new Point(i, 20));

            trace(ref points);

            return points;
        }

        // 4
        private List<Point> setFour()
        {
            List<Point> points = new List<Point>();

            points.Add(new Point(0, 0));
            points.Add(new Point(0, 0));
            points.Add(new Point(0, 0));
            points.Add(new Point(0, 0));

            for (int i = 0; i < 20; i++)        points.Add(new Point(0, i));
            for (int i = 20; i > 10; i -= 2)    points.Add(new Point(0, i));
            for (int i = 0; i > -10; i--)       points.Add(new Point(i, 10));
            for (int i = 10; i < 20; i++)       points.Add(new Point(-10, i));

            trace(ref points);

            return points;
        }

        // 5
        private List<Point> setFive()
        {
            List<Point> points = new List<Point>();

            for (int i = -10; i < 0; i++)       points.Add(new Point(i, 0));
            for (int i = 0; i < 10; i++)        points.Add(new Point(0, i));
            for (int i = 0; i > -10; i--)       points.Add(new Point(i, 10));
            for (int i = 10; i < 20; i++)       points.Add(new Point(-10, i));
            for (int i = -10; i < 0; i++)       points.Add(new Point(i, 20));

            trace(ref points);

            return points;
        }

        // 6
        private List<Point> setSix()
        {
            List<Point> points = new List<Point>();

            for (int i = -10; i < 0; i++)       points.Add(new Point(i, 0));
            for (int i = 0; i < 10; i++)        points.Add(new Point(0, i));
            for (int i = 0; i > -10; i--)       points.Add(new Point(i, 10));
            for (int i = 10; i > 0; i--)        points.Add(new Point(-10, i));
            for (int i = 10; i < 20; i++)       points.Add(new Point(-10, i));
            for (int i = -10; i < 0; i++)       points.Add(new Point(i, 20));

            trace(ref points);

            return points;
        }

        // 7
        private List<Point> setSeven()
        {
            List<Point> points = new List<Point>();

            points.Add(new Point(0, 0));
            points.Add(new Point(0, 0));
            points.Add(new Point(0, 0));
            points.Add(new Point(0, 0));

            for (int i = 0; i < 20; i++)        points.Add(new Point(0, i));
            for (int i = 0; i > -10; i--)       points.Add(new Point(i, 20));

            trace(ref points);

            return points;
        }

        // 8
        private List<Point> setEight()
        {
            List<Point> points = new List<Point>();

            for (int i = -10; i < 0; i++)       points.Add(new Point(i, 0));
            for (int i = 0; i < 20; i++)        points.Add(new Point(0, i));
            for (int i = 0; i > -10; i--)       points.Add(new Point(i, 20));
            for (int i = 20; i > 10; i--)       points.Add(new Point(-10, i));
            for (int i = -10; i < 0; i++)       points.Add(new Point(i, 10));
            for (int i = 0; i > -10; i--)       points.Add(new Point(i, 10));
            for (int i = 10; i > 0; i--)        points.Add(new Point(-10, i));

            trace(ref points);

            return points;
        }

        // 9
        private List<Point> setNine()
        {
            List<Point> points = new List<Point>();

            for (int i = -10; i < 0; i++)       points.Add(new Point(i, 0));
            for (int i = 0; i < 20; i++)        points.Add(new Point(0, i));
            for (int i = 0; i > -10; i--)       points.Add(new Point(i, 20));
            for (int i = 20; i > 10; i--)       points.Add(new Point(-10, i));
            for (int i = -10; i < 0; i++)       points.Add(new Point(i, 10));

            trace(ref points);

            return points;
        }

        // :
        private List<Point> setColon()
        {
            List<Point> points = new List<Point>();

            for (int i = 0; i < 20; i++)        points.Add(new Point((int)(2 * Math.Cos(i) - 5), (int)(2 * Math.Sin(i)) + 3));
            for (int i = 0; i < 20; i++)        points.Add(new Point((int)(2 * Math.Cos(i) - 5), (int)(2 * Math.Sin(i)) + 17));

            trace(ref points);

            return points;
        }

        // TRACE
        // traces the character back to origin
        private void trace(ref List<Point> p)
        {
            for (int i = p.Count - 1; i > -1; i--)
            {
                p.Add(new Point(p[i].X, p[i].Y));
            }
        }

        // RETURN CHAR
        // returns points that correspond to an ASCII character
        public List<Point> getSingleChar(Char c)
        {
            switch(c)
            {
                case '0': return setZero();
                case '1': return setOne();
                case '2': return setTwo();
                case '3': return setThree();
                case '4': return setFour();
                case '5': return setFive();
                case '6': return setSix();
                case '7': return setSeven();
                case '8': return setEight();
                case '9': return setNine();
                case ':': return setColon();
                default: return new List<Point>();
            }
        }

        // RETURN STRING
        // returns points that correspond to a string of ASCII characters
        public List<Point> getString(String s)
        {
            List<Point> sPoints = new List<Point>();
            List<Point> nextChar = new List<Point>();
            range = 0;

            // X and Y offset values for character placement
            int xMove = 0;
            int yMove = 0;
            foreach (char c in s)
            {
                if ((int)c != 13)
                {
                    // loads the next character into nextChar
                    nextChar.AddRange(getSingleChar(c));

                    for (int i = 0; i < (nextChar.Count); i++)
                    {
                        // pushes all the coordinates of nextChar according to the offset
                        nextChar[i] = new Point((nextChar[i].X + xMove), (nextChar[i].Y + yMove));

                        // determines what the largest coordinate is
                        if (Math.Abs(nextChar[i].X) > range) range = nextChar[i].X;
                        if (Math.Abs(nextChar[i].Y) > range) range = nextChar[i].Y;
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

        // RETURN COORDINATE RANGE
        // returns the largest X or Y coordinate
        public int getRange(int size)
        {
            return range * size * 100;
        }
    }
}
