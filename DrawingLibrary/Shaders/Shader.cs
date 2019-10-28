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
        protected Mesh mesh { get; private set; }
        protected int triangleIndex { get; private set; }
        internal void Init(Scene scene)
        {
            this.scene = scene;
        }
        public virtual void ForVertex(in IntVector2 vertex) { }
        public virtual void StartTriangle(int triangleIndex)
        {
            this.triangleIndex = triangleIndex;
        }
        public virtual void StartMesh(Mesh mesh)
        {
            this.mesh = mesh;
        }
        public abstract Color ForFragment(in IntVector2 bitmapPos);

        public Vector2 GetUV(in IntVector2 bitmapPos)
        {
            return new Vector2((float)bitmapPos.X / scene.Bitmap.Width, (float)bitmapPos.Y / scene.Bitmap.Height);
        }

        public static void GetBarymetricWeights(IntVector2[] vertices, float[] resultingWeights, in IntVector2 bitmapPos)
        {
            resultingWeights[0] =
                 ((float)(vertices[1].Y - vertices[2].Y)
                 * (bitmapPos.X - vertices[2].X)
                 + (float)(vertices[2].X - vertices[1].X)
                 * (bitmapPos.Y - vertices[2].Y))
                 / 
                 ((float)(vertices[1].Y - vertices[2].Y)
                 * (vertices[0].X - vertices[2].X)
                 + (float)(vertices[2].X - vertices[1].X)
                 * (vertices[0].Y - vertices[2].Y));
            resultingWeights[1] =
                 ((float)(vertices[2].Y - vertices[0].Y)
                 * (bitmapPos.X - vertices[2].X)
                 + (float)(vertices[0].X - vertices[2].X)
                 * (bitmapPos.Y - vertices[2].Y))
                 /
                 ((float)(vertices[1].Y - vertices[2].Y)
                 * (vertices[0].X - vertices[2].X)
                 + (float)(vertices[2].X - vertices[1].X)
                 * (vertices[0].Y - vertices[2].Y));
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
        public static Vector2 WeightedAverage(float[] weights, params Vector2[] vectors)
        {
            return weights[0] * vectors[0] + weights[1] * vectors[1] + weights[2] * vectors[2];
        }
        private static readonly Vector3 V = new Vector3(0, 0, 1);
        public static Vector3 CalculateLight(in Vector3 lightColor, in Vector3 objectColor, in Vector3 toLight, in Vector3 normal, in LightParameters lightParameters)
        {
            float NLAngleCos = Vector3.DotProduct(normal, toLight);
            float VRAngleCos = Vector3.DotProduct(V, (2*normal - toLight).Normalized);
            return
                Saturate(
                    Vector3.CoordinateMultiplication(lightColor, objectColor)
                 * (lightParameters.Kd * NLAngleCos + lightParameters.Ks * (float)Math.Pow(VRAngleCos, lightParameters.M))
                 );
        }
        public static Vector3 Saturate(in Vector3 v)
        {
            return new Vector3(Saturate(v.X), Saturate(v.Y), Saturate(v.Z));
        }
        public static float Saturate(float d)
        {
            return d >= 0 ? (d <= 1 ? d : 1) : 0;
        }
    }
}
