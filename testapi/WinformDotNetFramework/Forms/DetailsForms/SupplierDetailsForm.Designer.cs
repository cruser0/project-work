using System.Windows.Forms;

namespace WinformDotNetFramework.Forms.DetailsForms
{
    partial class SupplierDetailsForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.SaveEditSupplierBtn = new System.Windows.Forms.Button();
            this.EditSupplierCbx = new System.Windows.Forms.CheckBox();
            this.CountrySupplierLbl = new System.Windows.Forms.Label();
            this.NameSupplierLbl = new System.Windows.Forms.Label();
            this.NameSupplierTxt = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CountryCmbx = new System.Windows.Forms.ComboBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // SaveEditSupplierBtn
            // 
            this.SaveEditSupplierBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SaveEditSupplierBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.SaveEditSupplierBtn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.SaveEditSupplierBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.SaveEditSupplierBtn.Location = new System.Drawing.Point(369, 330);
            this.SaveEditSupplierBtn.Name = "SaveEditSupplierBtn";
            this.SaveEditSupplierBtn.Size = new System.Drawing.Size(92, 25);
            this.SaveEditSupplierBtn.TabIndex = 16;
            this.SaveEditSupplierBtn.Text = "Save changes";
            this.SaveEditSupplierBtn.UseVisualStyleBackColor = false;
            this.SaveEditSupplierBtn.Click += new System.EventHandler(this.SaveEditSupplierBtn_Click);
            // 
            // EditSupplierCbx
            // 
            this.EditSupplierCbx.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.EditSupplierCbx.AutoSize = true;
            this.EditSupplierCbx.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditSupplierCbx.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.EditSupplierCbx.Location = new System.Drawing.Point(415, 305);
            this.EditSupplierCbx.Name = "EditSupplierCbx";
            this.EditSupplierCbx.Size = new System.Drawing.Size(46, 19);
            this.EditSupplierCbx.TabIndex = 15;
            this.EditSupplierCbx.Text = "Edit";
            this.EditSupplierCbx.UseVisualStyleBackColor = true;
            this.EditSupplierCbx.CheckedChanged += new System.EventHandler(this.EditSupplierCbx_CheckedChanged);
            // 
            // CountrySupplierLbl
            // 
            this.CountrySupplierLbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CountrySupplierLbl.AutoSize = true;
            this.CountrySupplierLbl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CountrySupplierLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.CountrySupplierLbl.Location = new System.Drawing.Point(261, 149);
            this.CountrySupplierLbl.Name = "CountrySupplierLbl";
            this.CountrySupplierLbl.Size = new System.Drawing.Size(50, 15);
            this.CountrySupplierLbl.TabIndex = 14;
            this.CountrySupplierLbl.Text = "Country";
            // 
            // NameSupplierLbl
            // 
            this.NameSupplierLbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.NameSupplierLbl.AutoSize = true;
            this.NameSupplierLbl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameSupplierLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.NameSupplierLbl.Location = new System.Drawing.Point(261, 105);
            this.NameSupplierLbl.Name = "NameSupplierLbl";
            this.NameSupplierLbl.Size = new System.Drawing.Size(39, 15);
            this.NameSupplierLbl.TabIndex = 13;
            this.NameSupplierLbl.Text = "Name";
            // 
            // NameSupplierTxt
            // 
            this.NameSupplierTxt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.NameSupplierTxt.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameSupplierTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.NameSupplierTxt.Location = new System.Drawing.Point(261, 123);
            this.NameSupplierTxt.MaxLength = 100;
            this.NameSupplierTxt.Name = "NameSupplierTxt";
            this.NameSupplierTxt.Size = new System.Drawing.Size(200, 23);
            this.NameSupplierTxt.TabIndex = 10;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(245)))), ((int)(((byte)(247)))));
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.CountryCmbx);
            this.panel1.Controls.Add(this.chart1);
            this.panel1.Controls.Add(this.NameSupplierTxt);
            this.panel1.Controls.Add(this.SaveEditSupplierBtn);
            this.panel1.Controls.Add(this.EditSupplierCbx);
            this.panel1.Controls.Add(this.NameSupplierLbl);
            this.panel1.Controls.Add(this.CountrySupplierLbl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(17, 17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(750, 427);
            this.panel1.TabIndex = 19;
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBox1.BackColor = System.Drawing.SystemColors.Window;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Active",
            "Deprecated"});
            this.comboBox1.Location = new System.Drawing.Point(261, 209);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(200, 21);
            this.comboBox1.TabIndex = 32;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.label1.Location = new System.Drawing.Point(261, 191);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 15);
            this.label1.TabIndex = 31;
            this.label1.Text = "Status";
            // 
            // CountryCmbx
            // 
            this.CountryCmbx.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CountryCmbx.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CountryCmbx.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CountryCmbx.BackColor = System.Drawing.SystemColors.Window;
            this.CountryCmbx.FormattingEnabled = true;
            this.CountryCmbx.Location = new System.Drawing.Point(261, 167);
            this.CountryCmbx.Name = "CountryCmbx";
            this.CountryCmbx.Size = new System.Drawing.Size(200, 21);
            this.CountryCmbx.TabIndex = 29;
            // 
            // chart1
            // 
            this.chart1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chart1.BackColor = System.Drawing.Color.Transparent;
            this.chart1.BorderlineColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Location = new System.Drawing.Point(494, 105);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(250, 250);
            this.chart1.TabIndex = 17;
            this.chart1.Text = "chart1";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(180)))), ((int)(((byte)(194)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(767, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(17, 461);
            this.panel2.TabIndex = 20;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(180)))), ((int)(((byte)(194)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(17, 461);
            this.panel3.TabIndex = 21;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(180)))), ((int)(((byte)(194)))));
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(17, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(750, 17);
            this.panel4.TabIndex = 22;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(180)))), ((int)(((byte)(194)))));
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(17, 444);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(750, 17);
            this.panel5.TabIndex = 23;
            // 
            // SupplierDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "SupplierDetailsForm";
            this.Text = "SupplierDetailsForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Button SaveEditSupplierBtn;
        private CheckBox EditSupplierCbx;
        private Label CountrySupplierLbl;
        private Label NameSupplierLbl;
        private TextBox NameSupplierTxt;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private ComboBox CountryCmbx;
        private ComboBox comboBox1;
        private Label label1;
    }
}