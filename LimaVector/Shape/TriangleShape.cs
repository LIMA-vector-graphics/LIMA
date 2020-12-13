using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace LimaVector.Shape
{
    public class TriangleShape : ADragShape
    {
        override public void UpdateVertices(PointF startPoint, PointF endPoint)
        {
            Vertices = new List<PointF>() {
                startPoint,
                new PointF(startPoint.X, endPoint.Y),
                endPoint
            };

            UpdateCenter();
        }
    }
}
