﻿using DrawingLibrary.Vectors;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingLibrary.Shaders
{
    public class HybridShader:Shader
    {
        private VertexData[] vertexData = new VertexData[3];
        private Vector3[] colors = new Vector3[3];
        private Vector3[] normals = new Vector3[3];
        int i;
        public override void StartTriangle()
        {
            i = 0;
        }
        public override void ForVertex(in VertexData vertex)
        {
            vertexData[i] = vertex;
            colors[i] = MainTex.Sample(vertexData[i].UV);
            normals[i] = Normals.Sample(vertexData[i].UV);
            i++;
        }
        public override Color ForFragment(in IntVector2 bitmapPos)
        {
            float[] barymetricWeights = new float[3];
            GetBarymetricWeights(vertexData, barymetricWeights, bitmapPos);
            Vector3 color = colors[0] * barymetricWeights[0] + colors[1] * barymetricWeights[1] + colors[2] * barymetricWeights[2];
            Vector3 normal = normals[0] * barymetricWeights[0] + normals[1] * barymetricWeights[1] + normals[2] * barymetricWeights[2];
            Vector3 toLight = (globalData.LightPosition - new Vector3(scene.TransformToSceneCoords(bitmapPos))).Normalized;
            return CalculateLight(globalData.Ks,
                                   globalData.Kd,
                                   globalData.LightRGB,
                                   color,
                                   toLight,
                                   normal,
                                   globalData.M).ToColor();
        }
    }
}
