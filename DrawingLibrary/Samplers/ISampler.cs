﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingLibrary.Samplers
{
    public interface ISampler
    {
        Vectors.Vector3 Sample(Vectors.Vector2 UV);
    }
}
