using LimaVector.Shape;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimaVector.Factories
{
    class PolygonFactory : IFactory
    {
        public AShape CreateShape()
        {
            return new PolygonShape();
        }
    }
}
