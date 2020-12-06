using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace LimaVector.Shape
{
    public class SquareShape : AShape
    {
        override public void UpdateVertices(Point startPoint, Point endPoint)
        {

            GravityCenter = new Point((startPoint.X + endPoint.X) / 2, (startPoint.Y + endPoint.Y) / 2);
            int a = Math.Abs(startPoint.X - endPoint.X); //считаем длинну грани квадрата. получили длинну границы
            if (startPoint.Y > endPoint.Y)
            {
                a = -a;
            }
            // обсчет точек квадрата
            Vertices = new List<Point>() {
                startPoint,
                new Point(startPoint.X, startPoint.Y + a),
                new Point(endPoint.X, startPoint.Y + a),
                new Point(endPoint.X, startPoint.Y)
            };

        }

    }
}
