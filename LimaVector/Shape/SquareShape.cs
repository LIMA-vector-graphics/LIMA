using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace LimaVector.Shape
{
    public class SquareShape : IShape
    {
        public Point[] GetPoints(Point startPoint, Point endPoint)
        {
            int a = Math.Abs(startPoint.X - endPoint.X); //считаем длинну грани квадрата. получили длинну границы
            if (startPoint.Y > endPoint.Y)
            {
                a = -a;
            }
            // обсчет точек квадрата
            Point[] points = new Point[4];
            points[0] = startPoint;
            points[1] = new Point(startPoint.X, startPoint.Y + a);
            points[2] = new Point(endPoint.X, startPoint.Y + a);
            points[3] = new Point(endPoint.X, startPoint.Y);

            return points;
        }

    }
}
