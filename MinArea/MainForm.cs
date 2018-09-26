using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinArea
{
    /// <summary>
    /// The public interface of the main form
    /// </summary>
    public interface IMainForm
    {
        /// <summary>A component to create graphics</summary>
        IntPtr ForGraphics { get; }

        /// <summary>
        /// Sets polygon's area
        /// </summary>
        /// <param name="area">An area</param>
        void SetArea(int area);

        /// <summary>Background color of the workspace</summary>
        Color Background { get; }

        /// <summary>The count of tops need to get randomly</summary>
        int CountRandomPoints { get; set; }

        /// <summary>The width of the workspace in px</summary>
        int WorkSpaceWidth { get; }

        /// <summary>The height of the workspace in px</summary>
        int WorkSpaceHeight { get; }

        /// <summary>An event to add point</summary>
        event MouseEventHandler AddPoint;

        /// <summary>An event to get random points</summary>
        event EventHandler RandomPoints;

        /// <summary>An event to create a polygon</summary>
        event EventHandler GetPolygon;

        /// <summary>An event to clear the workspace</summary>
        event EventHandler Clear;

        /// <summary>An event to get help</summary>
        event EventHandler Help;
    }

    /// <summary>
    /// The main form class
    /// </summary>
    public partial class MainForm : Form, IMainForm
    {
        /// <summary>
        /// A Constructor
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>Overload</summary>
        public IntPtr ForGraphics => pctrBxMain.Handle;

        /// <summary>Overload</summary>
        public Color Background => pctrBxMain.BackColor;

        /// <summary>Overload</summary>
        public int CountRandomPoints
        {
            get => (int) nmrcRandom.Value;
            set => nmrcRandom.Value = value;
        }

        /// <summary>Overload</summary>
        public int WorkSpaceWidth => pctrBxMain.Width;

        /// <summary>Overload</summary>
        public int WorkSpaceHeight => pctrBxMain.Height;

        /// <summary>Overload</summary>
        public event MouseEventHandler AddPoint;

        /// <summary>Overload</summary>
        public event EventHandler GetPolygon;

        /// <summary>Overload</summary>
        public event EventHandler Clear;

        /// <summary>Overload</summary>
        public event EventHandler Help;

        /// <summary>Overload</summary>
        public event EventHandler RandomPoints;

        /// <summary>Overload</summary>
        public void SetArea(int area) => 
            txtBxArea.Text = area.ToString();
       
        /// <summary>
        /// A Click on the workspace
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pctrBxMain_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                AddPoint?.Invoke(sender, e);
        }

        /// <summary>
        /// A Click on the button to create polygon
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFindPolygon_Click(object sender, EventArgs e) =>
            GetPolygon?.Invoke(sender, e);

        /// <summary>
        /// A Click on the button to clear the workspace
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e) =>
            Clear?.Invoke(sender, e);

        /// <summary>
        /// A Click on the button ot get help
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHelp_Click(object sender, EventArgs e) =>
            Help?.Invoke(sender, e);

        /// <summary>
        /// A Click on the button to get random tops
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRandom_Click(object sender, EventArgs e) =>
            RandomPoints?.Invoke(sender, e);

        /// <summary>
        /// The hot key "enter" to get a polygon
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                GetPolygon(this, EventArgs.Empty);
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
