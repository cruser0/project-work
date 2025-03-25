namespace WinformDotNetFramework.Forms.AddForms
{
    partial class CreateSupplierForm
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.CreateNameLbl = new System.Windows.Forms.Label();
            this.CreateNameTxt = new System.Windows.Forms.TextBox();
            this.CreateCountryLbl = new System.Windows.Forms.Label();
            this.CreateSaveBtn = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.CountryCmbx = new System.Windows.Forms.ComboBox();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(245)))), ((int)(((byte)(247)))));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.CountryCmbx);
            this.panel3.Controls.Add(this.CreateNameLbl);
            this.panel3.Controls.Add(this.CreateNameTxt);
            this.panel3.Controls.Add(this.CreateCountryLbl);
            this.panel3.Controls.Add(this.CreateSaveBtn);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(17, 17);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(750, 427);
            this.panel3.TabIndex = 30;
            // 
            // CreateNameLbl
            // 
            this.CreateNameLbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CreateNameLbl.AutoSize = true;
            this.CreateNameLbl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateNameLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.CreateNameLbl.Location = new System.Drawing.Point(289, 126);
            this.CreateNameLbl.Name = "CreateNameLbl";
            this.CreateNameLbl.Size = new System.Drawing.Size(47, 15);
            this.CreateNameLbl.TabIndex = 19;
            this.CreateNameLbl.Text = "Name *";
            // 
            // CreateNameTxt
            // 
            this.CreateNameTxt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CreateNameTxt.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateNameTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.CreateNameTxt.Location = new System.Drawing.Point(289, 144);
            this.CreateNameTxt.MaxLength = 100;
            this.CreateNameTxt.Name = "CreateNameTxt";
            this.CreateNameTxt.Size = new System.Drawing.Size(180, 23);
            this.CreateNameTxt.TabIndex = 17;
            this.CreateNameTxt.TextChanged += new System.EventHandler(this.NameTxt_TextChanged);
            // 
            // CreateCountryLbl
            // 
            this.CreateCountryLbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CreateCountryLbl.AutoSize = true;
            this.CreateCountryLbl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateCountryLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.CreateCountryLbl.Location = new System.Drawing.Point(289, 170);
            this.CreateCountryLbl.Name = "CreateCountryLbl";
            this.CreateCountryLbl.Size = new System.Drawing.Size(58, 15);
            this.CreateCountryLbl.TabIndex = 20;
            this.CreateCountryLbl.Text = "Country *";
            // 
            // CreateSaveBtn
            // 
            this.CreateSaveBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CreateSaveBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.CreateSaveBtn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateSaveBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.CreateSaveBtn.Location = new System.Drawing.Point(377, 217);
            this.CreateSaveBtn.Name = "CreateSaveBtn";
            this.CreateSaveBtn.Size = new System.Drawing.Size(92, 25);
            this.CreateSaveBtn.TabIndex = 22;
            this.CreateSaveBtn.Text = "Save changes";
            this.CreateSaveBtn.UseVisualStyleBackColor = false;
            this.CreateSaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(180)))), ((int)(((byte)(194)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(17, 444);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(750, 17);
            this.panel2.TabIndex = 29;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(180)))), ((int)(((byte)(194)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(17, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(750, 17);
            this.panel1.TabIndex = 28;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(180)))), ((int)(((byte)(194)))));
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(767, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(17, 461);
            this.panel5.TabIndex = 32;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(180)))), ((int)(((byte)(194)))));
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(17, 461);
            this.panel4.TabIndex = 31;
            // 
            // CountryCmbx
            // 
            this.CountryCmbx.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CountryCmbx.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CountryCmbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CountryCmbx.FormattingEnabled = true;
            this.CountryCmbx.Location = new System.Drawing.Point(289, 188);
            this.CountryCmbx.Name = "CountryCmbx";
            this.CountryCmbx.Size = new System.Drawing.Size(180, 21);
            this.CountryCmbx.TabIndex = 28;
            this.CountryCmbx.SelectionChangeCommitted += new System.EventHandler(this.NameTxt_TextChanged);
            // 
            // CreateSupplierForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "CreateSupplierForm";
            this.Text = "CreateSupplierForm";
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label CreateNameLbl;
        private System.Windows.Forms.TextBox CreateNameTxt;
        private System.Windows.Forms.Label CreateCountryLbl;
        private System.Windows.Forms.Button CreateSaveBtn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ComboBox CountryCmbx;
    }
}