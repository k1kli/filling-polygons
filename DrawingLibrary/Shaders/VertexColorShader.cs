using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingLibrary.Shaders
{
    public class VertexColorShader : Shader
    {
        private VertexData[] vertexData = new VertexData[3];
        private uint color;
        int i;
        public override void StartTriangle()
        {
            i = 0;
        }
        public override void ForVertex(VertexData vertex)
        {
            vertexData[i++] = vertex;
            if(i == 3)
            {
                color = AverageColor(Sampler.Sample(vertexData[0].UV),
                                     Sampler.Sample(vertexData[1].UV),
                                     Sampler.Sample(vertexData[2].UV));
            }
        }
        public override void ForFragment(int x, int y)
        {
            DrawingBitmap.SetPixel(x, y, (int)color);
        }
    }
}
