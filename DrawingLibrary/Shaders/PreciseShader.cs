using DrawingLibrary.Vectors;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingLibrary.Shaders
{
    public class PreciseShader : Shader
    {
        private IntVector2[] vertices = new IntVector2[3];
        int i;
        public override void StartTriangle()
        {
            i = 0;
        }
        public override void ForVertex(in IntVector2 vertex)
        {
            vertices[i++] = vertex;
        }
        public override Color ForFragment(in IntVector2 bitmapPos)
        {
            float[] barymetricWeights = new float[3];
            Vector2 uv = GetUV(bitmapPos);
            Vector3 color = MainTex.Sample(uv);
            Vectors.Vector3 normal = Normals.Sample(uv);
            Vector3 toLight = (globalData.LightPosition - new Vector3(scene.TransformToSceneCoords(bitmapPos))).Normalized;
            color = CalculateLight(globalData.Ks,
                                   globalData.Kd,
                                   globalData.LightRGB,
                                   color,
                                   toLight,
                                   normal,
                                   globalData.M);
            return color.ToColor();
        }
    }
}
