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
            Vertices =  new List<PointF>();
            NumberOfVertices = 0;
        }


        override public void UpdateVertices(PointF startPoint, PointF endPoint)
        {
            throw new NotImplementedException();
        }
    }
}
