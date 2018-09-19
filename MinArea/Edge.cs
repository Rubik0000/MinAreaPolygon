using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinArea
{
    /// <summary>
    /// Represents an edge between points
    /// </summary>
    class Edge : IDrawable
    {
        /// <summary>
        /// The first point
        /// </summary>
        public Point P1 { get; private set; }

        /// <summary>
        /// The second point
        /// </summary>
        public Point P2 { get; private set; }

        /// <summary>
        /// A constructor
        /// </summary>
        /// <param name="p1">A first point</param>
        /// <param name="p2">A second point</param>
        public Edge(Point p1, Point p2)
        {
            P1 = p1;
            P2 = p2;
        }

        /// <summary>
        /// Checks whether two edges are adjacent
        /// </summary>
        /// <param name="ed1">The first edge</param>
        /// <param name="ed2">The second edge</param>
        /// <returns>True if they are adjacent or false if they are not</returns>
        public static bool IsAdjacent(Edge ed1, Edge ed2) =>
            Utils.EqualPoints(ed1.P1, ed2.P1) ||
            Utils.EqualPoints(ed1.P1, ed2.P2) ||
            Utils.EqualPoints(ed1.P2, ed2.P1) ||
            Utils.EqualPoints(ed1.P2, ed2.P2);

        /// <summary>
        /// Checks whether two edges intersect
        /// It implies that they are not adjacent
        /// </summary>
        /// <param name="ed1"></param>
        /// <param name="ed2"></param>
        /// <returns>True if they intersect or false if they don't</returns>
        public static bool Intersect(Edge ed1, Edge ed2) =>
            Utils.Interect(ed1.P1, ed1.P2, ed2.P1, ed2.P2);

        /// <summary>
        /// Overload
        /// </summary>     
        public void Draw(Graphics grp, Pen pen) =>
            grp.DrawLine(pen, P1, P2);
    }
}
