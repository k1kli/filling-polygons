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
        private Vector3 color;
        int i;
        public override void StartTriangle()
        {
            i = 0;
        }
        public override void ForVertex(VertexData vertex)
        {
            vertexData[i] = vertex;
            colors[i] = MainTex.Sample(vertexData[i].UV);
            Vectors.Vector3 normal = Normals.Sample(vertexData[i].UV);
            color = CalculateLight(globalData.Ks,
                                   globalData.Kd,
                                   globalData.LightRGB,
                                   colors[i],
                                   globalData.ToLightVersor,
                                   normal,
                                   globalData.M);
            i++;
            if(i == 3)
            {
                color = (colors[0]+colors[1]+colors[2])/3;
            }
        }
        public override Color ForFragment(int x, int y)
        {
            return color.ToColor();
        }
    }
}
