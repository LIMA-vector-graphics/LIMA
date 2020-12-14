﻿namespace LimaVector
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.numberOfVertices = new System.Windows.Forms.NumericUpDown();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.Fill = new System.Windows.Forms.Button();
            this.SelectVertice = new System.Windows.Forms.Button();
            this.Resize = new System.Windows.Forms.Button();
            this.Move = new System.Windows.Forms.Button();
            this.Rotate = new System.Windows.Forms.Button();
            this.ClearAll = new System.Windows.Forms.Button();
            this.RegularPolygon = new System.Windows.Forms.Button();
            this.Ellipse = new System.Windows.Forms.Button();
            this.TriangleThreePoints = new System.Windows.Forms.Button();
            this.Color = new System.Windows.Forms.Button();
            this.Curve = new System.Windows.Forms.Button();
            this.Triangel = new System.Windows.Forms.Button();
            this.Line = new System.Windows.Forms.Button();
            this.Square = new System.Windows.Forms.Button();
            this.Rectangle = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfVertices)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.LargeChange = 1;
            this.hScrollBar1.Location = new System.Drawing.Point(108, 26);
            this.hScrollBar1.Maximum = 20;
            this.hScrollBar1.Minimum = 1;
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(154, 23);
            this.hScrollBar1.TabIndex = 6;
            this.hScrollBar1.Value = 1;
            this.hScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar1_Scroll);
            // 
            // numberOfVertices
            // 
            this.numberOfVertices.Location = new System.Drawing.Point(21, 394);
            this.numberOfVertices.Name = "numberOfVertices";
            this.numberOfVertices.Size = new System.Drawing.Size(58, 20);
            this.numberOfVertices.TabIndex = 10;
            this.numberOfVertices.ValueChanged += new System.EventHandler(this.numberOfVertices_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(483, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Resize";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(416, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Rotate";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(350, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Move";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(634, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Fill";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(558, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "Select";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(678, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Clear All";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(286, 61);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(31, 13);
            this.label9.TabIndex = 29;
            this.label9.Text = "Color";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(153, 61);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(58, 13);
            this.label10.TabIndex = 30;
            this.label10.Text = "Line Width";
            // 
            // Fill
            // 
            this.Fill.Image = global::LimaVector.Properties.Resources.fill7;
            this.Fill.Location = new System.Drawing.Point(612, 10);
            this.Fill.Name = "Fill";
            this.Fill.Size = new System.Drawing.Size(60, 50);
            this.Fill.TabIndex = 18;
            this.Fill.UseVisualStyleBackColor = true;
            this.Fill.Click += new System.EventHandler(this.Fill_Click);
            // 
            // SelectVertice
            // 
            this.SelectVertice.Image = global::LimaVector.Properties.Resources.SelectVer;
            this.SelectVertice.Location = new System.Drawing.Point(546, 10);
            this.SelectVertice.Name = "SelectVertice";
            this.SelectVertice.Size = new System.Drawing.Size(60, 50);
            this.SelectVertice.TabIndex = 16;
            this.SelectVertice.UseVisualStyleBackColor = true;
            this.SelectVertice.Click += new System.EventHandler(this.SelectVertice_Click);
            // 
            // Resize
            // 
            this.Resize.Image = global::LimaVector.Properties.Resources.resize71;
            this.Resize.Location = new System.Drawing.Point(480, 10);
            this.Resize.Name = "Resize";
            this.Resize.Size = new System.Drawing.Size(60, 50);
            this.Resize.TabIndex = 15;
            this.Resize.UseVisualStyleBackColor = true;
            this.Resize.Click += new System.EventHandler(this.Resize_Click);
            // 
            // Move
            // 
            this.Move.Image = global::LimaVector.Properties.Resources.move7;
            this.Move.Location = new System.Drawing.Point(348, 10);
            this.Move.Name = "Move";
            this.Move.Size = new System.Drawing.Size(60, 50);
            this.Move.TabIndex = 14;
            this.Move.UseVisualStyleBackColor = true;
            this.Move.Click += new System.EventHandler(this.Move_Click);
            // 
            // Rotate
            // 
            this.Rotate.Image = global::LimaVector.Properties.Resources.rotate7;
            this.Rotate.Location = new System.Drawing.Point(414, 10);
            this.Rotate.Name = "Rotate";
            this.Rotate.Size = new System.Drawing.Size(60, 50);
            this.Rotate.TabIndex = 13;
            this.Rotate.UseVisualStyleBackColor = true;
            this.Rotate.Click += new System.EventHandler(this.Rotate_Click);
            // 
            // ClearAll
            // 
            this.ClearAll.Image = global::LimaVector.Properties.Resources.clear;
            this.ClearAll.Location = new System.Drawing.Point(677, 10);
            this.ClearAll.Margin = new System.Windows.Forms.Padding(2);
            this.ClearAll.Name = "ClearAll";
            this.ClearAll.Size = new System.Drawing.Size(60, 50);
            this.ClearAll.TabIndex = 12;
            this.ClearAll.UseMnemonic = false;
            this.ClearAll.UseVisualStyleBackColor = true;
            this.ClearAll.Click += new System.EventHandler(this.ClearAll_Click);
            // 
            // RegularPolygon
            // 
            this.RegularPolygon.Image = global::LimaVector.Properties.Resources.poly;
            this.RegularPolygon.Location = new System.Drawing.Point(21, 337);
            this.RegularPolygon.Margin = new System.Windows.Forms.Padding(4);
            this.RegularPolygon.Name = "RegularPolygon";
            this.RegularPolygon.Size = new System.Drawing.Size(60, 50);
            this.RegularPolygon.TabIndex = 9;
            this.RegularPolygon.UseVisualStyleBackColor = true;
            this.RegularPolygon.Click += new System.EventHandler(this.RegularPolygon_Click);
            // 
            // Ellipse
            // 
            this.Ellipse.Image = global::LimaVector.Properties.Resources.ellips;
            this.Ellipse.Location = new System.Drawing.Point(21, 227);
            this.Ellipse.Name = "Ellipse";
            this.Ellipse.Size = new System.Drawing.Size(60, 50);
            this.Ellipse.TabIndex = 7;
            this.Ellipse.UseVisualStyleBackColor = true;
            this.Ellipse.Click += new System.EventHandler(this.Ellipse_Click);
            // 
            // TriangleThreePoints
            // 
            this.TriangleThreePoints.Image = global::LimaVector.Properties.Resources.trian1;
            this.TriangleThreePoints.Location = new System.Drawing.Point(21, 422);
            this.TriangleThreePoints.Margin = new System.Windows.Forms.Padding(2);
            this.TriangleThreePoints.Name = "TriangleThreePoints";
            this.TriangleThreePoints.Size = new System.Drawing.Size(60, 50);
            this.TriangleThreePoints.TabIndex = 8;
            this.TriangleThreePoints.UseVisualStyleBackColor = true;
            this.TriangleThreePoints.Click += new System.EventHandler(this.TriangleThreePoints_Click);
            // 
            // Color
            // 
            this.Color.Image = global::LimaVector.Properties.Resources.color_1;
            this.Color.Location = new System.Drawing.Point(283, 10);
            this.Color.Margin = new System.Windows.Forms.Padding(2);
            this.Color.Name = "Color";
            this.Color.Size = new System.Drawing.Size(60, 50);
            this.Color.TabIndex = 7;
            this.Color.UseVisualStyleBackColor = true;
            this.Color.Click += new System.EventHandler(this.Color_Click);
            // 
            // Curve
            // 
            this.Curve.Image = global::LimaVector.Properties.Resources.pen71;
            this.Curve.Location = new System.Drawing.Point(21, 11);
            this.Curve.Margin = new System.Windows.Forms.Padding(2);
            this.Curve.Name = "Curve";
            this.Curve.Size = new System.Drawing.Size(60, 50);
            this.Curve.TabIndex = 5;
            this.Curve.UseVisualStyleBackColor = true;
            this.Curve.Click += new System.EventHandler(this.Curve_Click);
            // 
            // Triangel
            // 
            this.Triangel.Image = global::LimaVector.Properties.Resources.trian;
            this.Triangel.Location = new System.Drawing.Point(21, 282);
            this.Triangel.Margin = new System.Windows.Forms.Padding(2);
            this.Triangel.Name = "Triangel";
            this.Triangel.Size = new System.Drawing.Size(60, 50);
            this.Triangel.TabIndex = 4;
            this.Triangel.UseVisualStyleBackColor = true;
            this.Triangel.Click += new System.EventHandler(this.Triangel_Click);
            // 
            // Line
            // 
            this.Line.Image = global::LimaVector.Properties.Resources.line;
            this.Line.Location = new System.Drawing.Point(21, 65);
            this.Line.Margin = new System.Windows.Forms.Padding(2);
            this.Line.Name = "Line";
            this.Line.Size = new System.Drawing.Size(60, 50);
            this.Line.TabIndex = 3;
            this.Line.UseVisualStyleBackColor = true;
            this.Line.Click += new System.EventHandler(this.Line_Click);
            // 
            // Square
            // 
            this.Square.Image = global::LimaVector.Properties.Resources.Square12;
            this.Square.Location = new System.Drawing.Point(21, 173);
            this.Square.Margin = new System.Windows.Forms.Padding(2);
            this.Square.Name = "Square";
            this.Square.Size = new System.Drawing.Size(60, 50);
            this.Square.TabIndex = 2;
            this.Square.UseVisualStyleBackColor = true;
            this.Square.Click += new System.EventHandler(this.Square_Click);
            // 
            // Rectangle
            // 
            this.Rectangle.Image = global::LimaVector.Properties.Resources.Rect1;
            this.Rectangle.Location = new System.Drawing.Point(21, 119);
            this.Rectangle.Margin = new System.Windows.Forms.Padding(2);
            this.Rectangle.Name = "Rectangle";
            this.Rectangle.Size = new System.Drawing.Size(60, 50);
            this.Rectangle.TabIndex = 1;
            this.Rectangle.UseVisualStyleBackColor = true;
            this.Rectangle.Click += new System.EventHandler(this.Rectangle_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pictureBox1.BackgroundImage = global::LimaVector.Properties.Resources.razlinovka;
            this.pictureBox1.Image = global::LimaVector.Properties.Resources.razlinovka;
            this.pictureBox1.Location = new System.Drawing.Point(108, 83);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(880, 450);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            this.pictureBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDoubleClick);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1002, 550);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Fill);
            this.Controls.Add(this.SelectVertice);
            this.Controls.Add(this.Resize);
            this.Controls.Add(this.Move);
            this.Controls.Add(this.Rotate);
            this.Controls.Add(this.ClearAll);
            this.Controls.Add(this.numberOfVertices);
            this.Controls.Add(this.RegularPolygon);
            this.Controls.Add(this.Ellipse);
            this.Controls.Add(this.TriangleThreePoints);
            this.Controls.Add(this.Color);
            this.Controls.Add(this.hScrollBar1);
            this.Controls.Add(this.Curve);
            this.Controls.Add(this.Triangel);
            this.Controls.Add(this.Line);
            this.Controls.Add(this.Square);
            this.Controls.Add(this.Rectangle);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "MagicDraw";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numberOfVertices)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button Rectangle;
        private System.Windows.Forms.Button Square;
        private System.Windows.Forms.Button Line;
        private System.Windows.Forms.Button Triangel;
        private System.Windows.Forms.Button Curve;
        private System.Windows.Forms.HScrollBar hScrollBar1;
        private System.Windows.Forms.Button Ellipse;
        private System.Windows.Forms.Button RegularPolygon;
        private System.Windows.Forms.NumericUpDown numberOfVertices;
        private System.Windows.Forms.Button Color;
        private System.Windows.Forms.Button TriangleThreePoints;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button ClearAll;
        private System.Windows.Forms.Button Rotate;
        private System.Windows.Forms.Button Move;
        private System.Windows.Forms.Button Resize;
        private System.Windows.Forms.Button SelectVertice;
        private System.Windows.Forms.Button Fill;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
    }
}

