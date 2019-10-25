using DrawingLibrary.Samplers;
using DrawingLibrary.Vectors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingLibrary.Shaders
{
    public abstract class Shader
    {
        protected MemoryBitmap DrawingBitmap { get; private set; }
        public ISampler Sampler { get; set; } = new StaticColorSampler(System.Drawing.Color.Red);
        internal void Init(MemoryBitmap drawingBitmap)
        {
            DrawingBitmap = drawingBitmap;
        }
        public virtual void ForVertex(VertexData vertex) { }
        public virtual void StartTriangle() { }
        public virtual void StartMesh() { }
        public abstract void ForFragment(int x, int y);

        public static uint AverageColor(uint c1, uint c2, uint c3)
        {
            return ((c1 & 255) + (c2 & 255) + (c3 & 255)) / 3
                + (((((c1 >> 8) & 255) + ((c2 >> 8) & 255) + ((c3 >> 8) & 255)) / 3) << 8)
                + (((((c1 >> 16) & 255) + ((c2 >> 16) & 255) + ((c3 >> 16) & 255)) / 3) << 16)
                + (((((c1 >> 24) & 255) + ((c2 >> 24) & 255) + ((c3 >> 24) & 255)) / 3) << 24);
        }

        public static void GetBarymetricWeights(VertexData[] vertices, double[] resultingWeights, int curX, int curY)
        {
            resultingWeights[0] =
                 ((double)(vertices[1].BitmapPos.Y - vertices[2].BitmapPos.Y)
                 * (curX - vertices[2].BitmapPos.X)
                 + (double)(vertices[2].BitmapPos.X - vertices[1].BitmapPos.X)
                 * (curY - vertices[2].BitmapPos.Y))
                 / 
                 ((double)(vertices[1].BitmapPos.Y - vertices[2].BitmapPos.Y)
                 * (vertices[0].BitmapPos.X - vertices[2].BitmapPos.X)
                 + (double)(vertices[2].BitmapPos.X - vertices[1].BitmapPos.X)
                 * (vertices[0].BitmapPos.Y - vertices[2].BitmapPos.Y));
            resultingWeights[1] =
                 ((double)(vertices[2].BitmapPos.Y - vertices[0].BitmapPos.Y)
                 * (curX - vertices[2].BitmapPos.X)
                 + (double)(vertices[0].BitmapPos.X - vertices[2].BitmapPos.X)
                 * (curY - vertices[2].BitmapPos.Y))
                 /
                 ((double)(vertices[1].BitmapPos.Y - vertices[2].BitmapPos.Y)
                 * (vertices[0].BitmapPos.X - vertices[2].BitmapPos.X)
                 + (double)(vertices[2].BitmapPos.X - vertices[1].BitmapPos.X)
                 * (vertices[0].BitmapPos.Y - vertices[2].BitmapPos.Y));
            resultingWeights[2] = 1 - resultingWeights[1] - resultingWeights[0];
        }
        /// <summary>
        /// Calculating average vector with barymetric sums
        /// Weights must sum up to 1
        /// Number of vector parameters must be equal to size of weights array
        /// </summary>
        /// <param name="weights">Barymetric weights</param>
        /// <param name="vectors">Vectors to average</param>
        /// <returns></returns>
        public static Vector2 WeightedAverage(double[] weights, params Vector2[] vectors)
        {
            Vector2 average = vectors[0]*weights[0];
            for (int i = 1; i < vectors.Length; i++)
            {
                average += vectors[i]*weights[i];
            }
            return average;
        }
    }
}
