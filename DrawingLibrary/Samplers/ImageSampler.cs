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
        private int[] pixels;
        private int width;
        private int height;

        public ImageSampler(Bitmap bitmap)
        {
            Image = bitmap;
        }

        public Bitmap Image
        {
            set => SetPixels(value);
        }
        public uint Sample(Vector2 UV)
        {
            return (uint)GetPixel(((int)(UV.X*width))%width, ((int)(UV.Y*height))%height);
        }
        private int GetPixel(int x, int y)
        {
            return pixels[y * width + x];
        }
        private void SetPixels(Bitmap bmp)
        {


            // Lock the bitmap's bits.  
            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            System.Drawing.Imaging.BitmapData bmpData =
                bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite,
                bmp.PixelFormat);

            // Get the address of the first line.
            IntPtr ptr = bmpData.Scan0;

            width = Math.Abs(bmpData.Stride) / 4;
            height = bmpData.Height;
            // Declare an array to hold the bytes of the bitmap.
            int size = width * height;
            pixels = new int[size];

            // Copy the RGB values into the array.
            System.Runtime.InteropServices.Marshal.Copy(ptr, pixels, 0, size);


            // Unlock the bits.
            bmp.UnlockBits(bmpData);


        }
    }
}
