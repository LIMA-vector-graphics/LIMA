﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace LimaVector.Shape
{
    public class CurveShape : AShape
    {
        public override void UpdateVertices(PointF startPoint, PointF endPoint)
        {

        }

        public CurveShape() //конструктор
        {
            Vertices = new List<PointF>();
        }

        public override void UpdateVertices(PointF location)
        {
            Vertices.Add(location);
        }
        public override void Paint(Canvas canvas)
        {
            NumberOfVertices = Vertices.Count();
            Pen pen = new Pen(Color,PenWidth);
            Graphics graphics = Graphics.FromImage(canvas.bitmap);
            graphics.DrawLine(pen,Vertices.LastOrDefault(),Vertices[NumberOfVertices-2]);
        }
    }
}
