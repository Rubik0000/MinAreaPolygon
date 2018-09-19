using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MinArea
{
    public static class Utils
    {
        public static void Swap<T>(ref T a, ref T b)
        {
            T tmp = a;
            a = b;
            b = tmp;
        }

        /// <summary>
        /// Checks whether two points are equal
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns>True if they are equal or false if they are not</returns>
        public static bool EqualPoints(Point p1, Point p2) =>
            p1.X == p2.X && p1.Y == p2.Y;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a1"></param>
        /// <param name="a2"></param>
        /// <param name="b1"></param>
        /// <param name="b2"></param>
        /// <returns></returns>
        public static bool Interect(Point a1, Point a2, Point b1, Point b2)
        {
            if (a1.X >= a2.X)
                Utils.Swap(ref a1, ref a2);
            if (b1.X >= b2.X)
                Utils.Swap(ref b1, ref b2);
            int v1 = Math.Sign((long)(b2.X - b1.X) * (a1.Y - b1.Y) -
                     (long)(b2.Y - b1.Y) * (a1.X - b1.X));

            int v2 = Math.Sign((long)(b2.X - b1.X) * (a2.Y - b1.Y) -
                     (long)(b2.Y - b1.Y) * (a2.X - b1.X));

            int v3 = Math.Sign((long)(a2.X - a1.X) * (b1.Y - a1.Y) -
                     (long)(a2.Y - a1.Y) * (b1.X - a1.X));

            int v4 = Math.Sign((long)(a2.X - a1.X) * (b2.Y - a1.Y) -
                     (long)(a2.Y - a1.Y) * (b2.X - a1.X));
            return v1 * v2 < 0 && v3 * v4 < 0;
        }
    }
}
