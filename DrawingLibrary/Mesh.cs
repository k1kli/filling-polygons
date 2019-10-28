using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingLibrary
{
    public class Mesh
    {
        public Vectors.Vector2[] Vertices { get; set; }
        public Vectors.Vector2[] UV { get; set; }
        public int[] Triangles { get; set; }
        public LightParameters[] TrianglesLightParameters { get; set; }
    }
}
