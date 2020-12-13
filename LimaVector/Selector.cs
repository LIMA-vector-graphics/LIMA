using LimaVector.Shape;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimaVector
{
    public class Selector
    {
        List<AShape> _shapes;

        public Selector(List<AShape> shapes)
        {
            _shapes = shapes;
        }

        public AShape Select(PointF point)
        {
            if (_shapes.Count() == 0)
            {
                return null;
            }
            foreach (AShape shape in _shapes)
            {
                if (shape != null)
                {
                    PointF previousVertice = shape.Vertices[shape.Vertices.Count() - 1];
                    for (int i = 0; i < shape.Vertices.Count; i++)
                    {
                        if (point.Belongs(shape.Vertices[i], previousVertice, shape.PenWidth))
                        {
                            shape.isHighLightOn = true;
                            shape.SelectedEdgeIndex = i;
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
                    for (int i = 0; i < shape.Vertices.Count(); i++)
                    {
                        if (shape.Vertices[i].Equals(point, shape.PenWidth))
                        {
                            shape.isHighLightOn = true;
                            shape.SelectedVerticeIndex = i;
                            return shape;
                        }
                    }
                }

            }
            return null;
        }
        public void ClearSelection()
        {
            if (_shapes != null)
            {
                foreach (AShape shape in _shapes)
                {
                    if(shape != null) 
                    {
                        shape.ClearSelection();
                    }
                }
            }
        }
    }
}
