using LimaVector.Shape;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimaVector.Fabrics
{
    class TriangleFabric : IFabric
    {
        public AShape CreateShape()
        {
            return new TriangleShape();
        }
    }
}
