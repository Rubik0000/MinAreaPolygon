using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MinArea
{
    public interface IPolygonActions
    {
        Polygon GetMinAreaPolygon();
        void AddTop(Point p);
        bool RemoveTop(Point p);
        bool ContainTop(Point p);
        void ClearTops();
        int CountTops();
    }

    class PolygonActions : IPolygonActions
    {
        private LinkedList<Point> _setOfTops;

        public PolygonActions()
        {
            _setOfTops = new LinkedList<Point>();
        }

        public PolygonActions(IEnumerable<Point> col)
        {
            _setOfTops = new LinkedList<Point>(col);
        }

        public void AddTop(Point p) => _setOfTops.AddLast(p);

        public bool ContainTop(Point p) => _setOfTops.Contains(p);

        public bool RemoveTop(Point p) => _setOfTops.Remove(p);

        public void ClearTops() => _setOfTops.Clear();

        public int CountTops() => _setOfTops.Count;

        public Polygon GetMinAreaPolygon()
        {
            var polTops = _setOfTops.ToArray();
            var perm = new Point[polTops.Length - 1];
            Array.Copy(polTops, 1, perm, 0, perm.Length);
            var permutations = new Permutations<Point>();

            int minArea = int.MaxValue;
            Polygon minPol = null;
            permutations.Generate(perm, way => {
                Array.Copy(perm, 0, polTops, 1, perm.Length);
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
    }
}
