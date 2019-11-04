using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using DrawingLibrary.Vectors;

namespace DrawingLibrary.Samplers
{
    public class ImageSampler : ISampler
    {
        private Vector3[] pixels;
        private Vector3[,] resizedPixels;
        private int width;
        private int height;
        private int resizedWidth;
        private int resizedHeight;
        private Vector2 pixelsSize;

        public ImageSampler(Bitmap bitmap, int width, int height)
        {
            resizedWidth = width;
            resizedHeight = height;
            Image = bitmap;
        }

        public void Transform(Func<Vector3, Vector3> func)
        {
            for(int i = 0; i < pixels.Length; i++)
            {
                pixels[i] = func(pixels[i]);
            }
            Resize(resizedWidth, resizedHeight);
        }

        public Bitmap Image
        {
            set
            { 
                SetPixels(value);
                Resize(resizedWidth, resizedHeight);
            }
        }
        private static Vector2 minUv = new Vector2(0, 0);
        private static Vector2 maxUv = new Vector2(1, 1);
        public Vector3 Sample(Vector2 bitmapPos)
        {
            return resizedPixels[(int)bitmapPos.X,(int)bitmapPos.Y];
        }
        private void SetPixels(Bitmap bmp)
        {


            // Lock the bitmap's bits.  
            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            System.Drawing.Imaging.BitmapData bmpData =
                bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite,
                System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            // Get the address of the first line.
            IntPtr ptr = bmpData.Scan0;

            width = Math.Abs(bmpData.Stride) / 4;
            height = bmpData.Height;
            // Declare an array to hold the bytes of the bitmap.
            int size = width * height;
            pixelsSize = new Vector2(width, height);
            int[] pixelsArgb = new int[size];
            pixels = new Vector3[size];

            // Copy the RGB values into the array.
            System.Runtime.InteropServices.Marshal.Copy(ptr, pixelsArgb, 0, size);
            for(int i = 0; i < size; i++)
            {
                pixels[i] = Color.FromArgb(pixelsArgb[i]).ToVector3();
            }


            // Unlock the bits.
            bmp.UnlockBits(bmpData);


        }

        public void Resize(int newWidth, int newHeight)
        {
            resizedPixels = new Vector3[newWidth,newHeight];
            for(int y = 0; y < newHeight; y++)
            {

                int oldY = y * height / newHeight;
                for (int x = 0; x < newWidth; x++)
                {
                    int oldX = x * width / newWidth;
                    resizedPixels[x, y] = pixels[oldX + width * oldY];
                }
            }
        }
    }
}
