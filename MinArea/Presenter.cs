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
        private static readonly int MIN_COUNT = 3;
        private static readonly int MAX_COUNT = 10;
        private static Color _color = Color.Black;
        private static int _pointSize = 3;
        private static string _fontFamily = "Arial";
        private static int _fontSize = 10;
        private static Pen _pen = new Pen(_color);
        private static Font _font = new Font(_fontFamily, _fontSize);

        private string[] _pointNames;
        private int _pNamesInd = 0;
        private bool _wasDrawn = false;
        private Graphics _graphics;
        private Random _random = new Random();
        private IMainForm _mainForm;
        private IPolygonActions _polAct;

        public Presenter(IMainForm form, IPolygonActions polAct)
        {
            _mainForm = form;
            _polAct = polAct;
            _graphics = Graphics.FromHwnd(_mainForm.ForGraphics);
            _pointNames = new string[26];
            for (int i = 0; i < 26; ++i)
            {
                _pointNames[i] = ((char)(i + 'A')).ToString();
            }

            _mainForm.AddPoint += AddPointEvent;
            _mainForm.Clear += ClearEvent;
            _mainForm.RandomPoints += ClearEvent;
            _mainForm.RandomPoints += RandomPointsEvent;

            _mainForm.GetPolygon += GetPolygonEvent;

            _mainForm.Help += HelpEvent;
        }

        private void HelpEvent(object sender, EventArgs e)
        {
            Messages.ShowMessage(
                "ЛКМ - установка вершины\r\n" +
                "При нажатии на кнопку \"Найти многоуг.\" будет построен" +
                "многоугольник с минимальной площадью");
        }

        private void RandomPointsEvent(object sender, EventArgs e)
        {
            if (_mainForm.CountRandomPoints > MAX_COUNT)
                _mainForm.CountRandomPoints = MAX_COUNT;
            for (int i = 0; i < _mainForm.CountRandomPoints; ++i)
            {
                int x = _random.Next(0, _mainForm.WorkSpaceWidth - _fontSize);
                int y = _random.Next(_fontSize, _mainForm.WorkSpaceHeight);
                Point p = new Point(x, y);
                _polAct.AddTop(p);
                DrawPoint(p, _pen);
                ++_pNamesInd;
            }
        }

        private void AddPointEvent(object sender, MouseEventArgs e)
        {
            if (_polAct.CountTops() == MAX_COUNT)
            {
                Messages.ShowWarning("Невозможно добавить больше точек");
                return;
            }
            if (_wasDrawn)
            {
                ClearWorkSpace();
                foreach(Point point in _polAct)
                {
                    DrawPoint(point, _pen);
                    ++_pNamesInd;
                }
            }
            Point p = new Point(e.X, e.Y);
            _polAct.AddTop(p);
            DrawPoint(p, _pen);
            ++_pNamesInd;
        }

        private void GetPolygonEvent(object sender, EventArgs e)
        {
            if (_polAct.CountTops() < MIN_COUNT)
            {
                Messages.ShowWarning("Для построения многоугольника " +
                    "необходимо минимум 3 точки");
                return;
            }
            var minPol = _polAct.GetMinAreaPolygon();
            if (minPol != null)
            {
                minPol.Draw(_graphics, _pen);
                _mainForm.setArea(minPol.GetArea());
                _wasDrawn = true;
            }
            else
            {
                Messages.ShowError("Невозможно построить многоугольник");
            }
        }

        private void ClearEvent(object sender, EventArgs e)
        {
            _polAct.ClearTops();
            ClearWorkSpace();
        }

        private void ClearWorkSpace()
        {
            _graphics.Clear(_mainForm.Background);
            _mainForm.setArea(0);
            _wasDrawn = false;
            _pNamesInd = 0;
        }

        private void DrawPoint(Point p, Pen pen)
        {
            _graphics.DrawEllipse(pen, p.X, p.Y, _pointSize, _pointSize);
            _graphics.DrawString(
                _pointNames[_pNamesInd],
                _font, 
                pen.Brush, 
                p.X - _fontSize / 2, 
                p.Y - 1.5f * _fontSize);
        }
    }
}
