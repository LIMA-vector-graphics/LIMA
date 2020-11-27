using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace LimaVector.Shape
{
    public class LineShape : IShape
    {
        public Point[] GetPoints(Point startPoint, Point endPoint)
        {
            return new Point[] { startPoint, endPoint };
        }
    }
}
