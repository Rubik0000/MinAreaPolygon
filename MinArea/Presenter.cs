using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace MinArea
{
    class Presenter
    {
        private Graphics _graphics;
        private IMainForm _mainForm;
        private LinkedList<Point> _tops;

        public Presenter(IMainForm form)
        {
            _mainForm = form;
            _graphics = Graphics.FromHwnd(_mainForm.ForGraphics);
            _tops = new LinkedList<Point>();

            _mainForm.AddPoint += AddPointEvent;
            _mainForm.GetPolygon += GetPolygonEvent;
            _mainForm.Clear += ClearEvent;
        }

        private void AddPointEvent(object sender, MouseEventArgs e)
        {
            _tops.AddLast(new Point(e.X, e.Y));
            _graphics.DrawEllipse(new Pen(Color.Black), e.X, e.Y, 2, 2);
        }

        private void GetPolygonEvent(object sender, EventArgs e)
        {
            int minArea = int.MaxValue;
            Polygon minPol = null;

            Point[] points = _tops.ToArray();
            Point[] perm = new Point[points.Length - 1];
            Array.Copy(points, 1, perm, 0, perm.Length);
            var p = new Permutations<Point>();
            Point[] polTops = new Point[perm.Length + 1];
            polTops[0] = points[0];

            p.Generate(perm, per => {

                Array.Copy(perm, 0, polTops, 1, perm.Length);
                var pol = Polygon.CreatePolygon(polTops);
                if (pol == null) return;
                int area = pol.GetArea();
                if (area < minArea)
                {
                    minArea = area;
                    minPol = pol;
                }
            });
            minPol.Draw(_graphics, new Pen(Color.Black));
            _mainForm.setArea(minArea);
        }

        private void ClearEvent(object sender, EventArgs e)
        {
            _tops.Clear();
            _graphics.Clear(_mainForm.Background);
            _mainForm.setArea(0);
        }
    }
}
