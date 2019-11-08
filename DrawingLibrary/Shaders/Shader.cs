using DrawingLibrary.Samplers;
using DrawingLibrary.Vectors;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DrawingLibrary.Shaders
{
    public abstract class Shader
    {
        protected Scene scene;
        protected GlobalData globalData => scene.GlobalData;
        public Sampler MainTex => scene.MainTex;
        public Sampler Normals => scene.Normals;
        protected Mesh mesh { get; private set; }
        protected int triangleIndex { get; private set; }
        internal void Init(Scene scene)
        {
            this.scene = scene;
        }
        public virtual void ForVertex(in Vector2 vertex) { }
        public virtual void StartTriangle(int triangleIndex)
        {
            this.triangleIndex = triangleIndex;
        }
        public virtual void StartMesh(Mesh mesh)
        {
            this.mesh = mesh;
        }
        public abstract Color ForFragment(in Vector2 bitmapPos);


        public static void GetBarymetricWeights(Vector2[] vertices, float[] resultingWeights, in Vector2 bitmapPos)
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
            unchecked
            {
                return weights[0] * vectors[0] + weights[1] * vectors[1] + weights[2] * vectors[2];
            }
        }
        private static readonly Vector3 V = new Vector3(0, 0, 1);
        private static Vector3 MinColorVec = new Vector3(0, 0, 0);
        private static Vector3 MaxColorVec = new Vector3(1, 1, 1);
        public static Vector3 CalculateLight(in Vector3 lightColor, in Vector3 objectColor, in Vector3 toLight, in Vector3 normal, in LightParameters lightParameters)
        {
            unchecked
            {
                float NLAngleCos = Vector3.Dot(normal, toLight);
                Vector3 R = 2 * Vector3.Dot(normal, toLight) * normal - toLight;
                float VRAngleCos = Vector3.Dot(V, R);
                VRAngleCos = VRAngleCos > 0 ? VRAngleCos : 0;
                return
                    Vector3.Clamp(
                        Vector3.Multiply(lightColor, objectColor)
                     * (lightParameters.Kd * NLAngleCos + lightParameters.Ks * (float)Math.Pow(VRAngleCos, lightParameters.M)),
                        MinColorVec,
                        MaxColorVec
                     );
            }
        }
    }
}
