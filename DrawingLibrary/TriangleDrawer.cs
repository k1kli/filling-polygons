using DrawingLibrary.Shaders;
using DrawingLibrary.Vectors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DrawingLibrary
{
    public class TriangleDrawer
    {
        public Shader Shader { get; set; }
        class AETData
        {
            public double x;
            public double antitangent;
            public double yMax;
        }
        int[] sortedVerticesIndexes = { 0, 1, 2 };
        LinkedList<AETData> AET = new LinkedList<AETData>();
        private MemoryBitmap bitmap;
        private LinkedList<IntVector2> ToDraw = new LinkedList<IntVector2>();

        public TriangleDrawer(MemoryBitmap bitmap)
        {
            this.bitmap = bitmap;
        }

        public void DrawTriangle(VertexData[] vertices)
        {
            if (Shader == null) throw new Exception("First assign value to Shader field");
            for (int i = 0; i < vertices.Length; i++)
            {
                Shader.ForVertex(vertices[i]);
            }
            Shader.StartTriangle();
            Array.Sort(sortedVerticesIndexes, (int a, int b) => vertices[a].BitmapPos.Y.CompareTo(vertices[b].BitmapPos.Y));
            int yMin = vertices[sortedVerticesIndexes[0]].BitmapPos.Y;
            int yMax = vertices[sortedVerticesIndexes[sortedVerticesIndexes.Length - 1]].BitmapPos.Y;
            int k = 0;
            for (int y = yMin + 1; y <= yMax; y++)
            {
                while (vertices[sortedVerticesIndexes[k]].BitmapPos.Y == y - 1)
                {
                    int prevIndex = (sortedVerticesIndexes[k] + vertices.Length - 1) % vertices.Length;
                    int nextIndex = (sortedVerticesIndexes[k] + 1) % vertices.Length;
                    if (vertices[prevIndex].BitmapPos.Y > y - 1) AET.AddLast(
                           new AETData()
                           {
                               x = vertices[sortedVerticesIndexes[k]].BitmapPos.X,
                               antitangent = GetAntiTangent(vertices[sortedVerticesIndexes[k]].BitmapPos, vertices[prevIndex].BitmapPos),
                               yMax = vertices[prevIndex].BitmapPos.Y
                           });
                    if (vertices[nextIndex].BitmapPos.Y > y - 1) AET.AddLast(
                           new AETData()
                           {
                               x = vertices[sortedVerticesIndexes[k]].BitmapPos.X,
                               antitangent = GetAntiTangent(vertices[sortedVerticesIndexes[k]].BitmapPos, vertices[nextIndex].BitmapPos),
                               yMax = vertices[nextIndex].BitmapPos.Y
                           });
                    k++;
                }

                foreach(var edge in AET)
                {
                    edge.x += edge.antitangent;
                }
                AET.Sort((AETData edge1, AETData edge2) => edge1.x.CompareTo(edge2.x));
                DrawOnScanLine(y);
                RemoveFinishedEdges(y);
            }
            Parallel.ForEach(ToDraw, (v) => bitmap.SetPixel(v.X, v.Y, Shader.ForFragment(v)));
            ToDraw.Clear();
        }

        private void RemoveFinishedEdges(int y)
        {
            if (AET.Count == 0) return;
            var node = AET.First;
            while (node.Next != null)
            {
                if (node.Next.Value.yMax <= y)
                {
                    AET.Remove(node.Next);
                }
                else
                {
                    node = node.Next;
                }
            }
            if (AET.Count > 0 && AET.First.Value.yMax <= y) AET.RemoveFirst();
        }

        private void DrawOnScanLine(int y)
        {
            var enumerator = AET.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var previous = enumerator.Current;
                if (!enumerator.MoveNext()) return;
                var current = enumerator.Current;
                int startX = (int)(previous.x + 0.5);
                int endX = (int)(current.x + 0.5);
                int y1 = y;
                for (int x = startX; x < endX; x++)
                {
                    ToDraw.AddLast(new IntVector2(x, y));
                    //bitmap.SetPixel(x, y, Shader.ForFragment(x, y));
                }
                //Parallel.For(startX, endX, (x) => bitmap.SetPixel(x, y1, Shader.ForFragment(x, y1)));
            }
        }
        private double GetAntiTangent(IntVector2 from, IntVector2 to)
        {
            return (double)(to.X - from.X) / (to.Y - from.Y);
        }
    }
}
