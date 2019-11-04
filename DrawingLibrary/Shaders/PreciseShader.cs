using DrawingLibrary.Vectors;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace DrawingLibrary.Shaders
{
    public class PreciseShader : Shader
    {
        public override Color ForFragment(in Vector2 bitmapPos)
        {
            Vector3 color = MainTex.Sample(bitmapPos);
            Vector3 normal = Normals.Sample(bitmapPos);
            Vector3 toLight = Vector3.Normalize(globalData.LightPosition - new Vector3(scene.TransformToSceneCoords(bitmapPos), 0.0f));
            color = CalculateLight(globalData.LightRGB,
                                   color,
                                   toLight,
                                   normal,
                                   mesh.TrianglesLightParameters[triangleIndex]);
            return color.ToColor();
        }
    }
}
