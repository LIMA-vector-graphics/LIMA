using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimaVector.Shape
{
    public class EllipseShape : AShape
    {
        override public void UpdateVertices(Point startPoint, Point endPoint)
        {
            int N = 360;
            Vertices = new List<Point>();
            GravityCenter = new Point((startPoint.X + endPoint.X) / 2, (startPoint.Y + endPoint.Y)/2);
            Point center = new Point((startPoint.X + endPoint.X) / 2, (startPoint.Y + endPoint.Y) / 2);
            Point delta = new Point(endPoint.X - startPoint.X, endPoint.Y - startPoint.Y);
            int radiusX = delta.X / 2;
            int radiusY = delta.Y / 2;

            for (int i = 0; i < N; i++)
            {
                Vertices.Add(new Point(center.X + (int)(radiusX * Math.Cos(2 * Math.PI * i / N)),
                    center.Y + (int)(radiusY * Math.Sin(2 * Math.PI * i / N))));
            }
            
        }
    }
}
