using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimaVector.Shape
{
    class PolygonShape : AShape
    {

        public int NumberOfVertices;

        public PolygonShape()
        {
            Vertices =  new List<Point>();
            NumberOfVertices = 0;
        }


        override public void UpdateVertices(Point startPoint, Point endPoint)
        {
            throw new NotImplementedException();
        }
    }
}
