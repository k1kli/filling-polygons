using DrawingLibrary.Vectors;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingLibrary.Shaders
{
    public class VertexColorShader : Shader
    {
        private VertexData[] vertexData = new VertexData[3];
        private Vector3[] colors = new Vector3[3];
        int i;
        public override void StartTriangle()
        {
            i = 0;
        }
        public override void ForVertex(in VertexData vertex)
        {
            vertexData[i] = vertex;
            colors[i] = MainTex.Sample(vertexData[i].UV);
            Vectors.Vector3 normal = Normals.Sample(vertexData[i].UV);
            Vector3 toLight = (globalData.LightPosition - new Vector3(scene.TransformToSceneCoords(vertex.BitmapPos))).Normalized;
            colors[i] = CalculateLight(globalData.Ks,
                                   globalData.Kd,
                                   globalData.LightRGB,
                                   colors[i],
                                   toLight,
                                   normal,
                                   globalData.M);
            i++;
        }
        public override Color ForFragment(in IntVector2 bitmapPos)
        {
            double[] barymetricWeights = new double[3];
            GetBarymetricWeights(vertexData, barymetricWeights, bitmapPos);
            Vector3 color = colors[0] * barymetricWeights[0] + colors[1] * barymetricWeights[1] + colors[2] * barymetricWeights[2];
            return color.ToColor();
        }
    }
}
