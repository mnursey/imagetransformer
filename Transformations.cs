﻿using System;
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
            int height = rgb.Length / width / pixelWidth;
            byte[] frgb = new byte[rgb.Length];

            for (int x = 0; x < rgb.Length; x = x + pixelWidth)
            {    
                float bSum = 0.0f;
                float gSum = 0.0f;
                float rSum = 0.0f;

                float kSum = 0.0f;
                for (int u = 0; u < k.width; u++)
                {
                    for(int v = 0; v < k.height; v++)
                    {
                        int p = GetPixelRelative(width, rgb.Length, pixelWidth, v - k.height/2, u - k.width/2, x);
                        //MessageBox.Show("" + x);
                        if(-1 < p)
                        {
                            bSum += k.array[u, v] * rgb[p];
                            gSum += k.array[u, v] * rgb[p + 1];
                            rSum += k.array[u, v] * rgb[p + 2];
                            kSum += k.array[u, v];
                        }
                    }
                }
                //MessageBox.Show("Sum: " + sum);                
                byte bResult = (byte)(bSum / (kSum));
                byte gResult = (byte)(gSum / (kSum));
                byte rResult = (byte)(rSum / (kSum));

                frgb[x] = bResult;
                frgb[x + 1] = gResult;
                frgb[x + 2] = rResult;
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
            Kernel kernal = new Kernel();
            kernal.GenerateArray(new int[] {1,2,1,2,4,2,1,2,1}, 3);
            return ApplyFilter(rgb, kernal, width);
        }
    }

    public class Kernel
    {
        public int width, height;
        public int[,] array;
        public void GenerateArray(int[] kernal, int width_)
        {
            width = width_;
            height = kernal.Length / width;
            array = new int[width, height];

            int x = 0;
            int y = 0;
            for(int p = 0; p < width * height; p++)
            {
                array[x, y] = kernal[p];

                x++;
                if(x == width)
                {
                    y++;
                    x = 0;
                }
            }


            /*for (int a = 0; a < width; a++)
            {
                for (int b = 0; b < height; b++)
                {
                    MessageBox.Show(a + " " + b + " : " + array[a,b]);
                }
            } Testing the array*/ 
        }
    }
}
