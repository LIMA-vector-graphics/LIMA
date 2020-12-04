using LimaVector.Shape;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimaVector
{
    class Selector
    {
        Bitmap _bitmap;
        List<Shape.AShape> _shapes;

        public Selector(Bitmap bitmap, List<Shape.AShape> shapes)
        {
            _shapes = shapes;
            _bitmap = bitmap;
        }

        public AShape Select(Point point)
        {
            if(_shapes.Count() == 0)
            {
                return null;
            }
            foreach(AShape shape in _shapes)
            {
                if(shape!= null)
                {
                    Point previousVertice = shape.Vertices[shape.Vertices.Count - 1];
                    for(int i=0; i < shape.Vertices.Count; i++)
                    {
                        if (Contain(shape.Vertices[i], previousVertice, point, shape.PenWidth))
                        {
                            return shape;
                        }
                        previousVertice = shape.Vertices[i];
                    }
                }
                
            }
            return null;
        }

        private bool Contain(Point start, Point end, Point checkPoint, double accuracy)
        {
            double x1 = start.X;
            double y1 = start.Y;
            double x2 = end.X;
            double y2 = end.Y;
            double x = checkPoint.X;
            double y = checkPoint.Y;

            if (CheckInside(x, x1, x2, accuracy) && CheckInside(y, y1, y2, accuracy))
                    return Math.Abs((x - x1) * (y2 - y1) - (y - y1) * (x2 - x1)) < accuracy / 2 * Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
            else return false;
        }

        private bool CheckInside(double x, double a, double b, double accuracy)
        {
            if ((x > a - accuracy && x < b + accuracy) || (x > b - accuracy && x < a + accuracy))
                return true;
            else return false;
        }
    }
}
