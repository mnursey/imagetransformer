using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace ImageTransformer
{
    public partial class Form1 : Form
    {
        Bitmap image;
        Bitmap original;
        PictureBox p;
        public Form1()
        {
            InitializeComponent();
        }

        static Bitmap RGBtoBitmap(Byte[] rgb, Bitmap b)
        {
            BitmapData data = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.WriteOnly, b.PixelFormat);
            Marshal.Copy(rgb, 0, data.Scan0, rgb.Count());
            b.UnlockBits(data);
            return b;
        }

        static byte[] BitmapToRGB(Bitmap b)
        {
            BitmapData data = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadOnly, b.PixelFormat);

            byte[] rgb = new byte[Math.Abs(data.Stride) * data.Height];
            Marshal.Copy(data.Scan0, rgb, 0, rgb.Count());
            b.UnlockBits(data);
            return rgb;
        }

        static Bitmap ConvertToPixelFormat(Bitmap b, PixelFormat p)
        {
            Bitmap clone = new Bitmap(b.Width, b.Height, p);

            using (Graphics gr = Graphics.FromImage(clone))
            {
                gr.DrawImage(b, new Rectangle(0, 0, clone.Width, clone.Height));
            }

            return clone;
        }

        void UpdatePictureFrame()
        {
            if (p == null)
                p = this.Controls.Find("imageFrame", true)[0] as PictureBox;

            p.Image = image;
        }

        void LoadImage(Stream s)
        {
            using (s)
            {
                image = new Bitmap(Bitmap.FromStream(s));
                image = ConvertToPixelFormat(image, PixelFormat.Format24bppRgb);
                original = new Bitmap(image.Width, image.Height, image.PixelFormat);
                using (Graphics gr = Graphics.FromImage(original))
                {
                    gr.DrawImage(image, new Rectangle(0, 0, image.Width, image.Height));
                }
            }
            s.Close();
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = @"D:\Desktop\Projects\ImageTransformer\_Test Images";
            openFileDialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF; *.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*";
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog.OpenFile()) != null)
                    {
                        LoadImage(myStream);
                        UpdatePictureFrame();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void bwButton_Click(object sender, EventArgs e)
        {
            if(image == null)
            {
                MessageBox.Show("No Image");
                return;
            }
            byte[] rgb = BitmapToRGB(image);

            if (image.Width % 2 != 0)//ODD Sized images are shifted a byte after each row
                rgb = Transformations.RemoveShiftByte(rgb, image.Width);

            rgb = Transformations.RGBtoBW(rgb, image.Width);

            if (image.Width % 2 != 0)
                rgb = Transformations.AddShiftByte(rgb, image.Width);

            image = RGBtoBitmap(rgb, image);
            UpdatePictureFrame();
        }

        private void rstButton_Click(object sender, EventArgs e)
        {
            if(original == null)
            {
                MessageBox.Show("No Original");
                return;
            }

            using (Graphics gr = Graphics.FromImage(image))
            {
                gr.DrawImage(original, new Rectangle(0, 0, image.Width, image.Height));
            }

            UpdatePictureFrame();
        }

        private void gbButton_Click(object sender, EventArgs e)
        {
            if (image == null)
            {
                MessageBox.Show("No Image");
                return;
            }
            byte[] rgb = BitmapToRGB(image);
            if (image.Width % 2 != 0)//ODD Sized images are shifted a byte after each row
                rgb = Transformations.RemoveShiftByte(rgb, image.Width);

            rgb = Transformations.GaussianBlur(rgb, image.Width, 1);

            if (image.Width % 2 != 0)
                rgb = Transformations.AddShiftByte(rgb, image.Width);

            image = RGBtoBitmap(rgb, image);
            UpdatePictureFrame();
        }
    }
}
