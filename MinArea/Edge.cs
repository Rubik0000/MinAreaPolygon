using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinArea
{
    class Edge : IDrawable
    {
        public Point P1 { get; private set; }
        public Point P2 { get; private set; }

        public Edge(Point p1, Point p2)
        {
            P1 = p1;
            P2 = p2;
        }

        private static bool EqualPoints(Point p1, Point p2) =>
            p1.X == p2.X && p1.Y == p2.Y;
        

        public static bool IsAdjacent(Edge ed1, Edge ed2) =>
            EqualPoints(ed1.P1, ed2.P1) ||
            EqualPoints(ed1.P1, ed2.P2) ||
            EqualPoints(ed1.P2, ed2.P1) ||
            EqualPoints(ed1.P2, ed2.P2);

        public static bool Interect(Edge ed1, Edge ed2) =>
            Interect(ed1.P1, ed1.P2, ed2.P1, ed2.P2);

        private static bool Interect(Point a1, Point a2, Point b1, Point b2)
        {
            int v1 = (b2.X - b1.X) * (a1.Y - b1.Y) -
                     (b2.Y - b1.Y) * (a1.X - b1.X);

            int v2 = (b2.X - b1.X) * (a2.Y - b1.Y) -
                     (b2.Y - b1.Y) * (a2.X - b1.X);

            int v3 = (a2.X - a1.X) * (b1.Y - a1.Y) -
                     (a2.Y - a1.Y) * (b1.X - a1.X);

            int v4 = (a2.X - a1.X) * (b2.Y - a1.Y) -
                     (a2.Y - a1.Y) * (b2.X - a1.X);
            return v1 * v2 < 0 && v3 * v4 < 0;
        }

        public void Draw(Graphics grp, Pen pen) =>
            grp.DrawLine(pen, P1, P2);
        
    }
}
