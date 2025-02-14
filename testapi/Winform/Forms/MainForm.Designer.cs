namespace Winform
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.CustomerStripButton = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowCustomersStripToolButton = new System.Windows.Forms.ToolStripMenuItem();
            this.AddCustomersStripToolButton = new System.Windows.Forms.ToolStripMenuItem();
            this.SuppliersStripToolButton = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowSuppliersStripToolButton = new System.Windows.Forms.ToolStripMenuItem();
            this.AddSuppliersStripToolButton = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CustomerStripButton,
            this.SuppliersStripToolButton});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1003, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // CustomerStripButton
            // 
            this.CustomerStripButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ShowCustomersStripToolButton,
            this.AddCustomersStripToolButton});
            this.CustomerStripButton.Name = "CustomerStripButton";
            this.CustomerStripButton.Size = new System.Drawing.Size(76, 20);
            this.CustomerStripButton.Text = "Customers";
            // 
            // ShowCustomersStripToolButton
            // 
            this.ShowCustomersStripToolButton.Name = "ShowCustomersStripToolButton";
            this.ShowCustomersStripToolButton.Size = new System.Drawing.Size(163, 22);
            this.ShowCustomersStripToolButton.Tag = "Show Customers";
            this.ShowCustomersStripToolButton.Text = "Show Customers";
            this.ShowCustomersStripToolButton.Click += new System.EventHandler(this.buttonOpenChild_Click);
            // 
            // AddCustomersStripToolButton
            // 
            this.AddCustomersStripToolButton.Name = "AddCustomersStripToolButton";
            this.AddCustomersStripToolButton.Size = new System.Drawing.Size(163, 22);
            this.AddCustomersStripToolButton.Text = "Add Customers";
            // 
            // SuppliersStripToolButton
            // 
            this.SuppliersStripToolButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ShowSuppliersStripToolButton,
            this.AddSuppliersStripToolButton});
            this.SuppliersStripToolButton.Name = "SuppliersStripToolButton";
            this.SuppliersStripToolButton.Size = new System.Drawing.Size(67, 20);
            this.SuppliersStripToolButton.Text = "Suppliers";
            // 
            // ShowSuppliersStripToolButton
            // 
            this.ShowSuppliersStripToolButton.Name = "ShowSuppliersStripToolButton";
            this.ShowSuppliersStripToolButton.Size = new System.Drawing.Size(154, 22);
            this.ShowSuppliersStripToolButton.Tag = "Show Suppliers";
            this.ShowSuppliersStripToolButton.Text = "Show Suppliers";
            this.ShowSuppliersStripToolButton.Click += new System.EventHandler(this.buttonOpenChild_Click);
            // 
            // AddSuppliersStripToolButton
            // 
            this.AddSuppliersStripToolButton.Name = "AddSuppliersStripToolButton";
            this.AddSuppliersStripToolButton.Size = new System.Drawing.Size(154, 22);
            this.AddSuppliersStripToolButton.Text = "Add Supplier";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1003, 762);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem CustomerStripButton;
        private ToolStripMenuItem ShowCustomersStripToolButton;
        private ToolStripMenuItem AddCustomersStripToolButton;
        private ToolStripMenuItem SuppliersStripToolButton;
        private ToolStripMenuItem ShowSuppliersStripToolButton;
        private ToolStripMenuItem AddSuppliersStripToolButton;
    }
}