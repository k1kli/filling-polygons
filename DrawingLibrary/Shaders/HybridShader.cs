﻿using DrawingLibrary.Vectors;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DrawingLibrary.Shaders
{
    public class HybridShader:Shader
    {
        private Vector2[] vertices = new Vector2[3];
        private Vector3[] colors = new Vector3[3];
        private Vector3[] normals = new Vector3[3];
        int i;
        public override void StartTriangle(int triangleIndex)
        {
            base.StartTriangle(triangleIndex);
            i = 0;
        }
        public override void ForVertex(in Vector2 vertex)
        {
            vertices[i] = vertex;
            colors[i] = MainTex.Sample(vertex);
            normals[i] = Normals.Sample(vertex);
            i++;
        }
        public override Color ForFragment(in Vector2 bitmapPos)
        {
            float[] barymetricWeights = new float[3];
            GetBarymetricWeights(vertices, barymetricWeights, bitmapPos);
            Vector3 color = 
                colors[0] * barymetricWeights[0]
                + colors[1] * barymetricWeights[1]
                + colors[2] * barymetricWeights[2];
            Vector3 normal = normals[0] * barymetricWeights[0]
                + normals[1] * barymetricWeights[1]
                + normals[2] * barymetricWeights[2];
            Vector3 toLight = Vector3.Normalize(
                globalData.LightPosition - new Vector3(scene.TransformToSceneCoords(bitmapPos),0));
            return CalculateLight(globalData.LightRGB,
                                   color,
                                   toLight,
                                   normal,
                                   mesh.TrianglesLightParameters[triangleIndex]).ToColor();
        }
    }
}
