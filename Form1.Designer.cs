namespace ImageTransformer
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
            this.bwButton = new System.Windows.Forms.Button();
            this.gbButton = new System.Windows.Forms.Button();
            this.gbtSlider = new System.Windows.Forms.NumericUpDown();
            this.imageFrame = new System.Windows.Forms.PictureBox();
            this.openButton = new System.Windows.Forms.Button();
            this.rstButton = new System.Windows.Forms.Button();
            this.gbkSlider = new System.Windows.Forms.NumericUpDown();
            this.seButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gbtSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageFrame)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbkSlider)).BeginInit();
            this.SuspendLayout();
            // 
            // bwButton
            // 
            this.bwButton.Location = new System.Drawing.Point(12, 12);
            this.bwButton.Name = "bwButton";
            this.bwButton.Size = new System.Drawing.Size(97, 23);
            this.bwButton.TabIndex = 0;
            this.bwButton.Text = "Black + White";
            this.bwButton.UseVisualStyleBackColor = true;
            this.bwButton.Click += new System.EventHandler(this.bwButton_Click);
            // 
            // gbButton
            // 
            this.gbButton.Location = new System.Drawing.Point(12, 41);
            this.gbButton.Name = "gbButton";
            this.gbButton.Size = new System.Drawing.Size(97, 23);
            this.gbButton.TabIndex = 1;
            this.gbButton.Text = "Gaussian Blur";
            this.gbButton.UseVisualStyleBackColor = true;
            this.gbButton.Click += new System.EventHandler(this.gbButton_Click);
            // 
            // gbtSlider
            // 
            this.gbtSlider.DecimalPlaces = 2;
            this.gbtSlider.Location = new System.Drawing.Point(115, 44);
            this.gbtSlider.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.gbtSlider.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.gbtSlider.Name = "gbtSlider";
            this.gbtSlider.Size = new System.Drawing.Size(43, 20);
            this.gbtSlider.TabIndex = 2;
            this.gbtSlider.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // imageFrame
            // 
            this.imageFrame.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imageFrame.Location = new System.Drawing.Point(178, 12);
            this.imageFrame.Name = "imageFrame";
            this.imageFrame.Size = new System.Drawing.Size(400, 297);
            this.imageFrame.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imageFrame.TabIndex = 3;
            this.imageFrame.TabStop = false;
            // 
            // openButton
            // 
            this.openButton.Location = new System.Drawing.Point(12, 286);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(75, 23);
            this.openButton.TabIndex = 4;
            this.openButton.Text = "Open Image";
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // rstButton
            // 
            this.rstButton.Location = new System.Drawing.Point(12, 257);
            this.rstButton.Name = "rstButton";
            this.rstButton.Size = new System.Drawing.Size(75, 23);
            this.rstButton.TabIndex = 5;
            this.rstButton.Text = "Reset Image";
            this.rstButton.UseVisualStyleBackColor = true;
            this.rstButton.Click += new System.EventHandler(this.rstButton_Click);
            // 
            // gbkSlider
            // 
            this.gbkSlider.Location = new System.Drawing.Point(115, 68);
            this.gbkSlider.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbkSlider.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.gbkSlider.Name = "gbkSlider";
            this.gbkSlider.Size = new System.Drawing.Size(43, 20);
            this.gbkSlider.TabIndex = 6;
            this.gbkSlider.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // seButton
            // 
            this.seButton.Location = new System.Drawing.Point(13, 70);
            this.seButton.Name = "seButton";
            this.seButton.Size = new System.Drawing.Size(97, 23);
            this.seButton.TabIndex = 7;
            this.seButton.Text = "Sobel Edge";
            this.seButton.UseVisualStyleBackColor = true;
            this.seButton.Click += new System.EventHandler(this.seButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 321);
            this.Controls.Add(this.seButton);
            this.Controls.Add(this.gbkSlider);
            this.Controls.Add(this.rstButton);
            this.Controls.Add(this.openButton);
            this.Controls.Add(this.imageFrame);
            this.Controls.Add(this.gbtSlider);
            this.Controls.Add(this.gbButton);
            this.Controls.Add(this.bwButton);
            this.Name = "Form1";
            this.Text = "Image Transformer";
            ((System.ComponentModel.ISupportInitialize)(this.gbtSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageFrame)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbkSlider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bwButton;
        private System.Windows.Forms.Button gbButton;
        private System.Windows.Forms.NumericUpDown gbtSlider;
        private System.Windows.Forms.PictureBox imageFrame;
        private System.Windows.Forms.Button openButton;
        private System.Windows.Forms.Button rstButton;
        private System.Windows.Forms.NumericUpDown gbkSlider;
        private System.Windows.Forms.Button seButton;
    }
}

