using System.Windows.Forms;

namespace WinformDotNetFramework.Forms.AddForms
{
    partial class CreateSaleForm
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
            this.saleDateDtp = new System.Windows.Forms.DateTimePicker();
            this.boltxt = new System.Windows.Forms.TextBox();
            this.bntxt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.StatusLbl = new System.Windows.Forms.Label();
            this.StatusCmbx = new System.Windows.Forms.ComboBox();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.OpenSale = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.CountryCmbxUC = new WinformDotNetFramework.Forms.control.DropDownMenuAutoCompleteUserControl();
            this.NameCmbxUC = new WinformDotNetFramework.Forms.control.DropDownMenuAutoCompleteUserControl();
            this.CustomerCountryLbl = new System.Windows.Forms.Label();
            this.CustomerNameLbl = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // saleDateDtp
            // 
            this.saleDateDtp.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saleDateDtp.Location = new System.Drawing.Point(115, 192);
            this.saleDateDtp.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.saleDateDtp.Name = "saleDateDtp";
            this.saleDateDtp.Size = new System.Drawing.Size(200, 23);
            this.saleDateDtp.TabIndex = 22;
            // 
            // boltxt
            // 
            this.boltxt.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boltxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.boltxt.Location = new System.Drawing.Point(115, 148);
            this.boltxt.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.boltxt.Name = "boltxt";
            this.boltxt.Size = new System.Drawing.Size(200, 23);
            this.boltxt.TabIndex = 21;
            this.boltxt.TextChanged += new System.EventHandler(this.NameTxt_TextChanged);
            // 
            // bntxt
            // 
            this.bntxt.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.bntxt.Location = new System.Drawing.Point(115, 102);
            this.bntxt.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.bntxt.Name = "bntxt";
            this.bntxt.Size = new System.Drawing.Size(200, 23);
            this.bntxt.TabIndex = 20;
            this.bntxt.TextChanged += new System.EventHandler(this.NameTxt_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.label4.Location = new System.Drawing.Point(115, 174);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 15);
            this.label4.TabIndex = 16;
            this.label4.Text = "Sale Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.label3.Location = new System.Drawing.Point(115, 130);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 15);
            this.label3.TabIndex = 15;
            this.label3.Text = "BoL Number";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.label2.Location = new System.Drawing.Point(115, 83);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 15);
            this.label2.TabIndex = 14;
            this.label2.Text = "Booking Number";
            // 
            // StatusLbl
            // 
            this.StatusLbl.AllowDrop = true;
            this.StatusLbl.AutoSize = true;
            this.StatusLbl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.StatusLbl.Location = new System.Drawing.Point(428, 177);
            this.StatusLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.StatusLbl.Name = "StatusLbl";
            this.StatusLbl.Size = new System.Drawing.Size(39, 15);
            this.StatusLbl.TabIndex = 29;
            this.StatusLbl.Text = "Status";
            // 
            // StatusCmbx
            // 
            this.StatusCmbx.AllowDrop = true;
            this.StatusCmbx.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusCmbx.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.StatusCmbx.FormattingEnabled = true;
            this.StatusCmbx.Items.AddRange(new object[] {
            "Active",
            "Closed"});
            this.StatusCmbx.Location = new System.Drawing.Point(428, 192);
            this.StatusCmbx.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.StatusCmbx.Name = "StatusCmbx";
            this.StatusCmbx.Size = new System.Drawing.Size(200, 23);
            this.StatusCmbx.TabIndex = 28;
            this.StatusCmbx.SelectedIndexChanged += new System.EventHandler(this.NameTxt_TextChanged);
            // 
            // SaveBtn
            // 
            this.SaveBtn.AllowDrop = true;
            this.SaveBtn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.SaveBtn.Location = new System.Drawing.Point(428, 238);
            this.SaveBtn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(200, 23);
            this.SaveBtn.TabIndex = 30;
            this.SaveBtn.Text = "Create Supplier Invoice Cost";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // OpenSale
            // 
            this.OpenSale.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(124)))), ((int)(((byte)(166)))));
            this.OpenSale.FlatAppearance.BorderSize = 0;
            this.OpenSale.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.OpenSale.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(245)))), ((int)(((byte)(247)))));
            this.OpenSale.Location = new System.Drawing.Point(635, 126);
            this.OpenSale.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.OpenSale.Name = "OpenSale";
            this.OpenSale.Size = new System.Drawing.Size(64, 23);
            this.OpenSale.TabIndex = 31;
            this.OpenSale.Text = "Open";
            this.OpenSale.UseVisualStyleBackColor = false;
            this.OpenSale.Click += new System.EventHandler(this.OpenSale_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(180)))), ((int)(((byte)(194)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(784, 20);
            this.panel1.TabIndex = 32;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(245)))), ((int)(((byte)(247)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.CountryCmbxUC);
            this.panel2.Controls.Add(this.NameCmbxUC);
            this.panel2.Controls.Add(this.CustomerCountryLbl);
            this.panel2.Controls.Add(this.CustomerNameLbl);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.OpenSale);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.SaveBtn);
            this.panel2.Controls.Add(this.StatusLbl);
            this.panel2.Controls.Add(this.bntxt);
            this.panel2.Controls.Add(this.StatusCmbx);
            this.panel2.Controls.Add(this.boltxt);
            this.panel2.Controls.Add(this.saleDateDtp);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(20, 20);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(744, 422);
            this.panel2.TabIndex = 33;
            // 
            // CountryCmbxUC
            // 
            this.CountryCmbxUC.listItemsDropCmbx = null;
            this.CountryCmbxUC.Location = new System.Drawing.Point(428, 148);
            this.CountryCmbxUC.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.CountryCmbxUC.Name = "CountryCmbxUC";
            this.CountryCmbxUC.Size = new System.Drawing.Size(201, 23);
            this.CountryCmbxUC.TabIndex = 44;
            // 
            // NameCmbxUC
            // 
            this.NameCmbxUC.listItemsDropCmbx = null;
            this.NameCmbxUC.Location = new System.Drawing.Point(428, 103);
            this.NameCmbxUC.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.NameCmbxUC.Name = "NameCmbxUC";
            this.NameCmbxUC.Size = new System.Drawing.Size(201, 24);
            this.NameCmbxUC.TabIndex = 43;
            // 
            // CustomerCountryLbl
            // 
            this.CustomerCountryLbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CustomerCountryLbl.AutoSize = true;
            this.CustomerCountryLbl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustomerCountryLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.CustomerCountryLbl.Location = new System.Drawing.Point(429, 130);
            this.CustomerCountryLbl.Name = "CustomerCountryLbl";
            this.CustomerCountryLbl.Size = new System.Drawing.Size(110, 15);
            this.CustomerCountryLbl.TabIndex = 42;
            this.CustomerCountryLbl.Text = "Customer Country*";
            // 
            // CustomerNameLbl
            // 
            this.CustomerNameLbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CustomerNameLbl.AutoSize = true;
            this.CustomerNameLbl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustomerNameLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.CustomerNameLbl.Location = new System.Drawing.Point(429, 85);
            this.CustomerNameLbl.Name = "CustomerNameLbl";
            this.CustomerNameLbl.Size = new System.Drawing.Size(99, 15);
            this.CustomerNameLbl.TabIndex = 39;
            this.CustomerNameLbl.Text = "Customer Name*";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(180)))), ((int)(((byte)(194)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 442);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(784, 20);
            this.panel3.TabIndex = 34;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(180)))), ((int)(((byte)(194)))));
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 20);
            this.panel4.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(20, 422);
            this.panel4.TabIndex = 35;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(180)))), ((int)(((byte)(194)))));
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(764, 20);
            this.panel5.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(20, 422);
            this.panel5.TabIndex = 36;
            // 
            // CreateSaleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 462);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "CreateSaleForm";
            this.Text = "CreateSaleForm";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public DateTimePicker saleDateDtp;
        public TextBox boltxt;
        public TextBox bntxt;
        public Label label4;
        public Label label3;
        public Label label2;
        public Label StatusLbl;
        public ComboBox StatusCmbx;
        public Button SaveBtn;
        public Button OpenSale;
        public Panel panel1;
        public Panel panel2;
        public Panel panel3;
        public Panel panel4;
        public Panel panel5;
        public Label CustomerCountryLbl;
        public Label CustomerNameLbl;
        public control.DropDownMenuAutoCompleteUserControl CountryCmbxUC;
        public control.DropDownMenuAutoCompleteUserControl NameCmbxUC;
    }
}