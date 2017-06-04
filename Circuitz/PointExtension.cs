using System;
using System.Drawing;

namespace Circuitz
{
    public static class PointExtension
    {
        public static float Distance(this Point p1, Point p2)
        {
            return (float)Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
        }

        public static Point Add(this Point p1, Point p2)
        {
            return new Point(p1.X + p2.X, p1.Y + p2.Y);
        }
        public static Point Subtract(this Point p1, Point p2)
        {
            return new Point(p1.X - p2.X, p1.Y - p2.Y);
        }
        public static Point Modulo(this Point p, int n)
        {
            return new Point(p.X % n, p.Y % n);
        }
        public static Point Snap(this Point p, int n)
        {
            return new Point(p.X / n * n, p.Y / n * n);
        }
    }
}