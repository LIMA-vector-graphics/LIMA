using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimaVector.Shape
{
    public class EllipseShape : ADragShape
    {
        int N = 36;
        override public void UpdateVertices(PointF startPoint, PointF endPoint)
        {
            Vertices = new List<PointF>();
            GravityCenter = new PointF((startPoint.X + endPoint.X) / 2, (startPoint.Y + endPoint.Y)/2);
            PointF center = new PointF((startPoint.X + endPoint.X) / 2, (startPoint.Y + endPoint.Y) / 2);
            PointF delta = new PointF(endPoint.X - startPoint.X, endPoint.Y - startPoint.Y);
            int radiusX = (int)delta.X / 2;
            int radiusY = (int)delta.Y / 2;

            for (int i = 0; i < N; i++)
            {
                Vertices.Add(new PointF(center.X + (int)(radiusX * Math.Cos(2 * Math.PI * i / N)),
                    center.Y + (int)(radiusY * Math.Sin(2 * Math.PI * i / N))));
            }            
        }

        public override void Highlight(Canvas canvas)
        {
            int[] footing = new int[] { 0, N / 4, N / 2, 3 * N / 4 };
            foreach (int i in footing)
            {
                Pen pen = new Pen(Color, 2);
                SolidBrush brush = new SolidBrush(Color.LightGray);
                Graphics graphics = Graphics.FromImage(canvas.Bitmap);
                graphics.FillEllipse(brush, Vertices[i].X - PenWidth, Vertices[i].Y - PenWidth, 2 * PenWidth, 2 * PenWidth);
                graphics.DrawEllipse(pen, Vertices[i].X - PenWidth, Vertices[i].Y - PenWidth, 2 * PenWidth, 2 * PenWidth);
            }
        }

        public override void MoveEdge(PointF delta)
        {

        }
        public override void MoveVertice(PointF delta)
        {

        }
    }
}
