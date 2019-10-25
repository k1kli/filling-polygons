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
        public uint argb { get; set; }
        public Color Color { get => Color.FromArgb((int)argb); set => argb = (uint)value.ToArgb(); }

        public StaticColorSampler(Color color)
        {
            Color = color;
        }

        public uint Sample(Vector2 UV)
        {
            return argb ;
        }
    }
}
