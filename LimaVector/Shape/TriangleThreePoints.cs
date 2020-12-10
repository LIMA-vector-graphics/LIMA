using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace LimaVector.Shape
{
    public class TriangleThreePoints : AShape
    {
        public TriangleThreePoints()
        {
            Vertices = new List<PointF>();
            NumberOfVertices = 0;
        }

        public override void UpdateVertices(PointF startPoint, PointF endPoint)
        {
            
        }

        public override void UpdateVertices(PointF location)
        {
          
        }
         
        public override Bitmap Paint(Bitmap bitmap) //PointF location)
        {
            // линия или две лиинии в зависимости от кол-ва вершин
            return bitmap;
        }
    }


}
