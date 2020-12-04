using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace LimaVector.Shape
{
    public class TriangleThreePoints : IThreePointShape
    {
        override public Point[] GetPoints(Point startPoint, Point middlePoint, Point endPoint)
        {

            GravityCenter = new Point((startPoint.X + endPoint.X) / 2, (startPoint.Y + endPoint.Y) / 2);

            Point[] points = new Point[3];

            points[0] = startPoint;
            points[1] = middlePoint;
            points[2] = endPoint;

            return points;
        }

        public override void UpdateVertices(Point startPoint, Point endPoint)
        {
            throw new NotImplementedException();
        }
    }
}
