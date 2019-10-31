using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace DrawingLibrary
{
    public class Mesh
    {
        public Vector2[] Vertices { get; set; }
        public Vector2[] UV { get; set; }
        public int[] Triangles { get; set; }
        public LightParameters[] TrianglesLightParameters { get; set; }
    }
}
