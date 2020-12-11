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
        public TriangleThreePoints() //конструктор
        {
            Vertices = new List<PointF>() {new PointF(0,0), new PointF(0, 0) , new PointF(0, 0) };
            NumberOfVertices = 0;
        }

        public override void UpdateVertices(PointF startPoint, PointF endPoint)
        {
            
        }

        public override void UpdateVertices(PointF location)
        {
            if (NumberOfVertices >=3)
            {
                Vertices.Clear();
                NumberOfVertices = 0;
            }
            switch (NumberOfVertices)
            {

                case 0:
                    Vertices[0]=location;
                    NumberOfVertices = 1;
                    break;

                case 1:
                    Vertices[1] = location; // добавили точку в вершину
                    NumberOfVertices = 2;
                    break;

                case 2:
                    NumberOfVertices = 3;
                    Vertices[2] = location; 
                  
                    break;
            }
        }

        public override Bitmap Paint(Bitmap bitmap) //PointF location)
        {
        // линия или две лиинии в зависимости от кол-ва вершин
       
                Pen pen = new Pen(Color, PenWidth);
                Graphics graphics = Graphics.FromImage(bitmap);

                switch (NumberOfVertices)
                {
                    case 2:
                        graphics.DrawLine(pen, Vertices[0], Vertices[1]);
                        break;
                    case 3:
                        graphics.DrawLine(pen, Vertices[1], Vertices[2]);
                        graphics.DrawLine(pen, Vertices[2], Vertices[0]);
                        break;
                }

            return bitmap;
        }
    }


}
