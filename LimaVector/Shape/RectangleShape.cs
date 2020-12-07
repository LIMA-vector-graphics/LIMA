using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace LimaVector.Shape
{
    public class RectangleShape : AShape
    {
        override public void UpdateVertices(PointF startPoint, PointF endPoint)
        {

            GravityCenter = new PointF((startPoint.X + endPoint.X) / 2, (startPoint.Y + endPoint.Y) / 2);
            // обсчет точек прямоугольника
            Vertices = new List<PointF>() {
                startPoint,
                new PointF(startPoint.X, endPoint.Y),
                endPoint,
                new PointF(endPoint.X, startPoint.Y)
            };
        }

    }
}
