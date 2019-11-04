using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DrawingLibrary.Samplers
{
    public interface ISampler
    {
        Vector3 Sample(Vector2 UV);
        void Resize(int width, int height);
    }
}
