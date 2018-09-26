using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace MinArea
{
    /// <summary>
    /// The presenter class
    /// </summary>
    class Presenter
    {
        // min number of tops
        private static readonly int MIN_COUNT = 3;

        // max number of tops
        private static readonly int MAX_COUNT = 10;

        // the color of the figure
        private static Color _color = Color.Black;

        // point size in px
        private static int _pointSize = 3;

        // the font family of a point letter
        private static string _fontFamily = "Arial";

        // the font size of a point letter
        private static int _fontSize = 10;

        // 
        private static Pen _pen = new Pen(_color);

        //
        private static Font _font = new Font(_fontFamily, _fontSize);


        // the set of the names of the tops 
        private string[] _pointNames;

        // the index of the current name of the top
        private int _pNamesInd = 0;

        // the flag whether a figure was drawn
        private bool _wasDrawn = false;

        // the component to draw figures
        private Graphics _graphics;

        // random generator
        private Random _random = new Random();

        // main form (view)
        private IMainForm _mainForm;
        
        private IPolygonActions _polAct;

        /// <summary>
        /// A constructor
        /// </summary>
        /// <param name="form"></param>
        /// <param name="polAct"></param>
        public Presenter(IMainForm form, IPolygonActions polAct)
        {
            _mainForm = form;
            _polAct = polAct;
            _graphics = Graphics.FromHwnd(_mainForm.ForGraphics);
            _pointNames = new string[MAX_COUNT];
            for (int i = 0; i < MAX_COUNT - 1; ++i)
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

        /// <summary>
        /// Event handler to get help
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HelpEvent(object sender, EventArgs e)
        {
            Messages.ShowMessage("A left-click is used to put a top " +
                "on the surface.\n\r" +
                "To get a polygon with a minimal area press the button" +
                "\"Get polygon\".\n\r" +
                "It is also posible to put points randomly" +
                "press the button \"Random points\".\n\r" +
                "To clear the surface press \"Clear\".");
        }

        /// <summary>
        /// Event handler to generate random points
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Event handler to add a point
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddPointEvent(object sender, MouseEventArgs e)
        {
            if (_polAct.CountTops() == MAX_COUNT)
            {
                Messages.ShowWarning("It is impossible to add more points");
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

        /// <summary>
        /// Event handler to get a polygon with minimal area
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GetPolygonEvent(object sender, EventArgs e)
        {
            if (_polAct.CountTops() < MIN_COUNT)
            {
                Messages.ShowWarning("You need minimum 3 points");
                return;
            }
            var minPol = _polAct.GetMinAreaPolygon();
            if (minPol != null)
            {
                minPol.Draw(_graphics, _pen);
                _mainForm.SetArea(minPol.GetArea());
                _wasDrawn = true;
            }
            else
            {
                Messages.ShowError("It is impossible to get a polygon");
            }
        }

        /// <summary>
        /// Event handler to delete points
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearEvent(object sender, EventArgs e)
        {
            _polAct.ClearTops();
            ClearWorkSpace();
        }

        /// <summary>
        /// Clears the surface
        /// </summary>
        private void ClearWorkSpace()
        {
            _graphics.Clear(_mainForm.Background);
            _mainForm.SetArea(0);
            _wasDrawn = false;
            _pNamesInd = 0;
        }

        /// <summary>
        /// Draw a given point on the current graphics
        /// </summary>
        /// <param name="p">The point it is need to draw</param>
        /// <param name="pen">A pen to draw</param>
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
