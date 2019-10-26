﻿using DrawingLibrary.Vectors;
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
        public double Ks;
        public double Kd;
        public Vector3 LightRGB;
        public void SetLightColor(Color c)
        {
            LightRGB = c.ToVector3();
        }
        public Vector3 ToLightVersor;
        public double M;
        public GlobalData(double ks, double kd, Color lightColor, Vector3 toLightVersor, double m)
        {
            Ks = ks;
            Kd = kd;
            LightRGB = lightColor.ToVector3();
            ToLightVersor = toLightVersor;
            M = m;
        }
    }
}