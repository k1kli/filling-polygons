using DrawingLibrary.Vectors;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingLibrary
{
    static class ExtensionMethods
    {
        public static void Sort<T>(this LinkedList<T> sortedList, Comparison<T> comparision)
        {
            if (sortedList.Count <= 1) return;
            LinkedList<T> greater = new LinkedList<T>();
            LinkedList<T> smaller = new LinkedList<T>();
            LinkedList<T> equal = new LinkedList<T>();
            equal.AddLast(sortedList.First());
            sortedList.RemoveFirst();
            while(sortedList.Count > 0)
            {
                T element = sortedList.First();
                sortedList.RemoveFirst();
                int comparisionResult = comparision.Invoke(element, equal.First());
                if(comparisionResult > 0)
                {
                    greater.AddLast(element);
                }
                else if(comparisionResult == 0)
                {
                    equal.AddLast(element);
                }
                else
                {
                    smaller.AddLast(element);
                }
            }
            greater.Sort(comparision);
            smaller.Sort(comparision);
            foreach (T el in smaller)
            {
                sortedList.AddLast(el);
            }
            foreach (T el in equal)
            {
                sortedList.AddLast(el);
            }
            foreach (T el in greater)
            {
                sortedList.AddLast(el);
            }
        }
        public static Vector3 ToVector3(this Color color)
        {
            uint argb = (uint)color.ToArgb();
            return new Vector3(
                (double)(argb >> 16 & 255) / 255,
                (double)(argb >> 8 & 255) / 255,
                (double)(argb & 255) / 255);
        }
        public static Color ToColor(this Vector3 vector3)
        {
            return Color.FromArgb((255 << 24)
                + ((int)(vector3.X * 255) << 16)
                + ((int)(vector3.Y * 255) << 8)
                + ((int)(vector3.Z * 255)));
        }
    }
}
