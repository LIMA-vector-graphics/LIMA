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
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            mD = false;
            mainBitmap = tmpBitmap;
        }

        private void Rectangle_Click(object sender, EventArgs e)
        {
            shape = new RectangleShape();
        }

        private void Square_Click(object sender, EventArgs e)
        {
            shape = new SquareShape();
        }

        private void Line_Click(object sender, EventArgs e)
        {
            shape = new LineShape();
        }

        private void Triangel_Click(object sender, EventArgs e)
        {
            shape = new TriangleShape();
        }

        private void Curve_Click(object sender, EventArgs e)
        {

        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            pen.Width = hScrollBar1.Value;
        }
    }
}
