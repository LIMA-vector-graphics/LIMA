using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using LimaVector.Shape;

namespace LimaVector
{
    class Painter
    {
        IShape _shape;
        Pen _pen;
        Graphics _graphics;
        Bitmap _bitmap;

        public Painter(IShape shape, Pen pen, Bitmap bitmap)
        {
            _shape = shape;
            _pen = pen;
            _bitmap = bitmap;
            _graphics = Graphics.FromImage(_bitmap);
        }

        public Bitmap Paint(Point start, Point end)
        {
            _graphics.DrawPolygon(_pen, _shape.GetPoints(start, end));
            return _bitmap;
        }
    }
}
