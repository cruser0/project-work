namespace WinformDotNetFramework.Forms.control
{
    partial class GraphDropDownMenuUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GraphDropDownMenuUserControl));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.DropDownMenuTS = new System.Windows.Forms.ToolStripDropDownButton();
            this.PieTSB = new System.Windows.Forms.ToolStripMenuItem();
            this.BarTSB = new System.Windows.Forms.ToolStripMenuItem();
            this.HorizontalBarTSB = new System.Windows.Forms.ToolStripMenuItem();
            this.LineTSB = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DropDownMenuTS});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(220, 25);
            this.toolStrip1.TabIndex = 9;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // DropDownMenuTS
            // 
            this.DropDownMenuTS.AutoSize = false;
            this.DropDownMenuTS.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PieTSB,
            this.BarTSB,
            this.HorizontalBarTSB,
            this.LineTSB});
            this.DropDownMenuTS.Image = ((System.Drawing.Image)(resources.GetObject("DropDownMenuTS.Image")));
            this.DropDownMenuTS.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DropDownMenuTS.Name = "DropDownMenuTS";
            this.DropDownMenuTS.Size = new System.Drawing.Size(188, 22);
            this.DropDownMenuTS.Text = "Menu";
            // 
            // PieTSB
            // 
            this.PieTSB.Image = global::WinformDotNetFramework.Properties.Resources.PieChart_removebg_preview;
            this.PieTSB.Name = "PieTSB";
            this.PieTSB.Size = new System.Drawing.Size(187, 30);
            this.PieTSB.Text = "Pie";
            // 
            // BarTSB
            // 
            this.BarTSB.Image = global::WinformDotNetFramework.Properties.Resources.BarChart_nobg;
            this.BarTSB.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BarTSB.Name = "BarTSB";
            this.BarTSB.Size = new System.Drawing.Size(187, 30);
            this.BarTSB.Text = "Bar";
            // 
            // HorizontalBarTSB
            // 
            this.HorizontalBarTSB.Image = global::WinformDotNetFramework.Properties.Resources.HorizontalChart_removebg_preview;
            this.HorizontalBarTSB.Name = "HorizontalBarTSB";
            this.HorizontalBarTSB.Size = new System.Drawing.Size(187, 30);
            this.HorizontalBarTSB.Text = "Horizontal Bar";
            // 
            // LineTSB
            // 
            this.LineTSB.Image = global::WinformDotNetFramework.Properties.Resources.LineChart_removebg_preview;
            this.LineTSB.Name = "LineTSB";
            this.LineTSB.Size = new System.Drawing.Size(187, 30);
            this.LineTSB.Text = "Line";
            // 
            // GraphDropDownMenuUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStrip1);
            this.Name = "GraphDropDownMenuUserControl";
            this.Size = new System.Drawing.Size(188, 22);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip toolStrip1;
        public System.Windows.Forms.ToolStripDropDownButton DropDownMenuTS;
        public System.Windows.Forms.ToolStripMenuItem PieTSB;
        public System.Windows.Forms.ToolStripMenuItem BarTSB;
        public System.Windows.Forms.ToolStripMenuItem HorizontalBarTSB;
        public System.Windows.Forms.ToolStripMenuItem LineTSB;
    }
}
