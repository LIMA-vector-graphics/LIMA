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
           
             if (NumberOfVertices == 1)
            {
                Vertices[1] = location; // добавили точку в вершину
              
            }
            else if (NumberOfVertices == 2)
            {
                
                Vertices[2] = location; // оказывается две точки с одинаковыми координатами
            }
          

        }

        public void AddVertices(PointF location)
        {
            if (NumberOfVertices == 0)
            {
                Vertices[0] = location;
                NumberOfVertices = 1;
            }
            else if (NumberOfVertices == 1)
            {
                Vertices[1] = location; // добавили точку в вершину
                NumberOfVertices = 2;
            }
            else if (NumberOfVertices == 2)
            {
                NumberOfVertices = 3;
                Vertices[2] = location; // оказывается две точки с одинаковыми координатами
            }
           

        }
        public override void Paint(Canvas canvas) //PointF location)
        {
        // линия или две лиинии в зависимости от кол-ва вершин
       
            Pen pen = new Pen(Color, PenWidth);
            Graphics graphics = Graphics.FromImage(canvas.Bitmap);

                switch (NumberOfVertices)
                {
                
                    case 1:
                        graphics.DrawLine(pen, Vertices[0], Vertices[1]);
                        break;
                    case 2:
                        graphics.DrawLine(pen, Vertices[0], Vertices[1]);
                        graphics.DrawLine(pen, Vertices[1], Vertices[2]);
                        graphics.DrawLine(pen, Vertices[2], Vertices[0]);
                    break;
                    case 3:
                        graphics.DrawLine(pen, Vertices[0], Vertices[1]);
                        graphics.DrawLine(pen, Vertices[1], Vertices[2]);
                        graphics.DrawLine(pen, Vertices[2], Vertices[0]);
                    break;
            }
        }
    }
}
