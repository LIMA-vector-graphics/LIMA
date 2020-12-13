using LimaVector.Shape;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimaVector.Factories
{
    class LineFactory : IFactory
    {
        public AShape CreateShape()
        {
            return new LineShape();
        }
    }
}
