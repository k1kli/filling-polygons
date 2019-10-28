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
        protected Scene scene;
        protected GlobalData globalData => scene.GlobalData;
        public ISampler MainTex => scene.MainTex;
        public ISampler Normals => scene.Normals;
        internal void Init(Scene scene)
        {
            this.scene = scene;
        }
        public virtual void ForVertex(in VertexData vertex) { }
        public virtual void StartTriangle() { }
        public virtual void StartMesh() { }
        public abstract Color ForFragment(in IntVector2 bitmapPos);


        public static void GetBarymetricWeights(VertexData[] vertices, double[] resultingWeights, in IntVector2 bitmapPos)
        {
            resultingWeights[0] =
                 ((double)(vertices[1].BitmapPos.Y - vertices[2].BitmapPos.Y)
                 * (bitmapPos.X - vertices[2].BitmapPos.X)
                 + (double)(vertices[2].BitmapPos.X - vertices[1].BitmapPos.X)
                 * (bitmapPos.Y - vertices[2].BitmapPos.Y))
                 / 
                 ((double)(vertices[1].BitmapPos.Y - vertices[2].BitmapPos.Y)
                 * (vertices[0].BitmapPos.X - vertices[2].BitmapPos.X)
                 + (double)(vertices[2].BitmapPos.X - vertices[1].BitmapPos.X)
                 * (vertices[0].BitmapPos.Y - vertices[2].BitmapPos.Y));
            resultingWeights[1] =
                 ((double)(vertices[2].BitmapPos.Y - vertices[0].BitmapPos.Y)
                 * (bitmapPos.X - vertices[2].BitmapPos.X)
                 + (double)(vertices[0].BitmapPos.X - vertices[2].BitmapPos.X)
                 * (bitmapPos.Y - vertices[2].BitmapPos.Y))
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
        /// Size of both arrays must be 3
        /// </summary>
        /// <param name="weights">Barymetric weights</param>
        /// <param name="vectors">Vectors to average</param>
        /// <returns></returns>
        public static Vector2 WeightedAverage(double[] weights, params Vector2[] vectors)
        {
            return weights[0] * vectors[0] + weights[1] * vectors[1] + weights[2] * vectors[2];
        }
        private static readonly Vector3 V = new Vector3(0, 0, 1);
        public static Vector3 CalculateLight(double ks, double kd, in Vector3 lightColor, in Vector3 objectColor, in Vector3 toLight, in Vector3 normal, double m)
        {
            double NLAngleCos = Vector3.DotProduct(normal, toLight);
            double VRAngleCos = Vector3.DotProduct(V, (2*normal - toLight).Normalized);
            return
                Saturate(
                    Vector3.CoordinateMultiplication(lightColor, objectColor)
                 * (kd * NLAngleCos + ks * Math.Pow(VRAngleCos, m))
                 );
        }
        public static Vector3 Saturate(in Vector3 v)
        {
            return new Vector3(Saturate(v.X), Saturate(v.Y), Saturate(v.Z));
        }
        public static double Saturate(double d)
        {
            return d >= 0 ? (d <= 1 ? d : 1) : 0;
        }
    }
}
