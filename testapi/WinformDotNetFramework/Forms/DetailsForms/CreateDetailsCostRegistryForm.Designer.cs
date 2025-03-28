namespace WinformDotNetFramework.Forms.DetailsForms
{
    partial class CreateDetailsCostRegistryForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.DescriptionTxt = new System.Windows.Forms.TextBox();
            this.CostLbl = new System.Windows.Forms.Label();
            this.UniqueCodeTxt = new System.Windows.Forms.TextBox();
            this.CodeLbl = new System.Windows.Forms.Label();
            this.CountryCustomerLbl = new System.Windows.Forms.Label();
            this.SaveEditCustomerBtn = new System.Windows.Forms.Button();
            this.EditCustomerCbx = new System.Windows.Forms.CheckBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.DefaultQuantityIntegerTxt = new WinformDotNetFramework.Forms.control.IntegerTextBoxUserControl();
            this.DefaultCostDecimalTxt = new WinformDotNetFramework.Forms.control.DecimalTextBoxUserControl();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(245)))), ((int)(((byte)(247)))));
            this.panel1.Controls.Add(this.DefaultQuantityIntegerTxt);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.DefaultCostDecimalTxt);
            this.panel1.Controls.Add(this.DescriptionTxt);
            this.panel1.Controls.Add(this.CostLbl);
            this.panel1.Controls.Add(this.UniqueCodeTxt);
            this.panel1.Controls.Add(this.CodeLbl);
            this.panel1.Controls.Add(this.CountryCustomerLbl);
            this.panel1.Controls.Add(this.SaveEditCustomerBtn);
            this.panel1.Controls.Add(this.EditCustomerCbx);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(17, 17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(766, 416);
            this.panel1.TabIndex = 29;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.label2.Location = new System.Drawing.Point(269, 207);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 15);
            this.label2.TabIndex = 33;
            this.label2.Text = "Defaul Quantity";
            // 
            // DescriptionTxt
            // 
            this.DescriptionTxt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DescriptionTxt.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DescriptionTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.DescriptionTxt.Location = new System.Drawing.Point(269, 137);
            this.DescriptionTxt.Name = "DescriptionTxt";
            this.DescriptionTxt.Size = new System.Drawing.Size(200, 23);
            this.DescriptionTxt.TabIndex = 30;
            // 
            // CostLbl
            // 
            this.CostLbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CostLbl.AutoSize = true;
            this.CostLbl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CostLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.CostLbl.Location = new System.Drawing.Point(269, 163);
            this.CostLbl.Name = "CostLbl";
            this.CostLbl.Size = new System.Drawing.Size(72, 15);
            this.CostLbl.TabIndex = 29;
            this.CostLbl.Text = "Default Cost";
            // 
            // UniqueCodeTxt
            // 
            this.UniqueCodeTxt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UniqueCodeTxt.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UniqueCodeTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.UniqueCodeTxt.Location = new System.Drawing.Point(269, 95);
            this.UniqueCodeTxt.Name = "UniqueCodeTxt";
            this.UniqueCodeTxt.Size = new System.Drawing.Size(200, 23);
            this.UniqueCodeTxt.TabIndex = 2;
            // 
            // CodeLbl
            // 
            this.CodeLbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CodeLbl.AutoSize = true;
            this.CodeLbl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CodeLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.CodeLbl.Location = new System.Drawing.Point(269, 77);
            this.CodeLbl.Name = "CodeLbl";
            this.CodeLbl.Size = new System.Drawing.Size(76, 15);
            this.CodeLbl.TabIndex = 5;
            this.CodeLbl.Text = "Unique Code";
            // 
            // CountryCustomerLbl
            // 
            this.CountryCustomerLbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CountryCustomerLbl.AutoSize = true;
            this.CountryCustomerLbl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CountryCustomerLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.CountryCustomerLbl.Location = new System.Drawing.Point(269, 121);
            this.CountryCustomerLbl.Name = "CountryCustomerLbl";
            this.CountryCustomerLbl.Size = new System.Drawing.Size(67, 15);
            this.CountryCustomerLbl.TabIndex = 6;
            this.CountryCustomerLbl.Text = "Description";
            // 
            // SaveEditCustomerBtn
            // 
            this.SaveEditCustomerBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SaveEditCustomerBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.SaveEditCustomerBtn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveEditCustomerBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.SaveEditCustomerBtn.Location = new System.Drawing.Point(377, 323);
            this.SaveEditCustomerBtn.Name = "SaveEditCustomerBtn";
            this.SaveEditCustomerBtn.Size = new System.Drawing.Size(92, 25);
            this.SaveEditCustomerBtn.TabIndex = 8;
            this.SaveEditCustomerBtn.Text = "Save changes";
            this.SaveEditCustomerBtn.UseVisualStyleBackColor = false;
            this.SaveEditCustomerBtn.Click += new System.EventHandler(this.SaveEditCostRegistryBtn_Click);
            // 
            // EditCustomerCbx
            // 
            this.EditCustomerCbx.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.EditCustomerCbx.AutoSize = true;
            this.EditCustomerCbx.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditCustomerCbx.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.EditCustomerCbx.Location = new System.Drawing.Point(423, 298);
            this.EditCustomerCbx.Name = "EditCustomerCbx";
            this.EditCustomerCbx.Size = new System.Drawing.Size(46, 19);
            this.EditCustomerCbx.TabIndex = 7;
            this.EditCustomerCbx.Text = "Edit";
            this.EditCustomerCbx.UseVisualStyleBackColor = true;
            this.EditCustomerCbx.CheckedChanged += new System.EventHandler(this.EditCostRegistryCbx_CheckedChanged);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(180)))), ((int)(((byte)(194)))));
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(17, 433);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(766, 17);
            this.panel5.TabIndex = 33;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(180)))), ((int)(((byte)(194)))));
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(17, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(766, 17);
            this.panel4.TabIndex = 32;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(180)))), ((int)(((byte)(194)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(783, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(17, 450);
            this.panel3.TabIndex = 31;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(180)))), ((int)(((byte)(194)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(17, 450);
            this.panel2.TabIndex = 30;
            // 
            // DefaultQuantityIntegerTxt
            // 
            this.DefaultQuantityIntegerTxt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DefaultQuantityIntegerTxt.Location = new System.Drawing.Point(269, 225);
            this.DefaultQuantityIntegerTxt.Name = "DefaultQuantityIntegerTxt";
            this.DefaultQuantityIntegerTxt.Size = new System.Drawing.Size(200, 23);
            this.DefaultQuantityIntegerTxt.TabIndex = 34;
            // 
            // DefaultCostDecimalTxt
            // 
            this.DefaultCostDecimalTxt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DefaultCostDecimalTxt.Location = new System.Drawing.Point(269, 181);
            this.DefaultCostDecimalTxt.Name = "DefaultCostDecimalTxt";
            this.DefaultCostDecimalTxt.Size = new System.Drawing.Size(200, 23);
            this.DefaultCostDecimalTxt.TabIndex = 31;
            // 
            // CreateDetailsCostRegistryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Name = "CreateDetailsCostRegistryForm";
            this.Text = "CreateCostRegistry";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label CostLbl;
        private System.Windows.Forms.TextBox UniqueCodeTxt;
        private System.Windows.Forms.Label CodeLbl;
        private System.Windows.Forms.Label CountryCustomerLbl;
        private System.Windows.Forms.Button SaveEditCustomerBtn;
        private System.Windows.Forms.CheckBox EditCustomerCbx;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox DescriptionTxt;
        private control.DecimalTextBoxUserControl DefaultCostDecimalTxt;
        private System.Windows.Forms.Label label2;
        private control.IntegerTextBoxUserControl DefaultQuantityIntegerTxt;
    }
}