using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimaVector.Shape
{
    public class EllipseShape : IShape
    {
        public Point[] GetPoints(Point startPoint, Point endPoint)
        {
            int N = 360;
            Point[] result = new Point[N];
            Point center = new Point((startPoint.X + endPoint.X) / 2, (startPoint.Y + endPoint.Y) / 2);
            Point delta = new Point((endPoint.X - startPoint.X) / 2, (endPoint.Y - startPoint.Y ) / 2);
            int radiusX = delta.X / 2;
            int radiusY = delta.Y / 2;

            for (int i = 0; i < N; i++)
            {
                result[i] = new Point(center.X + (int)(radiusX * Math.Cos(2 * Math.PI * i / N)),
                    center.Y + (int)(radiusY * Math.Sin(2 * Math.PI * i / N)));
            }
            return result;
        }
    }
}
