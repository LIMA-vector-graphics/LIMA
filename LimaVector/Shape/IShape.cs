using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace LimaVector.Shape
{
    public interface IShape
    {
        Point[] GetPoints(Point startPoint, Point endPoint);
    }
}
