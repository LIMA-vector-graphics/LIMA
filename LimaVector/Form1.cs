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
        bool mD;
        bool startEntered;
        int NumberOfVertices;
        PolygonShape polygon;
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
            
            pen = new Pen(System.Drawing.Color.Black, 16);
            pictureBox1.Image = mainBitmap;

            startEntered = false;
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

                _clickedPoints.Add(point); //добавлеем точку в лист (массив) , текущая точка которую кликнули
                if (_clickedPoints.Count == 3) // счетчик точек
                {
                    // draw triangle here
                    Point[] pts = shapeThreePoints.GetPoints(_clickedPoints[0], _clickedPoints[1], _clickedPoints[2]); // вызываем метод для трех точек которые были нажаты

                    tmpBitmap = (Bitmap)mainBitmap.Clone(); //создаем копии битмапа пока рисуем
                    graphics = Graphics.FromImage(tmpBitmap); //рисуем на копии главного битмапа
                    graphics.DrawPolygon(pen, pts);// соединяем точки
                    pictureBox1.Image = tmpBitmap;
                    GC.Collect();
                    _clickedPoints.Clear();// чистим координаты точек
                }
                else // рисуем точки вершины треугольника до тех пор пока точек не станет 3
                {
                    tmpBitmap = (Bitmap)mainBitmap.Clone(); //создаем копии битмапа пока рисуем
                    graphics = Graphics.FromImage(tmpBitmap); //рисуем на копии главного битмапа
                    graphics.DrawPolygon(pen, new Point[] { e.Location, new Point(e.Location.X - 1, e.Location.Y - 1) }); //передали точку и координаты точки -1, для того чтобы ее было видно ,
                    pictureBox1.Image = tmpBitmap;
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

        private void Polygon_Click(object sender, EventArgs e)
        {
            //shape = new PolygonShape();
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
            shapeThreePoints = new TriangleThreePoints();
        }

        private void Color_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            pen.Color = colorDialog1.Color;
        }


        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //tmpBitmap = (Bitmap)mainBitmap.Clone();
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

        private void Fractal_Click(object sender, EventArgs e)
        {
            BuildFractal(new Point(600, 400), 200);
        }
        private void BuildFractal(Point start, int radius, string mode="all", double alpha = 0.63, double penWidth)
        {
            if (radius > 1)
            {
                pen.Width = penWidth;
                Point upLeft = new Point(start.X - (int)(radius * Math.Sqrt(3) / 2), start.Y - radius / 2);
                Point upRight = new Point(start.X + (int)(radius * Math.Sqrt(3) / 2), start.Y - radius / 2);
                Point down = new Point(start.X, start.Y + radius);
                Point downLeft = GetSimmetric(upRight, start);
                Point downRight = GetSimmetric(upLeft, start);
                Point up = GetSimmetric(down, start);
                graphics = Graphics.FromImage(mainBitmap);
                switch(mode)
                {
                    case "all":
                        graphics.DrawLine(pen, start, down);
                        pictureBox1.Image = mainBitmap;

                        graphics.DrawLine(pen, start, upLeft);
                        pictureBox1.Image = mainBitmap;
                        BuildFractal(upLeft, (int)(radius * alpha), "upLeft", penWidth * alpha);

                        graphics.DrawLine(pen, start, upRight);
                        pictureBox1.Image = mainBitmap;
                        BuildFractal(upRight, (int)(radius * alpha), "upRight", penWidth * alpha);
                        break;
                    case "upLeft":
                        graphics.DrawLine(pen, start, up);
                        pictureBox1.Image = mainBitmap;
                        BuildFractal(up, (int)(radius * alpha), "up", penWidth * alpha);

                        graphics.DrawLine(pen, start, downLeft);
                        pictureBox1.Image = mainBitmap;
                        BuildFractal(downLeft, (int)(radius * alpha), "downLeft", penWidth * alpha);
                        break;
                    case "upRight":
                        graphics.DrawLine(pen, start, up);
                        pictureBox1.Image = mainBitmap;
                        BuildFractal(up, (int)(radius * alpha), "up", penWidth * alpha);

                        graphics.DrawLine(pen, start, downRight);
                        pictureBox1.Image = mainBitmap;
                        BuildFractal(downRight, (int)(radius * alpha), "downRight", penWidth * alpha);
                        break;
                    case "up":
                        graphics.DrawLine(pen, start, upLeft);
                        pictureBox1.Image = mainBitmap;
                        BuildFractal(upLeft, (int)(radius * alpha), "upLeft", penWidth * alpha);

                        graphics.DrawLine(pen, start, upRight);
                        pictureBox1.Image = mainBitmap;
                        BuildFractal(upRight, (int)(radius * alpha), "upRight", penWidth * alpha);
                        break;
                    case "down":
                        graphics.DrawLine(pen, start, downLeft);
                        pictureBox1.Image = mainBitmap;
                        BuildFractal(downLeft, (int)(radius * alpha), "downLeft", penWidth * alpha);

                        graphics.DrawLine(pen, start, downRight);
                        pictureBox1.Image = mainBitmap;
                        BuildFractal(downRight, (int)(radius * alpha), "downRight", penWidth * alpha);
                        break;
                    case "downLeft":
                        graphics.DrawLine(pen, start, down);
                        pictureBox1.Image = mainBitmap;
                        BuildFractal(down, (int)(radius * alpha), "down", penWidth * alpha);

                        graphics.DrawLine(pen, start, upLeft);
                        pictureBox1.Image = mainBitmap;
                        BuildFractal(upLeft, (int)(radius * alpha), "upLeft", penWidth * alpha);
                        break;
                    case "downRight":
                        graphics.DrawLine(pen, start, down);
                        pictureBox1.Image = mainBitmap;
                        BuildFractal(down, (int)(radius * alpha), "down", penWidth * alpha);

                        graphics.DrawLine(pen, start, upRight);
                        pictureBox1.Image = mainBitmap;
                        BuildFractal(upRight, radius / 2, "upRight", penWidth * alpha);
                        break;
                    default:
                        break;
                }
                pen.Width /= 2;
            }
        }

        private Point GetSimmetric(Point point, Point center)
        {
            return new Point(2 * center.X - point.X, 2 * center.Y - point.Y);
        }
    }
}
