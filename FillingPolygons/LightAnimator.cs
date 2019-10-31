using DrawingLibrary.Vectors;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace FillingPolygons
{
    class LightAnimator
    {
        Stopwatch stopwatch;
        private const int animationInterval = 5*1000;
        private float domeRadius;
        public LightAnimator(float domeRadius)
        {
            stopwatch = new Stopwatch();
            this.domeRadius = domeRadius;
        }
        public void StartAnimation()
        {
            stopwatch.Restart();
        }
        public Vector3 NextPos()
        {
            float t = (float)((float)(stopwatch.ElapsedMilliseconds % animationInterval) / animationInterval * Math.PI * 2);
            return new Vector3(X(t), Y(t), Z(t));
        }
        private float X(float t)
        {
            return domeRadius * (float)Math.Cos(t);
        }
        private float Y(float t)
        {
            return domeRadius * (float)Math.Sin(t);
        }
        private float Z(float t)
        {
            return domeRadius * (1f-(float)Math.Sin(t/2));
        }
    }
}
