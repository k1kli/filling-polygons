﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingLibrary.Vectors
{
    public struct Vector2
    {
        public float X { get; set; }
        public float Y { get; set; }

        public Vector2(float x, float y)
        {
            X = x;
            Y = y;
        }
        public float Magnitude =>
            (float)Math.Sqrt(MagnitudeSqr);
        public float MagnitudeSqr => X * X + Y * Y;
        public Vector2 GetPerpendicular()
        {
            return new Vector2(-this.Y, this.X);
        }
        public Vector2 Normalized => this / Magnitude;

        public static Vector2 operator +(Vector2 v1, Vector2 v2)
        {
            return new Vector2() { X = v1.X + v2.X, Y = v1.Y + v2.Y };
        }
        public static Vector2 operator -(Vector2 v1, Vector2 v2)
        {
            return new Vector2() { X = v1.X - v2.X, Y = v1.Y - v2.Y };
        }
        public static Vector2 operator -(Vector2 v)
        {
            return new Vector2() { X = -v.X, Y = -v.Y };
        }
        public static Vector2 operator *(Vector2 v, float factor)
        {
            return new Vector2() { X = v.X * factor, Y = v.Y * factor };
        }
        public static Vector2 operator *(float factor, Vector2 v)
        {
            return v * factor;
        }
        public static Vector2 operator /(Vector2 v, float factor)
        {
            return new Vector2() { X = v.X / factor, Y = v.Y / factor };
        }

        public static bool operator ==(Vector2 v1, Vector2 v2)
        {
            return v1.X == v2.X && v1.Y == v2.Y;
        }
        public static bool operator !=(Vector2 v1, Vector2 v2)
        {
            return v1.X != v2.X || v1.Y != v2.Y;
        }

        public static float DotProduct(Vector2 v1, Vector2 v2)
        {
            return v1.X * v2.X + v1.Y * v2.Y;
        }
        public static float CrossProduct(Vector2 v1, Vector2 v2)
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
