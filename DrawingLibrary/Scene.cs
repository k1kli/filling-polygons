﻿using DrawingLibrary.Vectors;
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
        private TriangleDrawer triangleDrawer;
        public Shaders.Shader Shader { get => triangleDrawer.Shader; set => triangleDrawer.Shader = value; }
        public Scene(MemoryBitmap bitmap, Shaders.Shader shader)
        {
            Bitmap = bitmap;
            triangleDrawer = new TriangleDrawer();
            triangleDrawer.Shader = shader;
            shader.Init(bitmap);
        }
        public float MinX { get; set; } = 0;
        public float MinY { get; set; } = 0;
        public float MaxX { get; set; } = 10;
        public float MaxY { get; set; } = 10;
        public float Width => MaxX - MinX;
        public float Height => MaxY - MinY;

        public Vector2 TransformToSceneCoords(Vector2 bitmapCoordsPos)
        {
            return new Vector2(
                Width * bitmapCoordsPos.X / Bitmap.Width + MinX,
                (MaxY - MinY) * bitmapCoordsPos.Y / Bitmap.Height + MinY);
        }

        public Vectors.Vector2 TransformToBitmapCoords(Vector2 sceneCoordsPos)
        {
            return new Vector2(
                 Bitmap.Width * (sceneCoordsPos.X + MinX) / Width,
                Bitmap.Height * (sceneCoordsPos.Y + MinY) / Height);
        }
        public void TransformToBitmapCoords(Vector2 sceneCoordsPos, out int bitmapX, out int bitmapY)
        {
            bitmapX = (int)(Bitmap.Width * (sceneCoordsPos.X + MinX) / Width);
            bitmapY = (int)(Bitmap.Height * (sceneCoordsPos.Y + MinY) / Height);
        }

        private static readonly VertexData[] triangleVertices = { new VertexData(), new VertexData(), new VertexData() };
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
            for (int triangle = 0; triangle < mesh.Triangles.Length; triangle += 3)
            {
                int p1X, p1Y, p2X, p2Y, p3X, p3Y;
                TransformToBitmapCoords(mesh.Vertices[mesh.Triangles[triangle]], out p1X, out p1Y);
                TransformToBitmapCoords(mesh.Vertices[mesh.Triangles[triangle+1]], out p2X, out p2Y);
                TransformToBitmapCoords(mesh.Vertices[mesh.Triangles[triangle+2]], out p3X, out p3Y);
                triangleVertices[0].BitmapPos.X = p1X; triangleVertices[0].BitmapPos.Y = p1Y;
                triangleVertices[1].BitmapPos.X = p2X; triangleVertices[1].BitmapPos.Y = p2Y;
                triangleVertices[2].BitmapPos.X = p3X; triangleVertices[2].BitmapPos.Y = p3Y;
                triangleVertices[0].UV = mesh.UV[mesh.Triangles[triangle]];
                triangleVertices[1].UV = mesh.UV[mesh.Triangles[triangle + 1]];
                triangleVertices[2].UV = mesh.UV[mesh.Triangles[triangle + 2]];
                triangleDrawer.DrawTriangle(triangleVertices);
                g.DrawLine(Pens.Black, p1X, p1Y, p2X, p2Y);
                g.DrawLine(Pens.Black, p3X, p3Y, p2X, p2Y);
                g.DrawLine(Pens.Black, p1X, p1Y, p3X, p3Y);
            }
            Bitmap.DisposeGraphics();
        }
    }
}
