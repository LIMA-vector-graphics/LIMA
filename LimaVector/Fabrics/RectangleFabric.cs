using LimaVector.Shape;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimaVector.Fabrics
{
    class RectangleFabric : IFabric
    {
        public Shape.AShape CreateShape()
        {
            return new RectangleShape();
        }
    }
}
