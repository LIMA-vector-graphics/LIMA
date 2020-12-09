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
        Point point;
        Point start;
        Point next;
        int counter;

        bool mD;
      
        int NumberOfVertices;
        PolygonShape polygon;
   
        TriangleThreePoints triangleThreePoints; //создали объект класса
       

        IFabric fabric;
        List<AShape> shapes;


        List<Point> _clickedPoints = new List<Point>(); // _приватные переменные (поля), список точек для треугольника по трем точкам
        string _action = ""; //// поле в котором будет храниться текущее действие


        AShape currentShape;
        IThreePointShape shapeThreePoints;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            shapes = new List<AShape>();
            mainBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            
            pen = new Pen(System.Drawing.Color.Red, 5);
            pictureBox1.Image = mainBitmap;
           
            numberOfVertices.Value = 5;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mD && currentShape != null)
            {
                switch (_action)
                {
                    case "drag":
                        tmpBitmap = (Bitmap)mainBitmap.Clone();
                        currentShape.UpdateVertices(point, e.Location);
                        pictureBox1.Image = currentShape.Paint(tmpBitmap);
                        GC.Collect();
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
                        Point delta = Delta(point, e.Location);
                        currentShape.Move(delta);
                        tmpBitmap = (Bitmap)mainBitmap.Clone();
                        pictureBox1.Image = currentShape.Paint(tmpBitmap);
                        point = e.Location;
                        GC.Collect();
                        break;

                    case "Triangle":
                        if (triangleThreePoints != null && triangleThreePoints.NumberOfVertices != 0)
                        {
                            tmpBitmap = (Bitmap)mainBitmap.Clone();
                            graphics = Graphics.FromImage(tmpBitmap);
                            graphics.DrawLine(pen, point, e.Location);

                            if (triangleThreePoints.NumberOfVertices == 2)
                            {
                                graphics.DrawLine(pen, triangleThreePoints.Vertices[0], e.Location);
                            }
                            pictureBox1.Image = tmpBitmap;
                            GC.Collect();
                        }

                        break;
                }
            }
           
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            point = e.Location;
            mD = true;
            currentShape = fabric.CreateShape();
            currentShape.Color = pen.Color;
            currentShape.PenWidth = (int)pen.Width;

            if (_action == "Triangle") // выбранный режим
            {
                switch (triangleThreePoints.NumberOfVertices)
                {
                    case 0:
                        triangleThreePoints.Vertices.Add(e.Location);
                        triangleThreePoints.NumberOfVertices=1;
                        break;
                    
                    case 1:
                        triangleThreePoints.Vertices.Add(e.Location); // добавили точку в вершину
                        graphics = Graphics.FromImage(mainBitmap);
                        graphics.DrawLine(pen, triangleThreePoints.Vertices[0], e.Location);
                        triangleThreePoints.NumberOfVertices=2;
                        pictureBox1.Image = mainBitmap;
                        break;

                    case 2:
                        graphics = Graphics.FromImage(mainBitmap);
                        graphics.DrawLine(pen, triangleThreePoints.Vertices[0], e.Location);
                        graphics.DrawLine(pen, triangleThreePoints.Vertices[1], e.Location);
                        pictureBox1.Image = mainBitmap;
                        triangleThreePoints.NumberOfVertices = 0;
                        triangleThreePoints.Vertices.Clear();
                        break;
                }
  
            }

            if (_action == "drag")
            {
                point = e.Location;
                mD = true;
            }

            if (_action == "rotate" || _action == "move")
            {
                point = e.Location;
                mD = true;
                Selector selector = new Selector(mainBitmap, shapes);
                currentShape = selector.Select(e.Location);
                shapes.Remove(currentShape);
                PaintAll();
            }

        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (_action == "drag" || _action == "rotate" || _action =="move")
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

            if (_action == "Triangle")
            {

            }
        }

        private void Rectangle_Click(object sender, EventArgs e)
        {
            _action = "drag";
            fabric = new RectangleFabric();
        }

        private void Square_Click(object sender, EventArgs e)
        {
            _action = "drag";
            fabric = new SquareFabric();
        }

        private void Line_Click(object sender, EventArgs e)
        {
            _action = "drag";
            fabric = new LineFabric();
        }

        private void Triangel_Click(object sender, EventArgs e)
        {
            _action = "drag";
            fabric = new TriangleFabric();
        }

        private void Curve_Click(object sender, EventArgs e)
        {
            // shape = new CurveShape();
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            pen.Width = hScrollBar1.Value;
        }

        private void Ellipse_Click(object sender, EventArgs e)
        {
            _action = "drag";
            fabric = new EllipseFabric();
        }

        private void BrokenLine_Click(object sender, EventArgs e)
        {
            _action = "polygon";
        }

        private void Polygon_Click_1(object sender, EventArgs e)
        {
            _action = "Polygon";
            fabric = new PolygonFabric();
        }
        private void RegularPolygon_Click(object sender, EventArgs e)
        {
            _action = "drag";
            fabric = new RegularPolygonFabric(NumberOfVertices);
        }

        private void numberOfVertices_ValueChanged(object sender, EventArgs e)
        {
            NumberOfVertices = Convert.ToInt32(numberOfVertices.Value);
            fabric = new RegularPolygonFabric(NumberOfVertices);
        }

        private void TriangleThreePoints_Click(object sender, EventArgs e)
        {
            _action = "Triangle";
            triangleThreePoints = new TriangleThreePoints();// создаем новый экземпляр класса
        }

        private void Color_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            pen.Color = colorDialog1.Color;
        }


        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (_action == "Polygon")
            {
                graphics = Graphics.FromImage(mainBitmap);
                graphics.DrawLine(pen, polygon.Vertices[polygon.NumberOfVertices - 1], e.Location);
                graphics.DrawLine(pen, polygon.Vertices[0], e.Location);
                polygon.NumberOfVertices = 0;
                polygon.Vertices.Clear();
                pictureBox1.Image = mainBitmap;
            }

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

        private double GetRotationAngle(Point center, Point start, Point end)
        {
            Point a = Delta(start, center);
            Point b = Delta(end, center);
            return GetAngle(a, b);
        }

        private double GetAngle(Point a, Point b) // a, b - vectors
        {
            return Math.Acos((a.X * b.X + a.Y * b.Y) / GetLength(a) / GetLength(b));
        }
        private double GetLength(Point vector) 
        {
            return Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
        }

        private Point Delta(Point start, Point end)
        {
            return new Point(end.X - start.X, end.Y - start.Y);
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
                if(shape!=null)
                    shape.Paint(mainBitmap);
            }
            
        }
    }
}

