using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingLibrary.Vectors
{
    public struct IntVector2
    {
        public int X { get; set; }
        public int Y { get; set; }

        public IntVector2(int x, int y)
        {
            X = x;
            Y = y;
        }
        public int Magnitude =>
            (int)Math.Sqrt(MagnitudeSqr);
        public int MagnitudeSqr => X * X + Y * Y;
        public IntVector2 GetPerpendicular()
        {
            return new IntVector2(-this.Y, this.X);
        }
        public IntVector2 Normalized => this / Magnitude;

        public static IntVector2 operator +(IntVector2 v1, IntVector2 v2)
        {
            return new IntVector2() { X = v1.X + v2.X, Y = v1.Y + v2.Y };
        }
        public static IntVector2 operator -(IntVector2 v1, IntVector2 v2)
        {
            return new IntVector2() { X = v1.X - v2.X, Y = v1.Y - v2.Y };
        }
        public static IntVector2 operator -(IntVector2 v)
        {
            return new IntVector2() { X = -v.X, Y = -v.Y };
        }
        public static IntVector2 operator *(IntVector2 v, double factor)
        {
            return new IntVector2() { X = (int)(v.X * factor), Y = (int)(v.Y * factor) };
        }
        public static IntVector2 operator *(double factor, IntVector2 v)
        {
            return v * factor;
        }
        public static IntVector2 operator /(IntVector2 v, double factor)
        {
            return new IntVector2() { X = (int)(v.X / factor), Y = (int)(v.Y / factor) };
        }

        public static bool operator ==(IntVector2 v1, IntVector2 v2)
        {
            return v1.X == v2.X && v1.Y == v2.Y;
        }
        public static bool operator !=(IntVector2 v1, IntVector2 v2)
        {
            return v1.X != v2.X || v1.Y != v2.Y;
        }

        public override bool Equals(object obj)
        {
            return obj is IntVector2 vector &&
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
