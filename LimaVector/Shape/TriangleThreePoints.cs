using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace LimaVector.Shape
{
    public class TriangleThreePoints : IThreePointShape
    {
        public List<Point> Vertices;

        public int NumberOfVertices;

        public TriangleThreePoints()
        {
            Vertices = new List<Point>();
            NumberOfVertices = 0;
        }
    public Point[] GetPoints(Point startPoint, Point middlePoint, Point endPoint)
        {

            Point[] points = new Point[3];

            points[0] = startPoint;
            points[1] = middlePoint;
            points[2] = endPoint;

            return points;
        }

       
        public Point[] GetPoints(Point startPoint, Point endPoint)
        {
            throw new NotImplementedException();
        }
    }
}
