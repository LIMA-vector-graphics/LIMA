using LimaVector.Factories;
using LimaVector.Shape;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;


namespace LimaVector
{
    public partial class Form1 : Form
    {
        Canvas canvas;
        Pen pen;
        PointF point;
        bool mD;
        int NumberOfVertices;
        List<AShape> shapes;
        string _action = "";
        AShape currentShape;
        IFactory factory;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            shapes = new List<AShape>();
            canvas = new Canvas(pictureBox1.Width, pictureBox1.Height);
            pen = new Pen(System.Drawing.Color.Black, 1);
            numberOfVertices.Value = 5;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mD && currentShape != null)
            {
                PointF delta;
                switch (_action)
                {
                    case "paint":
                        if (currentShape is ADragShape)
                        {
                            canvas.Duplicate();
                            currentShape.UpdateVertices(point, e.Location);
                        }
                        if (currentShape is TriangleThreePoints)
                        {
                            canvas.Duplicate();
                            currentShape.UpdateVertices(e.Location);
                        }
                        if (currentShape is PolygonShape)
                        {

                        }
                        if (currentShape is CurveShape)
                        {
                            currentShape.UpdateVertices(e.Location);
                        }
                        break;

                    case "rotate":
                        DisplayAll();
                        double phi = currentShape.GravityCenter.GetRotationAngle(point, e.Location);
                        canvas.Duplicate();
                        currentShape.Rotate(phi);
                        point = e.Location;
                        break;
                    case "move":
                        DisplayAll();
                        canvas.Duplicate();
                        delta = point.Delta(e.Location);
                        currentShape.Move(delta);
                        point = e.Location;
                        break;
                    case "resize":
                        DisplayAll();
                        canvas.Duplicate();
                        float alpha = currentShape.GravityCenter.GetAlpha(point, e.Location);
                        currentShape.Resize(alpha);
                        point = e.Location;
                        break;
                    case "select":
                        DisplayAll();
                        canvas.Duplicate();
                        delta = point.Delta(e.Location);

                        if (currentShape.isVerticeSelected)
                        {
                            currentShape.MoveVertice(delta);
                        }
                        else
                        {
                            if (currentShape.isEdgeSelected)
                            {
                                currentShape.MoveEdge(delta);
                            }
                        }

                        point = e.Location;
                        break;
                }
                Display();
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            point = e.Location;
            mD = true;

            if (_action == "paint")

            {
                if (!(currentShape is TriangleThreePoints) || !(factory is TriangleThreePointsFactory) ||
                    ((currentShape is TriangleThreePoints) && currentShape.NumberOfVertices == 3))                     
                {
                    currentShape = factory.CreateShape();
                    currentShape.Color = pen.Color;
                    currentShape.PenWidth = (int)pen.Width;
                }
                if (currentShape is TriangleThreePoints)
                {
                    ((TriangleThreePoints)currentShape).AddVertices(e.Location);
                }
                if (currentShape is CurveShape)
                {
                    currentShape.UpdateVertices(e.Location);
                }

            }

            if (_action == "rotate" || _action == "move" || _action == "resize")
            {
                Selector selector = new Selector(shapes);
                currentShape = selector.Select(e.Location);
                shapes.Remove(currentShape);
            }
            if (_action == "select")
            {
                Selector selector = new Selector(shapes);
                currentShape = selector.SelectVertice(e.Location);
                if (currentShape == null)
                {
                    currentShape = selector.Select(e.Location);
                }
                shapes.Remove(currentShape);
            }

        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (_action == "paint" || _action == "rotate" || _action == "move" ||
                                            _action == "resize" || _action == "select")
            {

                mD = false;

                if (currentShape is TriangleThreePoints)
                {
                    if(currentShape.NumberOfVertices == 2)
                    {
                        ((TriangleThreePoints)currentShape).AddVertices(e.Location);
                    }
                    if(currentShape.NumberOfVertices == 3)
                    {
                        canvas.Update();
                        shapes.Add(currentShape);
                    }
                }
                else
                {
                    canvas.Update();
                    shapes.Add(currentShape);
                }
            }
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (_action == "Polygon")
            {

            }
        }

        private void Rectangle_Click(object sender, EventArgs e)
        {
            _action = "paint";
            factory = new RectangleFactory();
        }

        private void Square_Click(object sender, EventArgs e)
        {
            _action = "paint";
            factory = new SquareFactory();
        }

        private void Line_Click(object sender, EventArgs e)
        {
            _action = "paint";
            factory = new LineFactory();
        }

        private void Triangel_Click(object sender, EventArgs e)
        {
            _action = "paint";
            factory = new TriangleFactory();
        }

        private void Curve_Click(object sender, EventArgs e)
        {
            _action = "paint";
            factory = new CurveFactory();
            currentShape = factory.CreateShape();
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            pen.Width = hScrollBar1.Value;
        }

        private void Ellipse_Click(object sender, EventArgs e)
        {
            _action = "paint";
            factory = new EllipseFactory();
        }

        private void Polygon__Click(object sender, EventArgs e)
        {
            _action = "polygon";
            factory = new PolygonFactory();
        }

        private void RegularPolygon_Click(object sender, EventArgs e)
        {
            _action = "paint";
            factory = new RegularPolygonFactory(NumberOfVertices);
        }

        private void numberOfVertices_ValueChanged(object sender, EventArgs e)
        {
            NumberOfVertices = Convert.ToInt32(numberOfVertices.Value);
            factory = new RegularPolygonFactory(NumberOfVertices);
        }

        private void TriangleThreePoints_Click(object sender, EventArgs e)
        {
            _action = "paint";
            factory = new TriangleThreePointsFactory();
        }

        private void Color_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            pen.Color = colorDialog1.Color;
        }

        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (_action == "polygon")
            {

            }

        }

        private void ClearAll_Click(object sender, EventArgs e)
        {
            canvas.Clear();
            shapes.Clear();
            pictureBox1.Image = canvas.Bitmap;
        }

        private void Rotate_Click(object sender, EventArgs e)
        {
            _action = "rotate";
        }

        private void Move_Click(object sender, EventArgs e)
        {
            _action = "move";
        }

        private void Resize_Click(object sender, EventArgs e)
        {
            _action = "resize";
        }

        private void SelectVertice_Click(object sender, EventArgs e)
        {
            _action = "select";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        public void DisplayAll()
        {
            canvas.Update();
            canvas.Clear();

            foreach (AShape shape in shapes)
            {
                if (shape != null)
                {
                    shape.Paint(canvas);
                    pictureBox1.Image = canvas.Bitmap;
                }
            }

        }

        private void Display()
        {
            if (currentShape != null)
            {
                currentShape.Paint(canvas);
            }
            pictureBox1.Image = canvas.Bitmap;
            GC.Collect();
        }

        private void Fill_Click(object sender, EventArgs e)
        {
            currentShape.Fill(pen.Color);
            Display();
        }
    }
}
