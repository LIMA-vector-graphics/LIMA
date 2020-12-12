using LimaVector.Fabrics;
using LimaVector.Shape;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;


namespace LimaVector
{
    public partial class Form1 : Form
    {
        Bitmap mainBitmap; //Основной слой на который будут копироваться все нарисованные фигуры
        Bitmap tmpBitmap; // Копия основного слоя ImageBox на котором происходит процесс рисования
        Graphics graphics;
        Pen pen;
        PointF point;
        bool mD;
        int NumberOfVertices;
        
        List<AShape> shapes;
        string _action = ""; //// поле в котором будет храниться текущее действие

        AShape currentShape;
        PolygonShape polygon;
        IFabric fabric;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            shapes = new List<AShape>();
            mainBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pen = new Pen(System.Drawing.Color.Black, 16);
            pictureBox1.Image = mainBitmap;
            numberOfVertices.Value = 5;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mD && currentShape != null)
            {
                switch (_action)
                {
                    case "paint":
                        if (currentShape is ADragShape) 
                        {
                            tmpBitmap = (Bitmap)mainBitmap.Clone();
                            currentShape.UpdateVertices(point, e.Location);
                            pictureBox1.Image = currentShape.Paint(tmpBitmap);
                            GC.Collect();
                        }
                        if (currentShape is TriangleThreePoints)
                        {
                            tmpBitmap = (Bitmap)mainBitmap.Clone();
                            currentShape.UpdateVertices(e.Location);
                            pictureBox1.Image = currentShape.Paint(tmpBitmap);
                            GC.Collect();
                        }
                        if (currentShape is PolygonShape)
                        { }
                        if (currentShape is CurveShape)
                        {

                            //graphics = Graphics.FromImage(mainBitmap);
                            //graphics.DrawLine(pen, point, e.Location);
                            //pictureBox1.Image = mainBitmap;
                            //point = e.Location;

                            //tmpBitmap = (Bitmap)mainBitmap.Clone();
                            currentShape.UpdateVertices(e.Location);
                            pictureBox1.Image = currentShape.Paint(mainBitmap);
                            GC.Collect();
                        }
                        break;

                    case "rotate":
                        double phi = GetRotationAngle(currentShape.GravityCenter, point, e.Location);
                        currentShape.Rotate(phi);
                        tmpBitmap = (Bitmap)mainBitmap.Clone();
                        pictureBox1.Image = currentShape.Paint(tmpBitmap);
                        GC.Collect();
                        point = e.Location;
                        break;
                    case "move":
                        PointF delta = Delta(point, e.Location);
                        currentShape.Move(delta);
                        tmpBitmap = (Bitmap)mainBitmap.Clone();
                        pictureBox1.Image = currentShape.Paint(tmpBitmap);
                        point = e.Location;
                        GC.Collect();
                        break;
                    case "resize":
                        float alpha = GetAlpha(currentShape.GravityCenter, point, e.Location);
                        currentShape.Resize(alpha);
                        tmpBitmap = (Bitmap)mainBitmap.Clone();
                        pictureBox1.Image = currentShape.Paint(tmpBitmap);
                        point = e.Location;
                        GC.Collect();
                        break;

                    //case "Triangle":
                    //    if (currentShape.NumberOfVertices != 0)
                    //    {
                    //        tmpBitmap = (Bitmap)mainBitmap.Clone();
                    //        graphics = Graphics.FromImage(tmpBitmap);
                    //        graphics.DrawLine(pen, point, e.Location);

                    //        if (currentShape.NumberOfVertices == 2)
                    //        {
                    //            graphics.DrawLine(pen, currentShape.Vertices[0], e.Location);
                    //        }
                    //        pictureBox1.Image = tmpBitmap;
                    //        GC.Collect();
                            //blablablabl
                            //blablabla
                    //     }
                    //break;
                }
            }
        }

        private float GetAlpha(PointF center, PointF point, Point location)
        {
            PointF a = Delta(center, point);
            PointF b = Delta(center, location);
            return GetLength(b) / GetLength(a);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            point = e.Location;
            mD = true;

            //if (_action == "Triangle") // выбранный режим
            //{
            //    if (!(currentShape is TriangleThreePoints) || currentShape == null)
            //    {
            //        currentShape = fabric.CreateShape();
            //        currentShape.Color = pen.Color;
            //        currentShape.PenWidth = (int)pen.Width;
            //    }

                //switch (currentShape.NumberOfVertices)
                //{
                //    case 0:
                //        currentShape.Vertices.Add(e.Location);
                //        currentShape.NumberOfVertices = 1;
                //        break;

                //    case 1:
                //        currentShape.Vertices.Add(e.Location); // добавили точку в вершину
                //        graphics = Graphics.FromImage(mainBitmap);
                //        graphics.DrawLine(pen, currentShape.Vertices[0], e.Location);
                //        currentShape.NumberOfVertices = 2;
                //        pictureBox1.Image = mainBitmap;
                //        break;

                //    case 2:
                //        graphics = Graphics.FromImage(mainBitmap);
                //        graphics.DrawLine(pen, currentShape.Vertices[0], e.Location);
                //        graphics.DrawLine(pen, currentShape.Vertices[1], e.Location);
                //        pictureBox1.Image = mainBitmap;
                //        currentShape.NumberOfVertices = 0;
                //        currentShape.Vertices.Clear();
                //        break;
            //}

            
            if (_action == "paint")

            {
                if (!(currentShape is TriangleThreePoints) || !(currentShape == null))
                {
                    currentShape = fabric.CreateShape();
                    currentShape.Color = pen.Color;
                    currentShape.PenWidth = (int)pen.Width;
                }
                if (currentShape is TriangleThreePoints)
                {
                    currentShape.UpdateVertices(e.Location);// не заходит в метод не обнавляет вершины
                }
                if(currentShape is CurveShape)
                {
                    currentShape.UpdateVertices(e.Location);
                }
             
            }

            if (_action == "rotate" || _action == "move" ||_action=="resize")
            {
                Selector selector = new Selector(mainBitmap, shapes);
                currentShape = selector.Select(e.Location);
                shapes.Remove(currentShape);
                PaintAll();
            }

        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (_action == "paint" || _action == "rotate" || _action == "move" || _action == "resize")
            {
                mD = false;
                mainBitmap = tmpBitmap;
                shapes.Add(currentShape);
            }
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (_action == "Polygon")
            {
                if (polygon.NumberOfVertices == 0)
                {
                    polygon.Vertices.Add(e.Location);

                    graphics = Graphics.FromImage(mainBitmap);
                    polygon.NumberOfVertices++;
                }
                else
                {
                    graphics = Graphics.FromImage(mainBitmap);
                    graphics.DrawLine(pen, polygon.Vertices[polygon.NumberOfVertices - 1], e.Location);
                    polygon.NumberOfVertices++;
                    polygon.Vertices.Add(e.Location);//записали в массив новую точку 
                    pictureBox1.Image = mainBitmap;
                }
            }
        }

        private void Rectangle_Click(object sender, EventArgs e)
        {
            _action = "paint";
            fabric = new RectangleFabric();
        }

        private void Square_Click(object sender, EventArgs e)
        {
            _action = "paint";
            fabric = new SquareFabric();
        }

        private void Line_Click(object sender, EventArgs e)
        {
            _action = "paint";
            fabric = new LineFabric();
        }

        private void Triangel_Click(object sender, EventArgs e)
        {
            _action = "paint";
            fabric = new TriangleFabric();
        }

        private void Curve_Click(object sender, EventArgs e)
        {
            _action = "paint";
            fabric = new CurveFabric();
            currentShape = fabric.CreateShape();
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            pen.Width = hScrollBar1.Value;
        }

        private void Ellipse_Click(object sender, EventArgs e)
        {
            _action = "paint";
            fabric = new EllipseFabric();
        }

        private void Polygon_Click(object sender, EventArgs e)
        {
            _action = "polygon";
            fabric = new PolygonFabric();
        }

        private void Polygon_Click_1(object sender, EventArgs e)
        {
            _action = "Polygon";
            fabric = new PolygonFabric();
        }

        private void RegularPolygon_Click(object sender, EventArgs e)
        {
            _action = "paint";
            fabric = new RegularPolygonFabric(NumberOfVertices);
        }

        private void numberOfVertices_ValueChanged(object sender, EventArgs e)
        {
            NumberOfVertices = Convert.ToInt32(numberOfVertices.Value);
            fabric = new RegularPolygonFabric(NumberOfVertices);
        }

        private void TriangleThreePoints_Click(object sender, EventArgs e)
        {
            _action = "paint";
            fabric = new TriangleThreePointsFabric();
        }

        private void Color_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            pen.Color = colorDialog1.Color;
        }

        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            graphics = Graphics.FromImage(mainBitmap);
            graphics.DrawLine(pen, polygon.Vertices[polygon.NumberOfVertices - 1], e.Location);
            graphics.DrawLine(pen, polygon.Vertices[0], e.Location);
            polygon.NumberOfVertices = 0;
            polygon.Vertices.Clear();
            pictureBox1.Image = mainBitmap;
        }

        private void ClearAll_Click(object sender, EventArgs e)
        {
            mainBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = mainBitmap;
            shapes.Clear();
        }

        private void Rotate_Click(object sender, EventArgs e)
        {
            _action = "rotate";
        }

        private void BrokenLine_Click(object sendet, EventArgs e)
        {
            _action = "polygon";
        }
        private double GetRotationAngle(PointF center, PointF start, PointF end)
        {
            PointF a = Delta(center, start);
            PointF b = Delta(center, end);
            return GetAngle(a, b);
            //return GetLength(Delta(start, end));
        }

        private double GetAngle(PointF a, PointF b) // a, b - vectors
        {
            int sign = Math.Sign(a.Y) * Math.Sign(a.X - b.X);
            if (Math.Abs(a.Y) < 2 || Math.Abs(b.Y) < 2)
            {
                sign = Math.Sign(a.X) * Math.Sign(b.Y - a.Y);
            }

            return sign * Math.Acos((a.X * b.X + a.Y * b.Y) / GetLength(a) / GetLength(b));
        }
        private float GetLength(PointF vector)
        {
            return (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
        }

        private PointF Delta(PointF start, PointF end)
        {
            return new PointF(end.X - start.X, end.Y - start.Y);
        }

        private void Move_Click(object sender, EventArgs e)
        {
            _action = "move";
        }

        public void PaintAll()
        {
            mainBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            foreach (AShape shape in shapes)
            {
                if (shape != null)
                    shape.Paint(mainBitmap);
            }

        }

        private void Resize_Click(object sender, EventArgs e)
        {
            _action = "resize";
        }

        private void SelectVertice_Click(object sender, EventArgs e)
        {
            _action = "selectVertice";
        }
    }
}
