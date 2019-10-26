using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrawingLibrary.Vectors;

namespace DrawingLibrary.Samplers
{
    public class StaticColorSampler : ISampler
    {
        private Vector3 color;
        public Color Color { get => color.ToColor(); set => color = value.ToVector3(); }

        public StaticColorSampler(Color color)
        {
            Color = color;
        }

        public Vector3 Sample(Vector2 UV)
        {
            return color;
        }
    }
}
