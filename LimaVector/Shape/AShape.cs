using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace LimaVector.Shape
{
    public abstract class AShape
    {
        public List<Point> Vertices;
        public Point GravityCenter;
        public Color Color;
        public int PenWidth;

        public Point[] GetPoints()
        {
            return Vertices.ToArray();
        }
        public abstract void UpdateVertices(Point startPoint, Point endPoint);
        public void Rotate(double phi)
        {
            for(int i=0; i < Vertices.Count(); i++)
            {
                Point vertice = Vertices[i];
                Vertices[i] = new Point(
                    (int)(vertice.X * Math.Cos(phi) - vertice.Y * Math.Sin(phi)),
                    (int)(vertice.X * Math.Cos(phi) - vertice.Y * Math.Sin(phi))
                );
            }
        }
        public void Move(Point delta)
        {
            for (int i = 0; i < Vertices.Count(); i++)
            {
                Point vertice = Vertices[i];
                Vertices[i] = new Point(vertice.X+ delta.X, vertice.Y + delta.Y);
            }
        }


        public Bitmap Paint(Bitmap bitmap)
        {
            Pen pen = new Pen(Color, PenWidth);
            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.DrawPolygon(pen, Vertices.ToArray());
            return bitmap;
        }
    }
}
