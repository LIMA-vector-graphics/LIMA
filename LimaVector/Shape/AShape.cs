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
        public int NumberOfVertices;
        public int SelectedVerticeIndex = -1;
        public int SelectedEdgeIndex = -1;
        public bool isHighLightOn = false;
        public bool isVerticeSelected 
        { 
            get 
            { 
                return SelectedVerticeIndex >= 0; 
            }
        }
        public bool isEdgeSelected
        {
            get
            {
                return SelectedEdgeIndex >= 0;
            }
        }


        public PointF[] GetPoints()
        {
            return Vertices.ToArray();
        }

        public abstract void UpdateVertices(PointF startPoint, PointF endPoint);

        public abstract void UpdateVertices(PointF location);

        public void Rotate(double phi)
        {
            for(int i=0; i < Vertices.Count(); i++)
            {
                PointF vertice = Vertices[i];
                PointF delta = GravityCenter.Delta(vertice);
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
        public void MoveVertice(PointF delta) // moving vertice with certain index
        {
            int index = SelectedVerticeIndex;
            Vertices[index] = new PointF(Vertices[index].X + delta.X, Vertices[index].Y + delta.Y);
            UpdateCenter();
        }

        public void MoveEdge(PointF delta) // moving vertice with certain index
        {
            int index = SelectedEdgeIndex;
            NumberOfVertices = Vertices.Count();
            Vertices[index] = new PointF(Vertices[index].X + delta.X, Vertices[index].Y + delta.Y);
            if(index == 0)
            {
                Vertices[NumberOfVertices - 1] = 
                        new PointF(Vertices[NumberOfVertices - 1].X + delta.X, 
                                Vertices[NumberOfVertices - 1].Y + delta.Y);
            }
            else
            {
                Vertices[index - 1] = new PointF(Vertices[index - 1].X + delta.X, Vertices[index - 1].Y + delta.Y);
            }

            UpdateCenter();
        }


        public virtual void Paint(Canvas canvas)
        {
            Pen pen = new Pen(Color, PenWidth);
            Graphics graphics = Graphics.FromImage(canvas.Bitmap);
            graphics.DrawPolygon(pen, Vertices.ToArray());
            if (isHighLightOn)
            {
                Highlight(canvas);
            }
        }
        public void Resize (float alpha)
        {
            for (int i = 0; i < Vertices.Count(); i++)
            {
                PointF vertice = Vertices[i];
                PointF d = new PointF(vertice.X - GravityCenter.X, vertice.Y - GravityCenter.Y);

                Vertices[i] = new PointF(GravityCenter.X + alpha * (vertice.X - GravityCenter.X),
                GravityCenter.Y + alpha * (vertice.Y - GravityCenter.Y));
            }
        }

        public void UpdateCenter()
        {
            float x = 0;
            float y = 0;
            int n = Vertices.Count();

            foreach (PointF vertice in Vertices)
            {
                x += vertice.X;
                y += vertice.Y;
            }
            GravityCenter = new PointF(x / n, y / n);
        }
    
        public virtual void Highlight(Canvas canvas)
        {
            for(int i = 0; i< Vertices.Count(); i++)
            {
                Pen pen = new Pen(Color, 2);
                SolidBrush brush = new SolidBrush(Color.LightGray);
                Graphics graphics = Graphics.FromImage(canvas.Bitmap);
                graphics.FillEllipse(brush, Vertices[i].X - PenWidth, Vertices[i].Y - PenWidth, 2 * PenWidth, 2 * PenWidth);
                graphics.DrawEllipse(pen, Vertices[i].X - PenWidth, Vertices[i].Y - PenWidth, 2 * PenWidth, 2 * PenWidth);
            }
        }

        public void ClearSelection()
        {
            isHighLightOn = false;
            SelectedVerticeIndex = -1;
            SelectedEdgeIndex = -1;
        }
    }
}