using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Collections;

namespace MinArea
{
    /// <summary>
    /// An interface provides actions above polygons
    /// </summary>
    public interface IPolygonActions : IEnumerable
    {
        /// <summary>
        /// Gets a polygon with min area from existing held tops
        /// </summary>
        /// <returns>The polygon or null if it is impossible to create</returns>
        Polygon GetMinAreaPolygon();

        /// <summary>
        /// Add a tops to the set
        /// </summary>
        /// <param name="p">A point need to add</param>
        void AddTop(Point p);

        /// <summary>
        /// Removes a top
        /// </summary>
        /// <param name="p">A point need to remove</param>
        /// <returns>True if removing was succesful or false if it was not</returns>
        bool RemoveTop(Point p);

        /// <summary>
        /// Checks whether a top is held
        /// </summary>
        /// <param name="p">The top need to check</param>
        /// <returns>True if the set has the top</returns>
        bool ContainTop(Point p);

        /// <summary>
        /// Clears the set of tops
        /// </summary>
        void ClearTops();

        /// <summary>
        /// Gets the number of held tops
        /// </summary>
        /// <returns>The number of the tops</returns>
        int CountTops();
    }

    public class PolygonActions : IPolygonActions
    {
        ///<summary>The set of tops</summary>
        private LinkedList<Point> _setOfTops;

        /// <summary>
        /// A constructor, the set is empty
        /// </summary>
        public PolygonActions()
        {
            _setOfTops = new LinkedList<Point>();
        }

        /// <summary>
        /// Gets points form a collection
        /// </summary>
        /// <param name="col">The collection of the tops</param>
        public PolygonActions(IEnumerable<Point> col)
        {
            _setOfTops = new LinkedList<Point>(col);
        }

        /// <summary>Overload</summary>
        public void AddTop(Point p) => _setOfTops.AddLast(p);

        /// <summary>Overload</summary>
        public bool ContainTop(Point p) => _setOfTops.Contains(p);

        /// <summary>Overload</summary>
        public bool RemoveTop(Point p) => _setOfTops.Remove(p);

        /// <summary>Overload</summary>
        public void ClearTops() => _setOfTops.Clear();

        /// <summary>Overload</summary>
        public int CountTops() => _setOfTops.Count;

        /// <summary>Overload</summary>
        public Polygon GetMinAreaPolygon()
        {
            var polTops = _setOfTops.ToArray();
            var perm = new Point[polTops.Length - 1];
            Array.Copy(polTops, 1, perm, 0, perm.Length);
            var permutations = new Permutations<Point>();

            int minArea = int.MaxValue;
            Polygon minPol = null;
            permutations.Generate(perm, way => {
                Array.Copy(way, 0, polTops, 1, way.Length);
                var polygon = Polygon.CreatePolygon(polTops);
                if (polygon == null) return;
                int area = polygon.GetArea();
                if (area < minArea)
                {
                    minArea = area;
                    minPol = polygon;
                }
            });
            return minPol;
        }

        public IEnumerator GetEnumerator()
        {
            foreach(var p in _setOfTops)
            {
                yield return p;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
