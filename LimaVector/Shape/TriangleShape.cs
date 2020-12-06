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
            points[1] = new Point(startPoint.X, endPoint.Y);
            points[2] = endPoint;


            return points;


        }
      

    }
}
