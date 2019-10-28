using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingLibrary.Vectors
{
    public struct Vector2
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Vector2(double x, double y)
        {
            X = x;
            Y = y;
        }
        public double Magnitude =>
            (double)Math.Sqrt(MagnitudeSqr);
        public double MagnitudeSqr => X * X + Y * Y;
        public Vector2 GetPerpendicular()
        {
            return new Vector2(-this.Y, this.X);
        }
        public Vector2 Normalized => this / Magnitude;

        public static Vector2 operator +(in Vector2 v1, in Vector2 v2)
        {
            return new Vector2() { X = v1.X + v2.X, Y = v1.Y + v2.Y };
        }
        public static Vector2 operator -(in Vector2 v1, in Vector2 v2)
        {
            return new Vector2() { X = v1.X - v2.X, Y = v1.Y - v2.Y };
        }
        public static Vector2 operator -(in Vector2 v)
        {
            return new Vector2() { X = -v.X, Y = -v.Y };
        }
        public static Vector2 operator *(in Vector2 v, double factor)
        {
            return new Vector2() { X = v.X * factor, Y = v.Y * factor };
        }
        public static Vector2 operator *(double factor, in Vector2 v)
        {
            return v * factor;
        }
        public static Vector2 operator /(in Vector2 v, double factor)
        {
            return new Vector2() { X = v.X / factor, Y = v.Y / factor };
        }

        public static bool operator ==(in Vector2 v1, in Vector2 v2)
        {
            return v1.X == v2.X && v1.Y == v2.Y;
        }
        public static bool operator !=(in Vector2 v1, in Vector2 v2)
        {
            return v1.X != v2.X || v1.Y != v2.Y;
        }

        public static double DotProduct(in Vector2 v1, in Vector2 v2)
        {
            return v1.X * v2.X + v1.Y * v2.Y;
        }
        public static double CrossProduct(in Vector2 v1, in Vector2 v2)
        {
            return v1.X * v2.Y - v1.Y * v2.X;
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
