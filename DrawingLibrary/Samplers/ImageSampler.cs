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
        private int width;
        private int height;
        private Vector2 pixelsSize;

        public ImageSampler(Bitmap bitmap)
        {
            Image = bitmap;
        }

        public void Transform(Func<Vector3, Vector3> func)
        {
            for(int i = 0; i < pixels.Length; i++)
            {
                pixels[i] = func(pixels[i]);
            }
        }

        public Bitmap Image
        {
            set => SetPixels(value);
        }
        private static Vector2 minUv = new Vector2(0, 0);
        private static Vector2 maxUv = new Vector2(1, 1);
        public Vector3 Sample(Vector2 UV)
        {
            UV = Vector2.Clamp(UV, minUv, maxUv);
            UV *= pixelsSize;
            return pixels[(int)UV.X + (int)UV.Y*height];
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
    }
}
