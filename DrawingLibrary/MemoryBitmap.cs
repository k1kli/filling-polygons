using DrawingLibrary.Vectors;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DrawingLibrary
{
    public class MemoryBitmap
    {
        public Bitmap Bitmap { get; private set; }
        public Int32[] Bits { get; private set; }
        public bool Disposed { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }

        public Vector2 Size { get; private set; }
        protected GCHandle BitsHandle { get; private set; }
        private Graphics g;
        public MemoryBitmap(int xSize, int ySize)
        {
            Width = xSize;
            Height = ySize;
            Size = new Vector2(Width, Height);
            Bits = new Int32[Width * Height];
            BitsHandle = GCHandle.Alloc(Bits, GCHandleType.Pinned);
            Bitmap = new Bitmap(Width, Height, Width * 4, PixelFormat.Format32bppPArgb, BitsHandle.AddrOfPinnedObject());
        }
        public void Resize(int newXSize, int newYSize)
        {
            Bitmap.Dispose();
            BitsHandle.Free();
            Width = newXSize;
            Height = newYSize;
            Size = new Vector2(Width, Height);
            Bits = new Int32[Width * Height];
            BitsHandle = GCHandle.Alloc(Bits, GCHandleType.Pinned);
            Bitmap = new Bitmap(Width, Height, Width * 4, PixelFormat.Format32bppPArgb, BitsHandle.AddrOfPinnedObject());
        }
        public void SetPixel(int x, int y, Color color)
        {
            SetPixel(x, y, color.ToArgb());
        }
        public void SetPixel(int x, int y, int argb)
        {
            if (x < 0 || x >= Width || y < 0 || y >= Height) return;
            RawSetPixel(x, y, argb);
        }
        public void RawSetPixel(int x, int y, int argb)
        {
            unchecked
            {
                int index = x + (y * Width);
                int col = argb;


                Bits[index] = col;
            }
        }
        public unsafe void RawSetPixel(int x, int y, Color color)
        {
            unchecked
            {
                int index = x + (y * Width);
                int col = color.ToArgb();

                Bits[index] = col;
            }
        }
        public Color GetPixel(int x, int y)
        {
            if (x < 0 || x >= Width || y < 0 || y >= Height) throw new IndexOutOfRangeException();
            int index = x + (y * Width);
            int col = Bits[index];
            Color result = Color.FromArgb(col);

            return result;
        }
        public void Clear()
        {
            CreateGraphics();
            GetGraphics().FillRectangle(Brushes.White, 0, 0, Width, Height);
            DisposeGraphics();
        }
        public void Dispose()
        {
            if (Disposed) return;
            Disposed = true;
            Bitmap.Dispose();
            BitsHandle.Free();
        }
        public void CreateGraphics()
        {
            g = Graphics.FromImage(Bitmap);
        }
        public void DisposeGraphics()
        {
            g.Dispose();
        }
        public Graphics GetGraphics()
        {
            return g;
        }

    }
}
