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
        private static int GetPixelRelative(int width, int length, int pixelWidth, int rowChange, int columnChange, int current)
        {
            int n = current + width * pixelWidth * rowChange + columnChange * pixelWidth;

            //Check if n has jumped onto another row
            int currentRow = (int)Math.Floor((double)(current / width / pixelWidth));
            int changedRow = (int)Math.Floor((double)(n / width / pixelWidth));

            if (changedRow - current != rowChange)
            {
                n = -1;
            }

            if (n < 0 || length - 1 < n)
                n = -1;

            return n;
        }

        public static byte[] ApplyFilter(byte[] rgb, Kernel k, int width)
        {
            int pixelWidth = 3;
            byte[] frgb = new byte[rgb.Count()];

            int offset = 0;
            byte test = 0;

            for (int c = 0; c < rgb.Count(); c = c + 3)
            {
                if(width * pixelWidth + offset < c)
                {
                    test++;
                    offset = offset + width * pixelWidth;
                    if (test > 255)
                        test = 0;
                }

                frgb[c] = test;
            }
            return frgb;
        }

        public static byte[] RGBtoBW(byte[] rgb)
        {
            for(int i = 0; i < rgb.Count(); i = i + 3)
            {
                if (i + 1 > rgb.Count() - 1 || i + 2 > rgb.Count() - 1 || i + 3 > rgb.Count() - 1)
                    continue;
                int value = (rgb[i] + rgb[i + 1] + rgb[i + 2]) / 3;
                rgb[i] = (byte)value;
                rgb[i + 1] = (byte)value;
                rgb[i + 2] = (byte)value;
            }

            return rgb;
        }

        public static byte[] GaussianBlur(byte[] rgb, int width, int tao)
        {
            Kernel xKernal = new Kernel();
            Kernel yKernal = new Kernel();

            byte[] xGB = ApplyFilter(rgb, xKernal, width);
            byte[] yGB = ApplyFilter(rgb, yKernal, width);

            byte[] GB = new byte[rgb.Length];

            for(int i = 0; i < rgb.Length; i++)
            {
                GB[i] = (byte)Math.Round(Math.Sqrt((double)(xGB[i] * xGB[i] + yGB[i] * yGB[i])));
            }

            return GB;
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
