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
        public List<PointF> Vertices;
        public PointF GravityCenter;
        public Color Color;
        public int PenWidth;

        public PointF[] GetPoints()
        {
            return Vertices.ToArray();
        }
        public abstract void UpdateVertices(PointF startPoint, PointF endPoint);
        public void Rotate(double phi)
        {
            for(int i=0; i < Vertices.Count(); i++)
            {
                PointF vertice = Vertices[i];
                PointF delta = new PointF(vertice.X - GravityCenter.X, vertice.Y - GravityCenter.Y);
                Vertices[i] = new PointF(
                    (float)(GravityCenter.X + delta.X * Math.Cos(phi) - delta.Y * Math.Sin(phi)),
                    (float)(GravityCenter.Y + delta.X * Math.Sin(phi) + delta.Y * Math.Cos(phi))
                );
            }
        }
        public void Move(PointF delta)
        {
            GravityCenter = new PointF(GravityCenter.X + delta.X, GravityCenter.Y + delta.Y);
            for (int i = 0; i < Vertices.Count(); i++)
            {
                PointF vertice = Vertices[i];
                Vertices[i] = new PointF(vertice.X+ delta.X, vertice.Y + delta.Y);
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
