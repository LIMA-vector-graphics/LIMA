using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimaVector
{
    public static class ExensionMethods
    {
        public static double GetRotationAngle(this PointF center, PointF start, PointF end)
        {
            PointF a = Delta(center, start);
            PointF b = Delta(center, end);
            return GetAngle(a, b);
        }
        private static double GetAngle(PointF a, PointF b) // a, b - vectors
        {
            int sign = Math.Sign(a.Y) * Math.Sign(a.X - b.X);
            if (Math.Abs(a.Y) < 2 || Math.Abs(b.Y) < 2)
            {
                sign = Math.Sign(a.X) * Math.Sign(b.Y - a.Y);
            }

            return sign * Math.Acos((a.X * b.X + a.Y * b.Y) / a.GetLength() / b.GetLength());
        }
        public static float GetLength(this PointF vector)
        {
            return (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
        }

        public static PointF Delta(this PointF start, PointF end)
        {
            return new PointF(end.X - start.X, end.Y - start.Y);
        }

        public static float GetAlpha(this PointF center, PointF point, Point location)
        {
            PointF a = Delta(center, point);
            PointF b = Delta(center, location);
            return GetLength(b) / GetLength(a);
        }

        public static bool Equals(this PointF A, PointF B, float accuracy)
        {
            return A.Delta(B).GetLength() <= accuracy / 2;
        }

        public static bool Belongs(this PointF checkPoint, PointF start, PointF end, double accuracy)
        {
            double x1 = start.X;
            double y1 = start.Y;
            double x2 = end.X;
            double y2 = end.Y;
            double x = checkPoint.X;
            double y = checkPoint.Y;

            if (CheckInside(x, x1, x2, accuracy) && CheckInside(y, y1, y2, accuracy))
                return Math.Abs((x - x1) * (y2 - y1) - (y - y1) * (x2 - x1)) < accuracy / 2 * Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
            else return false;
        }

        private static bool CheckInside(double x, double a, double b, double accuracy)
        {
            if ((x > a - accuracy && x < b + accuracy) || (x > b - accuracy && x < a + accuracy))
                return true;
            else return false;
        }

    }

}
