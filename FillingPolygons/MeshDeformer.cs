﻿using DrawingLibrary;
using DrawingLibrary.Vectors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FillingPolygons
{
    public class MeshDeformer
    {
        public Mesh Mesh { get; set; }

        public MeshDeformer(Mesh mesh)
        {
            this.Mesh = mesh;
        }
        private int selectedVertexId = -1;
        private Vector2 prevCursorPos;

        public void MouseDown(Vector2 sceneCursorPos)
        {
            selectedVertexId = FindSelectedVertex(sceneCursorPos);
            prevCursorPos = sceneCursorPos;
        }

        private static double toleranceSqr = 1;
        private int FindSelectedVertex(Vector2 sceneCursorPos)
        {
            double minDist = double.MaxValue;
            int minId = -1;
            for(int i = 0; i < Mesh.Vertices.Length; i++)
            {
                double dist = (sceneCursorPos - Mesh.Vertices[i]).MagnitudeSqr;
                if(dist < toleranceSqr && minDist > dist)
                {
                    minDist = dist;
                    minId = i;
                }
            }
            return minId;
        }

        public bool MouseMove(Vector2 sceneCursorPos)
        {
            if(selectedVertexId != -1)
            {
                Vector2 movement = sceneCursorPos - prevCursorPos;
                if(movement.MagnitudeSqr > double.Epsilon)
                {
                    Mesh.Vertices[selectedVertexId] += movement;
                    prevCursorPos = sceneCursorPos;
                    return true;
                }
            }
            return false;
        }
        public void MouseUp()
        {
            selectedVertexId = -1;
        }
    }
}
