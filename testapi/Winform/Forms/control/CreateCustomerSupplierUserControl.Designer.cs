namespace Winform.Forms.control
{
    partial class CreateCustomerSupplierUserControl
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
            this.CreateSaveBtn = new System.Windows.Forms.Button();
            this.CreateCountryLbl = new System.Windows.Forms.Label();
            this.CreateNameLbl = new System.Windows.Forms.Label();
            this.CreateCountryTxt = new System.Windows.Forms.TextBox();
            this.CreateNameTxt = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // CreateSaveBtn
            // 
            this.CreateSaveBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CreateSaveBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.CreateSaveBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.CreateSaveBtn.Location = new System.Drawing.Point(365, 253);
            this.CreateSaveBtn.Name = "CreateSaveBtn";
            this.CreateSaveBtn.Size = new System.Drawing.Size(107, 23);
            this.CreateSaveBtn.TabIndex = 22;
            this.CreateSaveBtn.Text = "Save changes";
            this.CreateSaveBtn.UseVisualStyleBackColor = false;
            this.CreateSaveBtn.Click += new System.EventHandler(this.CreateSaveBtn_Click);
            // 
            // CreateCountryLbl
            // 
            this.CreateCountryLbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CreateCountryLbl.AutoSize = true;
            this.CreateCountryLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.CreateCountryLbl.Location = new System.Drawing.Point(272, 179);
            this.CreateCountryLbl.Name = "CreateCountryLbl";
            this.CreateCountryLbl.Size = new System.Drawing.Size(58, 15);
            this.CreateCountryLbl.TabIndex = 20;
            this.CreateCountryLbl.Text = "Country *";
            this.CreateCountryLbl.Click += new System.EventHandler(this.CreateCountryLbl_Click);
            // 
            // CreateNameLbl
            // 
            this.CreateNameLbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CreateNameLbl.AutoSize = true;
            this.CreateNameLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.CreateNameLbl.Location = new System.Drawing.Point(272, 114);
            this.CreateNameLbl.Name = "CreateNameLbl";
            this.CreateNameLbl.Size = new System.Drawing.Size(47, 15);
            this.CreateNameLbl.TabIndex = 19;
            this.CreateNameLbl.Text = "Name *";
            this.CreateNameLbl.Click += new System.EventHandler(this.CreateNameLbl_Click);
            // 
            // CreateCountryTxt
            // 
            this.CreateCountryTxt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CreateCountryTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.CreateCountryTxt.Location = new System.Drawing.Point(272, 197);
            this.CreateCountryTxt.MaxLength = 50;
            this.CreateCountryTxt.Name = "CreateCountryTxt";
            this.CreateCountryTxt.Size = new System.Drawing.Size(200, 23);
            this.CreateCountryTxt.TabIndex = 18;
            this.CreateCountryTxt.TextChanged += new System.EventHandler(this.CreateCountryTxt_TextChanged);
            // 
            // CreateNameTxt
            // 
            this.CreateNameTxt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CreateNameTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.CreateNameTxt.Location = new System.Drawing.Point(272, 130);
            this.CreateNameTxt.MaxLength = 100;
            this.CreateNameTxt.Name = "CreateNameTxt";
            this.CreateNameTxt.Size = new System.Drawing.Size(200, 23);
            this.CreateNameTxt.TabIndex = 17;
            this.CreateNameTxt.TextChanged += new System.EventHandler(this.CreateNameTxt_TextChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(180)))), ((int)(((byte)(194)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(784, 20);
            this.panel1.TabIndex = 23;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(180)))), ((int)(((byte)(194)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 441);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(784, 20);
            this.panel2.TabIndex = 24;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(245)))), ((int)(((byte)(247)))));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.CreateNameLbl);
            this.panel3.Controls.Add(this.CreateNameTxt);
            this.panel3.Controls.Add(this.CreateCountryTxt);
            this.panel3.Controls.Add(this.CreateCountryLbl);
            this.panel3.Controls.Add(this.CreateSaveBtn);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(20, 20);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(744, 421);
            this.panel3.TabIndex = 25;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(180)))), ((int)(((byte)(194)))));
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 20);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(20, 421);
            this.panel4.TabIndex = 26;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(180)))), ((int)(((byte)(194)))));
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(764, 20);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(20, 421);
            this.panel5.TabIndex = 27;
            // 
            // CreateCustomerSupplierUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "CreateCustomerSupplierUserControl";
            this.Size = new System.Drawing.Size(784, 461);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Button CreateSaveBtn;
        private Label CreateCountryLbl;
        private Label CreateNameLbl;
        private TextBox CreateCountryTxt;
        private TextBox CreateNameTxt;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
    }
}
