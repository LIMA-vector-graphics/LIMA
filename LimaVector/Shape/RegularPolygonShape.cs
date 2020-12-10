using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimaVector.Shape
{
    class RegularPolygonShape : ADragShape
    {
        public RegularPolygonShape(int N)
        {
            NumberOfVertices = N;
        }

        override public void UpdateVertices(PointF startPoint, PointF endPoint)
        {

            GravityCenter = new PointF((startPoint.X + endPoint.X) / 2, (startPoint.Y + endPoint.Y) / 2);
            Vertices = new List<PointF>();
            PointF center = GravityCenter;
            PointF delta = new PointF(endPoint.X - startPoint.X, endPoint.Y - startPoint.Y);
            double radius = (int) Math.Sqrt(delta.X * delta.X + delta.Y * delta.Y);
            double phase = Math.PI + Math.Atan2(delta.Y, delta.X);

            for (int i = 0; i < NumberOfVertices; i++)
            {
                Vertices.Add( 
                    new PointF(
                    center.X + (int)(radius * Math.Cos(phase + 2 * Math.PI * i / NumberOfVertices)),
                    center.Y + (int)(radius * Math.Sin(phase + 2 * Math.PI * i / NumberOfVertices))
                    )
                );
            }
        }
    }
}
