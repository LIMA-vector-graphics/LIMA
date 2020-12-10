using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace LimaVector.Shape
{
    public class SquareShape : ADragShape
    {
        override public void UpdateVertices(PointF startPoint, PointF endPoint)
        {

            GravityCenter = new PointF((startPoint.X + endPoint.X) / 2, (startPoint.Y + endPoint.Y) / 2);
            int a = (int)Math.Abs(startPoint.X - endPoint.X); //считаем длинну грани квадрата. получили длинну границы
            if (startPoint.Y > endPoint.Y)
            {
                a = -a;
            }
            // обсчет точек квадрата
            Vertices = new List<PointF>() {
                startPoint,
                new PointF(startPoint.X, startPoint.Y + a),
                new PointF(endPoint.X, startPoint.Y + a),
                new PointF(endPoint.X, startPoint.Y)
            };

        }

    }
}
