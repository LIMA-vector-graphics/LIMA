using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LimaVector.Shape;


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

        List<Point> _clickedPoints = new List<Point>(); // _приватные переменные (поля), список точек для треугольника по трем точкам
        string _action = ""; //// поле в котором будет храниться текущее действие

        Painter painter;
        IShape shape;
        IThreePointShape shapeThreePoints;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            mainBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            
            pen = new Pen(System.Drawing.Color.Red, 5);
            pictureBox1.Image = mainBitmap;

            shape = new RectangleShape();

            startEntered = false;
            numberOfVertices.Value = 5;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mD && _action == "drag")
            {
                tmpBitmap = (Bitmap) mainBitmap.Clone();
                painter = new Painter(shape, pen, tmpBitmap);
                pictureBox1.Image = painter.Paint(point, e.Location);
                GC.Collect();
            }
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            point = e.Location;
            mD = true;

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
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (_action == "drag")
            {
                mD = false;
                mainBitmap = tmpBitmap;
            }
        }

        private void Rectangle_Click(object sender, EventArgs e)
        {
            _action = "drag";
            shape = new RectangleShape();
        }

        private void Square_Click(object sender, EventArgs e)
        {
            _action = "drag";
            shape = new SquareShape();
        }

        private void Line_Click(object sender, EventArgs e)
        {
            _action = "drag";
            shape = new LineShape();
        }

        private void Triangel_Click(object sender, EventArgs e)
        {
            _action = "drag";
            shape = new TriangleShape();
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
            shape = new EllipseShape();
        }

        private void Polygon_Click(object sender, EventArgs e)
        {
            //shape = new PolygonShape();
            _action = "polygon";
        }
    


        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if(_action == "polygon")
            {
                if (!startEntered)
                {
                    start = e.Location;
                    startEntered = true;
                    graphics = Graphics.FromImage(mainBitmap);
                    next = start;
                }
                else
                {
                    graphics.DrawLine(pen, next, e.Location);
                    next = e.Location;
                    pictureBox1.Image = mainBitmap;
                }
            }
        }
        private void RegularPolygon_Click(object sender, EventArgs e)
        {
            _action = "drag";
            shape = new RegularPolygonShape(NumberOfVertices);
        }

        private void numberOfVertices_ValueChanged(object sender, EventArgs e)
        {
            NumberOfVertices = Convert.ToInt32(numberOfVertices.Value);
            shape = new RegularPolygonShape(NumberOfVertices);
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
    }


}
