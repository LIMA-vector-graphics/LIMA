using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace LimaVector.Shape
{
    public class RectangleShape : IShape
    {
        public Point[] GetPoints(Point startPoint, Point endPoint)
        {
            // обсчет точек прямоугольника

            Point[] points = new Point[4];
            points[0] = startPoint;
            points[1] = new Point(startPoint.X, endPoint.Y);
            points[2] = endPoint;
            points[3] = new Point(endPoint.X, startPoint.Y);

            return points;
        }

    }
}
