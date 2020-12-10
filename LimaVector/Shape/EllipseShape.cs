using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimaVector.Shape
{
    public class EllipseShape : ADragShape
    {
        override public void UpdateVertices(PointF startPoint, PointF endPoint)
        {
            int N = 360;
            Vertices = new List<PointF>();
            GravityCenter = new PointF((startPoint.X + endPoint.X) / 2, (startPoint.Y + endPoint.Y)/2);
            PointF center = new PointF((startPoint.X + endPoint.X) / 2, (startPoint.Y + endPoint.Y) / 2);
            PointF delta = new PointF(endPoint.X - startPoint.X, endPoint.Y - startPoint.Y);
            int radiusX = (int)delta.X / 2;
            int radiusY = (int)delta.Y / 2;

            for (int i = 0; i < N; i++)
            {
                Vertices.Add(new PointF(center.X + (int)(radiusX * Math.Cos(2 * Math.PI * i / N)),
                    center.Y + (int)(radiusY * Math.Sin(2 * Math.PI * i / N))));
            }
            
        }
    }
}
