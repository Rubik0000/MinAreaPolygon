﻿using System;
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
    public interface IMainForm
    {
        IntPtr ForGraphics { get; }
        void setArea(int area);
        Color Background { get; }
        event MouseEventHandler AddPoint;
        event MouseEventHandler RemovePoint;
        event EventHandler GetPolygon;
        event EventHandler Clear;
        event EventHandler Help;
    }

    public partial class MainForm : Form, IMainForm
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public IntPtr ForGraphics => pctrBxMain.Handle;

        public Color Background => pctrBxMain.BackColor;

        public event MouseEventHandler AddPoint;
        public event MouseEventHandler RemovePoint;
        public event EventHandler GetPolygon;
        public event EventHandler Clear;
        public event EventHandler Help;

        public void setArea(int area) => 
            txtBxArea.Text = area.ToString();
       

        private void pctrBxMain_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                AddPoint?.Invoke(sender, e);
            }
            else if (e.Button == MouseButtons.Right)
            {
                RemovePoint?.Invoke(sender, e);
            }
        }

        private void btnFindPolygon_Click(object sender, EventArgs e) =>
            GetPolygon?.Invoke(sender, e);

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear?.Invoke(sender, e);
        }
    }
}