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
    public class VertexColorShader : Shader
    {
        private Vector2[] vertices = new Vector2[3];
        private Vector3[] colors = new Vector3[3];
        int i;
        public override void StartTriangle(int triangleIndex)
        {
            base.StartTriangle(triangleIndex);
            i = 0;
        }
        public override void ForVertex(in Vector2 vertex)
        {
            vertices[i] = vertex;
            Vector2 uv = GetUV(vertex);
            colors[i] = MainTex.Sample(uv);
            Vector3 normal = Normals.Sample(uv);
            Vector3 toLight = Vector3.Normalize(globalData.LightPosition - new Vector3(scene.TransformToSceneCoords(vertex), 0));
            colors[i] = CalculateLight(globalData.LightRGB,
                                   colors[i],
                                   toLight,
                                   normal,
                                   mesh.TrianglesLightParameters[triangleIndex]);
            i++;
        }
        public override Color ForFragment(in Vector2 bitmapPos)
        {
            float[] barymetricWeights = new float[3];
            GetBarymetricWeights(vertices, barymetricWeights, bitmapPos);
            Vector3 color = colors[0] * barymetricWeights[0] + colors[1] * barymetricWeights[1] + colors[2] * barymetricWeights[2];
            return color.ToColor();
        }
    }
}
