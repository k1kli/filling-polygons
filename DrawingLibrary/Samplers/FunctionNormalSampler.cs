using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DrawingLibrary.Samplers
{
    public class FunctionNormalSampler : Sampler
    {
        Stopwatch stopwatch;
        public float A { get; set; }
        public float B { get; set; }
        public float C { get; set; }
        public float D { get; set; }
        public FunctionNormalSampler(float a, float b, float c, float d)
        {
            A = a;
            B = b;
            C = c;
            D = d;
            stopwatch = new Stopwatch();
            stopwatch.Start();
        }
        private double GetFuncValAt(float x, float y, float t)
        {
           // return Math.Sin(A * x / 20.0f + B * t) + Math.Sin(C * y / 20.0f + D * t);
            double arg =
                10000.0
                - Math.Pow(x - (100 * A + 100 * B * Math.Sin(t)), 2)
                - Math.Pow(y - (100 * C + 100 * D * Math.Cos(t)), 2);
            if (arg < 0) return 0;
            return Math.Sqrt(arg);
        }
        public override Vector3 Sample(Vector2 worldPosition)
        {
            float x = worldPosition.X;
            float y = worldPosition.Y;
            float t = stopwatch.ElapsedMilliseconds / 1000.0f;
            double xDerivative = (GetFuncValAt(x + 1, y, t) - GetFuncValAt(x - 1, y, t)) * 0.5;
            double yDerivative = (GetFuncValAt(x, y+1, t) - GetFuncValAt(x, y-1, t)) * 0.5;
            Vector3 normal = new Vector3(-(float)xDerivative, -(float)yDerivative, 1f);
            normal = Vector3.Normalize(normal);
            return normal;
        }
        public void SetFunctionNormalParams((float a, float b, float c, float d) funcParams)
        {
            A = funcParams.a;
            B = funcParams.b;
            C = funcParams.c;
            D = funcParams.d;
        }
    }
}
