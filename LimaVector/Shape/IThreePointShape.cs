using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace LimaVector.Shape
{
    public interface IThreePointShape : IShape
    {
        Point[] GetPoints(Point startPoint, Point middlePoint, Point endPoint);
    }
}
