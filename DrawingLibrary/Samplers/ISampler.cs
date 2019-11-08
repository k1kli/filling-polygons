using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DrawingLibrary.Samplers
{
    public abstract class Sampler
    {
        public abstract Vector3 Sample(Vector2 UV);
        public virtual void Resize(int width, int height) { }
    }
}
