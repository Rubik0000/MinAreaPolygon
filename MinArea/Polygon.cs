using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MinArea
{
    /// <summary>
    /// Represents a polygon
    /// </summary>
    public class Polygon : IDrawable
    {
        /// <summary>The set of edges</summary>
        private Edge[] _edges;

        /// <summary>The set of tops</summary>
        private Point[] _tops;

        /// <summary>
        /// A close constructor
        /// Objects are created with a factory method
        /// </summary>
        protected Polygon() {}

        /// <summary>
        /// The factory method that creates an polygon if it is possible
        /// and returns null if it is not
        /// </summary>
        /// <param name="tops">
        /// Tops of a polygon on which it needs to get polygon
        /// Points must be in order they will be linked in edges
        /// </param>
        /// <returns>A created polygon or null</returns>
        public static Polygon CreatePolygon(Point[] tops)
        {
            Polygon polygon = new Polygon();
            polygon._tops = tops;
            polygon._edges = new Edge[tops.Length];
            for (int i = 0; i < tops.Length - 1; ++i)
            {
                polygon._edges[i] = new Edge(tops[i], tops[i + 1]);
            }
            polygon._edges[tops.Length - 1] = 
                new Edge(tops[tops.Length - 1], tops[0]);

            //veryfying on intersecting
            for (int i = 0; i < polygon._edges.Length; ++i)
            {
                for (int j = 0; j < polygon._edges.Length; ++j)
                {
                    if (i != j && !Edge.IsAdjacent(polygon._edges[i], polygon._edges[j]) &&
                        Edge.Intersect(polygon._edges[i], polygon._edges[j]))
                    {
                        return null;
                    }
                }
            }
            return polygon;
        }

        /// <summary>Overload</summary>
        public void Draw(Graphics grp, Pen pen)
        {
            foreach(var ed in _edges)
            {
                ed.Draw(grp, pen);
            }
        }

        /// <summary>
        /// Returns the area of the polygon
        /// using Gauss's area formula
        /// </summary>
        /// <returns>The area of the polygon</returns>
        public int GetArea()
        {
            int s1 = 0;
            int s2 = 0;
            for (int i = 0; i < _tops.Length - 1; ++i)
            {
                s1 += _tops[i].X * _tops[i + 1].Y;
                s2 += _tops[i + 1].X * _tops[i].Y;
            }
            s1 += _tops[_tops.Length - 1].X * _tops[0].Y;
            s2 += _tops[0].X * _tops[_tops.Length - 1].Y;
            return Math.Abs(s1 - s2) / 2;
        }
    }
}
