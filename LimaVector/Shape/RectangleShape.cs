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
        override public void UpdateVertices(Point startPoint, Point endPoint)
        {

            GravityCenter = new Point((startPoint.X + endPoint.X) / 2, (startPoint.Y + endPoint.Y) / 2);
            // обсчет точек прямоугольника
            Vertices = new List<Point>() {
                startPoint,
                new Point(startPoint.X, endPoint.Y),
                endPoint,
                new Point(endPoint.X, startPoint.Y)
            };
        }

    }
}
