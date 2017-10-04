using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageTransformer
{
    public static class Transformations
    {
        public static byte[] RemoveShiftByte(byte[] odd, int width)
        {
            byte[] even = new byte[3 * width * (odd.Length / (width * 3 + 1))];

            //MessageBox.Show("Removed: " + even.Length + " from " + odd.Length);
            int c = 0;
            int t = 0;
            for(int i = 0; i < even.Length; i++)
            {
                even[i] = odd[c];

                c++;

                if(t == width * 3 - 1)
                {
                    c++;
                    t = 0;
                }
                else
                {
                    t++;
                }
            }

            return even;
        }

        public static byte[] AddShiftByte(byte[] rgb, int width)
        {
            byte[] odd = new byte[(rgb.Length * ((width * 3) + 1)) / (width * 3)];

            //MessageBox.Show("Added: " + odd.Length + " from " + rgb.Length);

            int c = 0;
            int t = 0;
            for (int i = 0; i < rgb.Length; i++)
            {
                if(c < odd.Length)
                odd[c] = rgb[i];

                if(t == width * 3 -1)
                {
                    c++;
                    t = 0;
                }
                else
                {
                    t++;
                }

                c++;
            }

            return odd;
        }

        private static int GetPixelRelative(int width, int length, int pixelWidth, int rowChange, int columnChange, int current)
        {
            int n = current + width * pixelWidth * rowChange + columnChange * pixelWidth;
            //Check if n has jumped onto another row
            int currentRow = 0;
            int changedRow = 0;

            currentRow = (current / width / pixelWidth);
            changedRow = (n / width / pixelWidth);
            
            if (changedRow - currentRow != rowChange)
            {
                //MessageBox.Show("A: " + n);
                n = -1;
            }
            else
            {
                if (n < 0 || length - 1 < n)
                {
                    //MessageBox.Show("B");
                    n = -1;
                }
            }

            return n;
        }

        public static byte[] ApplyFilter(byte[] rgb, Kernel k, int width)
        {
            int pixelWidth = 3;
            byte[] frgb = new byte[rgb.Count()];

            int testCounter = 0;
            int tick = 0;

            for (int c = 0; c < frgb.Count(); c = c + 3)
            {
                if (tick == width)
                {
                    testCounter++;

                    tick = 0;
                }

                tick++;

                if((testCounter / 2) * 2 == testCounter)
                {
                    if(c < frgb.Length)
                    {
                        frgb[c] = 255;
                        int b = GetPixelRelative(width, frgb.Length, pixelWidth, -61, 5, c);
                       // MessageBox.Show("B: " + b);
                        if (0 <= b && b+ 1 < frgb.Length)
                            frgb[b + 1] = 255;
                    }
                }
            }
            return frgb;
        }

        public static byte[] RGBtoBW(byte[] rgb, int width)
        {
            int length = rgb.Length;
            byte[] bw = new byte[length];

            for (int i = 0; i < rgb.Length; i+= 3)
            {                
                if (i> length - 1 || i + 1 > length - 1 || i + 2 > length - 1)
                        continue;

                int value = (rgb[i] + rgb[i + 1] + rgb[i + 2]) / 3;

                if(i <= length - 1)
                    bw[i] = (byte)value;

                if(i + 1 <= length - 1)
                    bw[i + 1] = (byte)value;

                if(i + 2 <= length - 1)
                    bw[i + 2] = (byte)value;
            }

            return bw;
        }

        public static byte[] GaussianBlur(byte[] rgb, int width, int tao)
        {
            if(width % 2 != 0)//ODD Sized images are shifted a byte after each row
                rgb = RemoveShiftByte(rgb, width);

             byte[] bw = RGBtoBW(rgb, width);
             Kernel xKernal = new Kernel();
             Kernel yKernal = new Kernel();

            byte[] xGB = ApplyFilter(bw, xKernal, width);
            /*byte[] yGB = ApplyFilter(bw, yKernal, width);

            byte[] GB = new byte[bw.Length];

            for(int i = 0; i < rgb.Length; i++)
            {
                GB[i] = (byte)Math.Round(Math.Sqrt((double)(xGB[i] * xGB[i] + yGB[i] * yGB[i])));
            }*/

            //return GB;

            if (width % 2 != 0)
                xGB = AddShiftByte(xGB, width);

            return xGB;
        }
    }

    public class Kernel
    {
        int sizeX, sizeY;
        int[,] array;

        public void GenerateArray()
        {

        }
    }
}
