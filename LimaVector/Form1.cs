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
        int counter;

        bool mD;
      
        int NumberOfVertices;
        PolygonShape polygon;
        TriangleThreePoints triangleThreePoints; //создали объект класса
       

        List<Point> _clickedPoints = new List<Point>(); // _приватные переменные (поля), список точек для треугольника по трем точкам
        string _action = ""; //// поле в котором будет храниться текущее действие

        Painter painter;
        IShape shape;
        //IThreePointShape shapeThreePoints; // у интефейса создали, обявили поле типа интерфейса

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
            if (mD && _action == "Triangle")
            {
                if (triangleThreePoints.NumberOfVertices != 0)
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
            }
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            point = e.Location;
            mD = true;

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
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (_action == "drag")
            {
                mD = false;
                mainBitmap = tmpBitmap;
            }

            if (_action == "Triangle")
            {

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

        private void BrokenLine_Click(object sender, EventArgs e)
        {
            _action = "polygon";
        }
    


        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if(_action == "Polygon")
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
                    graphics.DrawLine(pen, polygon.Vertices[polygon.NumberOfVertices-1], e.Location);
                    polygon.NumberOfVertices++;
                    polygon.Vertices.Add(e.Location);//записали в массив новую точку 
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
            triangleThreePoints = new TriangleThreePoints();// создаем новый экземпляр класса
        }

        private void Color_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            pen.Color = colorDialog1.Color;
        }

        private void Polygon_Click_1(object sender, EventArgs e)
        {
            _action = "Polygon";
            polygon = new PolygonShape();

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
        }
    }


}
