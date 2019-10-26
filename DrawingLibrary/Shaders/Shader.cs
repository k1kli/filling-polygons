using DrawingLibrary.Samplers;
using DrawingLibrary.Vectors;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingLibrary.Shaders
{
    public abstract class Shader
    {
        private Scene scene;
        protected GlobalData globalData => scene.GlobalData;
        public ISampler MainTex { get; set; } = new StaticColorSampler(System.Drawing.Color.Red);
        public ISampler Normals { get; set; } = new StaticColorSampler(System.Drawing.Color.Blue);
        internal void Init(Scene scene)
        {
            this.scene = scene;
        }
        public virtual void ForVertex(VertexData vertex) { }
        public virtual void StartTriangle() { }
        public virtual void StartMesh() { }
        public abstract Color ForFragment(int x, int y);


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
        private static readonly Vector3 V = new Vector3(0, 0, 1);
        public static Vector3 CalculateLight(double ks, double kd, Vector3 lightColor, Vector3 objectColor, Vector3 toLight, Vector3 normal, double m)
        {
            double NLAngleCos = Vector3.DotProduct(normal, toLight);
            double VRAngleCos = Vector3.DotProduct(V, (2*normal - toLight));
            return
                Saturate(
                    Vector3.CoordinateMultiplication(lightColor, objectColor)
                 * (kd * NLAngleCos + ks * Math.Pow(VRAngleCos, m))
                 );
        }
        public static Vector3 Saturate(Vector3 v)
        {
            return new Vector3(Saturate(v.X), Saturate(v.Y), Saturate(v.Z));
        }
        public static double Saturate(double d)
        {
            return d <= 1 ? d : 1;
        }
    }
}
