using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LimaVector.Shape;

namespace LimaVector.Fabrics
{
    class TriangleThreePointsFabric : IFabric
    {
        public AShape CreateShape()
        {
            return new TriangleThreePoints();
        }
    }
}
