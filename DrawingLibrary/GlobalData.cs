using DrawingLibrary.Vectors;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingLibrary
{
    public struct GlobalData
    {
        public Vector3 LightRGB;
        public void SetLightColor(Color c)
        {
            LightRGB = c.ToVector3();
        }
        public Vector3 LightPosition;
        public GlobalData(Color lightColor, Vector3 lightPosition)
        {
            LightRGB = lightColor.ToVector3();
            LightPosition = lightPosition;
        }
    }
}
