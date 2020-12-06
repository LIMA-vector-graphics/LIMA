using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimaVector.Shape
{
    class RegularPolygonShape : AShape
    {
        int N;
        public RegularPolygonShape(int N)
        {
            this.N = N;
        }

        override public void UpdateVertices(Point startPoint, Point endPoint)
        {

            GravityCenter = new Point((startPoint.X + endPoint.X) / 2, (startPoint.Y + endPoint.Y) / 2);
            Vertices = new List<Point>();
            Point center = GravityCenter;
            Point delta = new Point(endPoint.X - startPoint.X, endPoint.Y - startPoint.Y);
            double radius = (int) Math.Sqrt(delta.X * delta.X + delta.Y * delta.Y);
            double phase = Math.PI + Math.Atan2(delta.Y, delta.X);

            for (int i = 0; i < N; i++)
            {
                Vertices.Add( 
                    new Point(
                    center.X + (int)(radius * Math.Cos(phase + 2 * Math.PI * i / N)),
                    center.Y + (int)(radius * Math.Sin(phase + 2 * Math.PI * i / N))
                    )
                );
            }
        }
    }
}
