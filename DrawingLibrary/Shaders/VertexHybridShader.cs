using DrawingLibrary.Vectors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingLibrary.Shaders
{
    public class VertexHybridShader : Shader
    {
        private VertexData[] vertexData = new VertexData[3];
        int i;
        public override void StartTriangle()
        {
            i = 0;
        }
        public override void ForVertex(VertexData vertex)
        {
            vertexData[i++] = vertex;
        }
        private static readonly double[] barymetricWeights = new double[3];
        public override void ForFragment(int x, int y)
        {
            GetBarymetricWeights(vertexData, barymetricWeights, x, y);
            DrawingBitmap.SetPixel(x, y, 
                (int)Sampler.Sample(WeightedAverage(barymetricWeights, vertexData[0].UV,
                                                         vertexData[1].UV,
                                                         vertexData[2].UV)));
        }
    }
}
