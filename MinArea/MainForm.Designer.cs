namespace MinArea
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pctrBxMain = new System.Windows.Forms.PictureBox();
            this.btnFindPolygon = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.txtBxArea = new System.Windows.Forms.TextBox();
            this.lblArea = new System.Windows.Forms.Label();
            this.btnRandom = new System.Windows.Forms.Button();
            this.nmrcRandom = new System.Windows.Forms.NumericUpDown();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblCountRandTops = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pctrBxMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrcRandom)).BeginInit();
            this.SuspendLayout();
            // 
            // pctrBxMain
            // 
            this.pctrBxMain.BackColor = System.Drawing.SystemColors.Control;
            this.pctrBxMain.Location = new System.Drawing.Point(12, 12);
            this.pctrBxMain.Name = "pctrBxMain";
            this.pctrBxMain.Size = new System.Drawing.Size(527, 371);
            this.pctrBxMain.TabIndex = 0;
            this.pctrBxMain.TabStop = false;
            this.pctrBxMain.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pctrBxMain_MouseClick);
            // 
            // btnFindPolygon
            // 
            this.btnFindPolygon.Location = new System.Drawing.Point(545, 94);
            this.btnFindPolygon.Name = "btnFindPolygon";
            this.btnFindPolygon.Size = new System.Drawing.Size(122, 23);
            this.btnFindPolygon.TabIndex = 1;
            this.btnFindPolygon.Text = "Get polygon";
            this.btnFindPolygon.UseVisualStyleBackColor = true;
            this.btnFindPolygon.Click += new System.EventHandler(this.btnFindPolygon_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(545, 12);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(122, 23);
            this.btnHelp.TabIndex = 2;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // txtBxArea
            // 
            this.txtBxArea.Location = new System.Drawing.Point(545, 67);
            this.txtBxArea.Name = "txtBxArea";
            this.txtBxArea.ReadOnly = true;
            this.txtBxArea.Size = new System.Drawing.Size(122, 20);
            this.txtBxArea.TabIndex = 3;
            // 
            // lblArea
            // 
            this.lblArea.AutoSize = true;
            this.lblArea.Location = new System.Drawing.Point(542, 52);
            this.lblArea.Name = "lblArea";
            this.lblArea.Size = new System.Drawing.Size(32, 13);
            this.lblArea.TabIndex = 4;
            this.lblArea.Text = "Area:";
            // 
            // btnRandom
            // 
            this.btnRandom.Location = new System.Drawing.Point(545, 183);
            this.btnRandom.Name = "btnRandom";
            this.btnRandom.Size = new System.Drawing.Size(122, 23);
            this.btnRandom.TabIndex = 5;
            this.btnRandom.Text = "Random points";
            this.btnRandom.UseVisualStyleBackColor = true;
            this.btnRandom.Click += new System.EventHandler(this.btnRandom_Click);
            // 
            // nmrcRandom
            // 
            this.nmrcRandom.Location = new System.Drawing.Point(545, 157);
            this.nmrcRandom.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nmrcRandom.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nmrcRandom.Name = "nmrcRandom";
            this.nmrcRandom.Size = new System.Drawing.Size(120, 20);
            this.nmrcRandom.TabIndex = 6;
            this.nmrcRandom.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(545, 228);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(122, 23);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblCountRandTops
            // 
            this.lblCountRandTops.AutoSize = true;
            this.lblCountRandTops.Location = new System.Drawing.Point(545, 141);
            this.lblCountRandTops.Name = "lblCountRandTops";
            this.lblCountRandTops.Size = new System.Drawing.Size(122, 13);
            this.lblCountRandTops.TabIndex = 8;
            this.lblCountRandTops.Text = "The num. of rand. points";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(676, 395);
            this.Controls.Add(this.lblCountRandTops);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.nmrcRandom);
            this.Controls.Add(this.btnRandom);
            this.Controls.Add(this.lblArea);
            this.Controls.Add(this.txtBxArea);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnFindPolygon);
            this.Controls.Add(this.pctrBxMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "MainForm";
            this.Text = "MinArea";
            ((System.ComponentModel.ISupportInitialize)(this.pctrBxMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrcRandom)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pctrBxMain;
        private System.Windows.Forms.Button btnFindPolygon;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.TextBox txtBxArea;
        private System.Windows.Forms.Label lblArea;
        private System.Windows.Forms.Button btnRandom;
        private System.Windows.Forms.NumericUpDown nmrcRandom;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblCountRandTops;
    }
}

