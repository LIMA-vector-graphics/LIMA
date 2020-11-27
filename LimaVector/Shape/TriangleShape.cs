using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace LimaVector.Shape
{
    public class TriangleShape : IShape
    {
        public Point[] GetPoints(Point startPoint, Point endPoint)
        {

            Point[] points = new Point[3];

            points[0] = startPoint;
            points[1] = new Point(startPoint.X, endPoint.X);
            points[2] = endPoint;

            return points;

        }

        //public Point[] GetPoints(Point startPoint, Point endPoint)
        //{
        //    int a = Math.Abs(startPoint.X - endPoint.X);


        //    Point[] points = new Point[3];

        //    points[0] = startPoint;
        //    points[1] = new Point(startPoint.X, startPoint.X + a);
        //    points[2] = new Point(endPoint.X+a, startPoint.X);

        //    return points;

        //}

    }
}
