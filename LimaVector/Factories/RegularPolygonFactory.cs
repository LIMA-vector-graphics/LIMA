using LimaVector.Shape;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimaVector.Factories
{
    class RegularPolygonFactory : IFactory
    {
        int numberOfVertices;

        public RegularPolygonFactory(int N)
        {
            numberOfVertices = N;
        }

        public AShape CreateShape()
        {
            return new RegularPolygonShape(numberOfVertices);
        }
    }
}
