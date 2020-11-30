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
        string mode;
        int NumberOfVertices;


        //RectangleFigure reactangle;

        IShape shape;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            mainBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            pen = new Pen(Color.Red, 5);
            pictureBox1.Image = mainBitmap;

            shape = new RectangleShape();

            startEntered = false;
            numberOfVertices.Value = 5;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mD && mode == "drag")
            {
                tmpBitmap = (Bitmap)mainBitmap.Clone(); //создаем копии битмапа пока рисуем
                graphics = Graphics.FromImage(tmpBitmap); //рисуем на копии главного битмапа

                //graphics.Clear(Color.White); // очищаем имейджБокс от фигур создающихся по пути

                graphics.DrawPolygon(pen, shape.GetPoints(point, e.Location));
                pictureBox1.Image = tmpBitmap;
                GC.Collect();
            }

            //
            //if (mode == "polygon")
            //{
            //    tmpBitmap = (Bitmap)mainBitmap.Clone(); //создаем копии битмапа пока рисуем
            //    graphics = Graphics.FromImage(tmpBitmap); //рисуем на копии главного битмапа

            //    //graphics.Clear(Color.White); // очищаем имейджБокс от фигур создающихся по пути

            //    graphics.DrawLine(pen, next, e.Location);
            //    graphics.DrawLine(pen, e.Location, start);
            //    pictureBox1.Image = tmpBitmap;
            //    GC.Collect();
            //}
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (mode == "drag")
            {
                point = e.Location;
                mD = true;
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (mode == "drag")
            {
                mD = false;
                mainBitmap = tmpBitmap;
            }
        }

        private void Rectangle_Click(object sender, EventArgs e)
        {
            mode = "drag";
            shape = new RectangleShape();
        }

        private void Square_Click(object sender, EventArgs e)
        {
            mode = "drag";
            shape = new SquareShape();
        }

        private void Line_Click(object sender, EventArgs e)
        {
            mode = "drag";
            shape = new LineShape();
        }

        private void Triangel_Click(object sender, EventArgs e)
        {
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
            mode = "drag";
            shape = new EllipseShape();
        }

        private void Polygon_Click(object sender, EventArgs e)
        {
            //shape = new PolygonShape();
            mode = "polygon";
        }
    


        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if(mode == "polygon")
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
            shape = new RegularPolygonShape(NumberOfVertices);
        }

        private void numberOfVertices_ValueChanged(object sender, EventArgs e)
        {
            NumberOfVertices = Convert.ToInt32(numberOfVertices.Value);
            shape = new RegularPolygonShape(NumberOfVertices);
        }
    }

}
