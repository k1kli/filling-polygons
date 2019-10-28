using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingLibrary
{
    public struct LightParameters
    {
        public float Kd { get; set; }
        public float Ks { get; set; }
        public float M { get; set; }
        public static LightParameters GetRandom(Random r)
        {
            LightParameters res = new LightParameters();
            res.Kd = (float)r.NextDouble();
            res.Ks = (float)r.NextDouble();
            res.M = r.Next(1, 100);
            return res;
        }
    }
}
