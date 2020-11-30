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
        bool mD;
        string mode;
        Point start;

        List<Point> _clickedPoints = new List<Point>(); // _приватные переменные (поля), список точек для треугольника по трем точкам
        string _action = ""; //// поле в котором будет храниться текущее действие

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

            //shape = new RectangleShape();


        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mD)
            {
                tmpBitmap = (Bitmap)mainBitmap.Clone(); //создаем копии битмапа пока рисуем
                graphics = Graphics.FromImage(tmpBitmap); //рисуем на копии главного битмапа

                //graphics.Clear(Color.White); // очищаем имейджБокс от фигур создающихся по пути

                graphics.DrawPolygon(pen, shape.GetPoints(point, e.Location));
                pictureBox1.Image = tmpBitmap;
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
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            mD = false;
            mainBitmap = tmpBitmap;
        }

        private void Rectangle_Click(object sender, EventArgs e)
        {
            _action = "Rectangle"; // выбираем режим
            shape = new RectangleShape();
        }

        private void Square_Click(object sender, EventArgs e)
        {
            _action = "Square";
            shape = new SquareShape();
        }

        private void Line_Click(object sender, EventArgs e)
        {
            _action = "Line";
            shape = new LineShape();
        }

        private void Triangel_Click(object sender, EventArgs e)
        {
            _action = "RightTriangle";
            shape = new TriangleShape();
        }

        private void Curve_Click(object sender, EventArgs e)
        {

        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            pen.Width = hScrollBar1.Value;
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
