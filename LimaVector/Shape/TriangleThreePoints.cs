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

        public List<Point> Vertices;

        public int NumberOfVertices;

        public TriangleThreePoints()
        {
            Vertices = new List<Point>();
            NumberOfVertices = 0;
        }
        override public PointF[] GetPoints(PointF startPoint, PointF middlePoint, PointF endPoint)
        {

            GravityCenter = new PointF((startPoint.X + endPoint.X) / 2, (startPoint.Y + endPoint.Y) / 2);

            PointF[] points = new PointF[3];

            points[0] = startPoint;
            points[1] = middlePoint;
            points[2] = endPoint;

            return points;
        }
        public override void UpdateVertices(PointF startPoint, PointF endPoint)
        {
            throw new NotImplementedException();
        }
    }
}
