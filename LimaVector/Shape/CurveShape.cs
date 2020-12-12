using System;
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
        public override Bitmap Paint(Bitmap bitmap)
        {
            NumberOfVertices = Vertices.Count();
            Pen pen = new Pen(Brushes.Black, 16); 
            pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.DrawLine(pen,Vertices.LastOrDefault(),Vertices[NumberOfVertices-2]);
            return bitmap;
        }
    }
}
