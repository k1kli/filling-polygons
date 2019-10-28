using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingLibrary.Vectors
{
    public struct Vector3
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public Vector3(float x, float y, float z = 0)
        {
            X = x;
            Y = y;
            Z = z;
        }
        public Vector3(in Vector2 v)
        {
            X = v.X;
            Y = v.Y;
            Z = 0;
        }
        public float Magnitude =>
            (float)Math.Sqrt(MagnitudeSqr);
        public float MagnitudeSqr => X * X + Y * Y + Z*Z;
        public Vector3 Normalized => this / Magnitude;

        public static Vector3 operator +(in Vector3 v1, in Vector3 v2)
        {
            return new Vector3() { X = v1.X + v2.X, Y = v1.Y + v2.Y, Z = v1.Z+v2.Z };
        }
        public static Vector3 operator -(in Vector3 v1, in Vector3 v2)
        {
            return new Vector3() { X = v1.X - v2.X, Y = v1.Y - v2.Y, Z = v1.Z - v2.Z };
        }
        public static Vector3 operator -(in Vector3 v)
        {
            return new Vector3() { X = -v.X, Y = -v.Y, Z = -v.Z };
        }
        public static Vector3 operator *(in Vector3 v, float factor)
        {
            return new Vector3() { X = v.X * factor, Y = v.Y * factor, Z = v.Z * factor };
        }
        public static Vector3 operator *(float factor, in Vector3 v)
        {
            return v * factor;
        }
        public static Vector3 operator /(in Vector3 v, float factor)
        {
            return new Vector3() { X = v.X / factor, Y = v.Y / factor, Z = v.Z / factor };
        }

        public static bool operator ==(in Vector3 v1, in Vector3 v2)
        {
            return v1.X == v2.X && v1.Y == v2.Y && v1.Z == v2.Z;
        }
        public static bool operator !=(in Vector3 v1, in Vector3 v2)
        {
            return !(v1 == v2);
        }

        public static float DotProduct(in Vector3 v1, in Vector3 v2)
        {
            return v1.X * v2.X + v1.Y * v2.Y + v1.Z*v2.Z;
        }
        public static Vector3 CrossProduct(in Vector3 v1, in Vector3 v2)
        {
            return new Vector3(v1.Y*v2.Z-v1.Z-v2.Y,v1.Z*v2.X-v1.X*v2.Z, v1.X*v2.Y-v1.Y*v2.X);
        }
        public static Vector3 CoordinateMultiplication(in Vector3 v1, in Vector3 v2)
        {
            return new Vector3(v1.X * v2.X, v1.Y * v2.Y, v1.Z * v2.Z);
        }

        public override bool Equals(object obj)
        {
            return obj is Vector2 vector &&
                   X == vector.X &&
                   Y == vector.Y;
        }

        public override int GetHashCode()
        {
            var hashCode = 1861411795;
            hashCode = hashCode * -1521134295 + X.GetHashCode();
            hashCode = hashCode * -1521134295 + Y.GetHashCode();
            return hashCode;
        }
    }
}
