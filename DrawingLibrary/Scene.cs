using DrawingLibrary.Samplers;
using DrawingLibrary.Vectors;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingLibrary
{
    public class Scene
    {
        public MemoryBitmap Bitmap { get; }
        private readonly TriangleDrawer triangleDrawer;
        public GlobalData GlobalData;
        public ISampler MainTex { get; set; } = new StaticColorSampler(System.Drawing.Color.Red);
        public ISampler Normals { get; set; } = new StaticColorSampler(System.Drawing.Color.Blue);
        public bool DrawWireframe { get; set; } = true;
        public Shaders.Shader Shader {
            get => triangleDrawer.Shader;
            set
            {
                triangleDrawer.Shader = value; triangleDrawer.Shader.Init(this);
            }
        }
        public Scene(MemoryBitmap bitmap, Shaders.Shader shader, GlobalData globalData)
        {
            Bitmap = bitmap;
            triangleDrawer = new TriangleDrawer(Bitmap);
            GlobalData = globalData;
            Shader = shader;
        }
        public float MinX { get; set; } = -5;
        public float MinY { get; set; } = -5;
        public float MaxX { get; set; } = 5;
        public float MaxY { get; set; } = 5;
        public float Width => MaxX - MinX;
        public float Height => MaxY - MinY;

        public Vector2 TransformToSceneCoords(in Vector2 bitmapCoordsPos)
        {
            return new Vector2(
                Width * bitmapCoordsPos.X / Bitmap.Width + MinX,
                Height * bitmapCoordsPos.Y / Bitmap.Height + MinY);
        }
        public Vector2 TransformToSceneCoords(in IntVector2 bitmapCoordsPos)
        {
            return new Vector2(
                Width * bitmapCoordsPos.X / Bitmap.Width + MinX,
                Height * bitmapCoordsPos.Y / Bitmap.Height + MinY);
        }

        public Vectors.Vector2 TransformToBitmapCoords(in Vector2 sceneCoordsPos)
        {
            return new Vector2(
                 Bitmap.Width * (sceneCoordsPos.X - MinX) / Width,
                Bitmap.Height * (sceneCoordsPos.Y - MinY) / Height);
        }
        public void TransformToBitmapCoords(in Vector2 sceneCoordsPos, out int bitmapX, out int bitmapY)
        {
            bitmapX = (int)(Bitmap.Width * (sceneCoordsPos.X - MinX) / Width);
            bitmapY = (int)(Bitmap.Height * (sceneCoordsPos.Y - MinY) / Height);
        }

        private static readonly IntVector2[] triangleVertices = { new IntVector2(), new IntVector2(), new IntVector2() };
        public void DrawMesh(Mesh mesh)
        {
            Bitmap.Clear();
            Bitmap.CreateGraphics();
            Graphics g = Bitmap.GetGraphics();
            int max = mesh.Triangles.Max();
            if (max >= mesh.Vertices.Length)
            {
                throw new Exception($"There is no vertex with index {max}");
            }
            var watch = System.Diagnostics.Stopwatch.StartNew();
            for (int triangle = 0; triangle < mesh.Triangles.Length; triangle += 3)
            {
                int p1X, p1Y, p2X, p2Y, p3X, p3Y;
                TransformToBitmapCoords(mesh.Vertices[mesh.Triangles[triangle]], out p1X, out p1Y);
                TransformToBitmapCoords(mesh.Vertices[mesh.Triangles[triangle+1]], out p2X, out p2Y);
                TransformToBitmapCoords(mesh.Vertices[mesh.Triangles[triangle+2]], out p3X, out p3Y);
                triangleVertices[0].X = p1X; triangleVertices[0].Y = p1Y;
                triangleVertices[1].X = p2X; triangleVertices[1].Y = p2Y;
                triangleVertices[2].X = p3X; triangleVertices[2].Y = p3Y;
                triangleDrawer.DrawTriangle(triangleVertices);
                if(DrawWireframe)
                {
                    g.DrawLine(Pens.Black, p1X, p1Y, p2X, p2Y);
                    g.DrawLine(Pens.Black, p3X, p3Y, p2X, p2Y);
                    g.DrawLine(Pens.Black, p1X, p1Y, p3X, p3Y);
                }
            }
            watch.Stop();
            Console.WriteLine("Rendered mesh in " + watch.ElapsedMilliseconds + " ms");
            Bitmap.DisposeGraphics();
        }
    }
}
