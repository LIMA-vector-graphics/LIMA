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
        List<AShape> _shapes;

        public Selector(Bitmap bitmap, List<Shape.AShape> shapes)
        {
            _shapes = shapes;
            _bitmap = bitmap;
        }

        public AShape Select(PointF point)
        {
            if(_shapes.Count() == 0)
            {
                return null;
            }
            foreach(AShape shape in _shapes)
            {
                if(shape!= null)
                {
                    PointF previousVertice = shape.Vertices[shape.Vertices.Count - 1];
                    for(int i=0; i < shape.Vertices.Count; i++)
                    {
                        if (point.Belongs(shape.Vertices[i], previousVertice, shape.PenWidth))
                        {
                            shape.Highlight();
                            return shape;
                        }
                        previousVertice = shape.Vertices[i];
                    }
                }
                
            }
            return null;
        }

        public AShape SelectVertice(PointF point)
        {
            if (_shapes.Count() == 0)
            {
                return null;
            }
            foreach (AShape shape in _shapes)
            {
                if (shape != null)
                {
                    for (int i = 0; i < shape.Vertices.Count; i++)
                    {
                        if(shape.Vertices[i].Equals(point, shape.PenWidth))
                        {
                            shape.Highlight();
                            shape.SelectedVerticeIndex = i;
                            return shape;
                        }
                    }
                }

            }
            return null;
        }

        private Tuple<AShape, int> Tuple(AShape shape, int i)
        {
            throw new NotImplementedException();
        }
    }
}
