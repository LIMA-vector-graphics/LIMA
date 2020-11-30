namespace LimaVector
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Rectangle = new System.Windows.Forms.Button();
            this.Square = new System.Windows.Forms.Button();
            this.Line = new System.Windows.Forms.Button();
            this.Triangel = new System.Windows.Forms.Button();
            this.Curve = new System.Windows.Forms.Button();
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.Color = new System.Windows.Forms.Button();
            this.TriangleThreePoints = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pictureBox1.Location = new System.Drawing.Point(136, 86);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(781, 342);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // Rectangle
            // 
            this.Rectangle.Location = new System.Drawing.Point(18, 45);
            this.Rectangle.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Rectangle.Name = "Rectangle";
            this.Rectangle.Size = new System.Drawing.Size(70, 37);
            this.Rectangle.TabIndex = 1;
            this.Rectangle.Text = "Rectangle";
            this.Rectangle.UseVisualStyleBackColor = true;
            this.Rectangle.Click += new System.EventHandler(this.Rectangle_Click);
            // 
            // Square
            // 
            this.Square.Location = new System.Drawing.Point(18, 86);
            this.Square.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Square.Name = "Square";
            this.Square.Size = new System.Drawing.Size(58, 37);
            this.Square.TabIndex = 2;
            this.Square.Text = "Square";
            this.Square.UseVisualStyleBackColor = true;
            this.Square.Click += new System.EventHandler(this.Square_Click);
            // 
            // Line
            // 
            this.Line.Location = new System.Drawing.Point(18, 128);
            this.Line.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Line.Name = "Line";
            this.Line.Size = new System.Drawing.Size(58, 37);
            this.Line.TabIndex = 3;
            this.Line.Text = "Line";
            this.Line.UseVisualStyleBackColor = true;
            this.Line.Click += new System.EventHandler(this.Line_Click);
            // 
            // Triangel
            // 
            this.Triangel.Location = new System.Drawing.Point(18, 169);
            this.Triangel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Triangel.Name = "Triangel";
            this.Triangel.Size = new System.Drawing.Size(58, 37);
            this.Triangel.TabIndex = 4;
            this.Triangel.Text = "Triangel";
            this.Triangel.UseVisualStyleBackColor = true;
            this.Triangel.Click += new System.EventHandler(this.Triangel_Click);
            // 
            // Curve
            // 
            this.Curve.Location = new System.Drawing.Point(18, 210);
            this.Curve.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Curve.Name = "Curve";
            this.Curve.Size = new System.Drawing.Size(58, 37);
            this.Curve.TabIndex = 5;
            this.Curve.Text = "Curve";
            this.Curve.UseVisualStyleBackColor = true;
            this.Curve.Click += new System.EventHandler(this.Curve_Click);
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.LargeChange = 1;
            this.hScrollBar1.Location = new System.Drawing.Point(680, 25);
            this.hScrollBar1.Maximum = 10;
            this.hScrollBar1.Minimum = 1;
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(154, 48);
            this.hScrollBar1.TabIndex = 6;
            this.hScrollBar1.Value = 1;
            this.hScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar1_Scroll);
            // 
            // Color
            // 
            this.Color.Location = new System.Drawing.Point(136, 25);
            this.Color.Margin = new System.Windows.Forms.Padding(2);
            this.Color.Name = "Color";
            this.Color.Size = new System.Drawing.Size(70, 37);
            this.Color.TabIndex = 7;
            this.Color.Text = "Color";
            this.Color.UseVisualStyleBackColor = true;
            this.Color.Click += new System.EventHandler(this.Color_Click);
            // 
            // TriangleThreePoints
            // 
            this.TriangleThreePoints.Location = new System.Drawing.Point(18, 251);
            this.TriangleThreePoints.Margin = new System.Windows.Forms.Padding(2);
            this.TriangleThreePoints.Name = "TriangleThreePoints";
            this.TriangleThreePoints.Size = new System.Drawing.Size(93, 68);
            this.TriangleThreePoints.TabIndex = 8;
            this.TriangleThreePoints.Text = "TriangleThreePoints";
            this.TriangleThreePoints.UseVisualStyleBackColor = true;
            this.TriangleThreePoints.Click += new System.EventHandler(this.TriangleThreePoints_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 439);
            this.Controls.Add(this.TriangleThreePoints);
            this.Controls.Add(this.Color);
            this.Controls.Add(this.hScrollBar1);
            this.Controls.Add(this.Curve);
            this.Controls.Add(this.Triangel);
            this.Controls.Add(this.Line);
            this.Controls.Add(this.Square);
            this.Controls.Add(this.Rectangle);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button Rectangle;
        private System.Windows.Forms.Button Square;
        private System.Windows.Forms.Button Line;
        private System.Windows.Forms.Button Triangel;
        private System.Windows.Forms.Button Curve;
        private System.Windows.Forms.HScrollBar hScrollBar1;
        private System.Windows.Forms.Button Color;
        private System.Windows.Forms.Button TriangleThreePoints;
        private System.Windows.Forms.ColorDialog colorDialog1;
    }
}

