using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimaVector.Shape
{
    class PolygonShape : IShape
    {
        public List<Point> Vertices; 

        public int NumberOfVertices;

        public PolygonShape()
        {
            Vertices =  new List<Point>();
            NumberOfVertices = 0;
        }


        public Point[] GetPoints(Point startPoint, Point endPoint)
        {
            throw new NotImplementedException();
        }
    }
}
