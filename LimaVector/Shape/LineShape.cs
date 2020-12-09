using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace LimaVector.Shape
{
    public class LineShape : AShape
    {
        override public void UpdateVertices(PointF startPoint, PointF endPoint)
        {
            GravityCenter = new PointF((startPoint.X + endPoint.X) / 2, (startPoint.Y + endPoint.Y) / 2);
            Vertices = new List<PointF>();
            Vertices.Add(startPoint);
            Vertices.Add(endPoint);
        }
    }
}
