using LimaVector.Shape;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimaVector.Fabrics
{
    class RegularPolygonFabric : IFabric
    {
        int numberOfVertices;

        public RegularPolygonFabric(int N)
        {
            numberOfVertices = N;
        }

        public AShape CreateShape()
        {
            return new RegularPolygonShape(numberOfVertices);
        }
    }
}
