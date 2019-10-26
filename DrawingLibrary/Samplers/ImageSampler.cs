using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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
        public Vector3 Sample(Vector2 UV)
        {
            return GetPixel(((int)(UV.X*width) + width)%width, ((int)(UV.Y*height) + height)%height);
        }
        private Vector3 GetPixel(int x, int y)
        {
            return pixels[y * width + x];
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
