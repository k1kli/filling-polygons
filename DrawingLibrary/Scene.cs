using DrawingLibrary.Samplers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using DrawingLibrary.Vectors;

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
            BitmapToSceneMatrix = Matrix3x2.Multiply(
                Matrix3x2.CreateScale(Width / Bitmap.Width, Height / Bitmap.Height),
                Matrix3x2.CreateTranslation(MinX, MinY)
                );
            SceneToBitmapMatrix = Matrix3x2.Multiply(
                Matrix3x2.CreateTranslation(-MinX, -MinY),
                Matrix3x2.CreateScale(Bitmap.Width / Width, Bitmap.Height / Height));
        }
        public float MinX { get; set; } = -5;
        public float MinY { get; set; } = -5;
        public float MaxX { get; set; } = 5;
        public float MaxY { get; set; } = 5;
        public float Width => MaxX - MinX;
        public float Height => MaxY - MinY;

        private Matrix3x2 BitmapToSceneMatrix;
        private Matrix3x2 SceneToBitmapMatrix;
        public void ResizeBitmap(Vector2 newSize)
        {
            Bitmap.Resize((int)newSize.X, (int)newSize.Y);
            BitmapToSceneMatrix = Matrix3x2.Multiply(
                Matrix3x2.CreateScale(Width / Bitmap.Width, Height / Bitmap.Height),
                Matrix3x2.CreateTranslation(MinX, MinY)
                );
            SceneToBitmapMatrix = Matrix3x2.Multiply(
                Matrix3x2.CreateTranslation(-MinX, -MinY),
                Matrix3x2.CreateScale(Bitmap.Width / Width, Bitmap.Height / Height));
        }

        public Vector2 TransformToSceneCoords(in Vector2 bitmapCoordsPos)
        {
            return Vector2.Transform(bitmapCoordsPos, BitmapToSceneMatrix);
        }

        public Vector2 TransformToBitmapCoords(in Vector2 sceneCoordsPos)
        {
            return Vector2.Transform(sceneCoordsPos, SceneToBitmapMatrix);
        }

        private static readonly IntVector2[] triangleVertices = new IntVector2[3];
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
            Shader.StartMesh(mesh);
            for (int triangle = 0; triangle < mesh.Triangles.Length; triangle += 3)
            {
                triangleVertices[0] = new IntVector2(TransformToBitmapCoords(mesh.Vertices[mesh.Triangles[triangle]]));
                triangleVertices[1] = new IntVector2(TransformToBitmapCoords(mesh.Vertices[mesh.Triangles[triangle+1]]));
                triangleVertices[2] = new IntVector2(TransformToBitmapCoords(mesh.Vertices[mesh.Triangles[triangle+2]]));
                triangleDrawer.DrawTriangle(triangleVertices, triangle/3);
                if(DrawWireframe)
                {
                    g.DrawLine(Pens.Black,
                        triangleVertices[0].X, triangleVertices[0].Y,
                        triangleVertices[1].X, triangleVertices[1].Y);
                    g.DrawLine(Pens.Black,
                        triangleVertices[2].X, triangleVertices[2].Y,
                        triangleVertices[1].X, triangleVertices[1].Y);
                    g.DrawLine(Pens.Black,
                        triangleVertices[2].X, triangleVertices[2].Y,
                        triangleVertices[0].X, triangleVertices[0].Y);
                }
            }
            watch.Stop();
            Console.WriteLine("Rendered mesh in " + watch.ElapsedMilliseconds + " ms");
            Bitmap.DisposeGraphics();
        }
    }
}
