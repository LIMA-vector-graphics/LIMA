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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pictureBox1.Location = new System.Drawing.Point(123, 55);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(665, 383);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // Rectangle
            // 
            this.Rectangle.Location = new System.Drawing.Point(24, 55);
            this.Rectangle.Name = "Rectangle";
            this.Rectangle.Size = new System.Drawing.Size(93, 45);
            this.Rectangle.TabIndex = 1;
            this.Rectangle.Text = "Rectangle";
            this.Rectangle.UseVisualStyleBackColor = true;
            this.Rectangle.Click += new System.EventHandler(this.Rectangle_Click);
            // 
            // Square
            // 
            this.Square.Location = new System.Drawing.Point(24, 106);
            this.Square.Name = "Square";
            this.Square.Size = new System.Drawing.Size(77, 45);
            this.Square.TabIndex = 2;
            this.Square.Text = "Square";
            this.Square.UseVisualStyleBackColor = true;
            this.Square.Click += new System.EventHandler(this.Square_Click);
            // 
            // Line
            // 
            this.Line.Location = new System.Drawing.Point(24, 157);
            this.Line.Name = "Line";
            this.Line.Size = new System.Drawing.Size(77, 45);
            this.Line.TabIndex = 3;
            this.Line.Text = "Line";
            this.Line.UseVisualStyleBackColor = true;
            this.Line.Click += new System.EventHandler(this.Line_Click);
            // 
            // Triangel
            // 
            this.Triangel.Location = new System.Drawing.Point(24, 208);
            this.Triangel.Name = "Triangel";
            this.Triangel.Size = new System.Drawing.Size(77, 45);
            this.Triangel.TabIndex = 4;
            this.Triangel.Text = "Triangel";
            this.Triangel.UseVisualStyleBackColor = true;
            this.Triangel.Click += new System.EventHandler(this.Triangel_Click);
            // 
            // Curve
            // 
            this.Curve.Location = new System.Drawing.Point(24, 259);
            this.Curve.Name = "Curve";
            this.Curve.Size = new System.Drawing.Size(77, 45);
            this.Curve.TabIndex = 5;
            this.Curve.Text = "Curve";
            this.Curve.UseVisualStyleBackColor = true;
            this.Curve.Click += new System.EventHandler(this.Curve_Click);
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.LargeChange = 1;
            this.hScrollBar1.Location = new System.Drawing.Point(349, 4);
            this.hScrollBar1.Maximum = 10;
            this.hScrollBar1.Minimum = 1;
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(206, 48);
            this.hScrollBar1.TabIndex = 6;
            this.hScrollBar1.Value = 1;
            this.hScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar1_Scroll);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.hScrollBar1);
            this.Controls.Add(this.Curve);
            this.Controls.Add(this.Triangel);
            this.Controls.Add(this.Line);
            this.Controls.Add(this.Square);
            this.Controls.Add(this.Rectangle);
            this.Controls.Add(this.pictureBox1);
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
    }
}

