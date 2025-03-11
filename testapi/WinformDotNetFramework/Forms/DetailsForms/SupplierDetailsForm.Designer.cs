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
            this.SaveEditSupplierBtn = new System.Windows.Forms.Button();
            this.EditSupplierCbx = new System.Windows.Forms.CheckBox();
            this.CountrySupplierLbl = new System.Windows.Forms.Label();
            this.NameSupplierLbl = new System.Windows.Forms.Label();
            this.IdSupplierLbl = new System.Windows.Forms.Label();
            this.CountrySupplierTxt = new System.Windows.Forms.TextBox();
            this.IdSupplierTxt = new System.Windows.Forms.TextBox();
            this.NameSupplierTxt = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SaveEditSupplierBtn
            // 
            this.SaveEditSupplierBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SaveEditSupplierBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.SaveEditSupplierBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.SaveEditSupplierBtn.Location = new System.Drawing.Point(377, 235);
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
            this.EditSupplierCbx.Location = new System.Drawing.Point(423, 210);
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
            this.CountrySupplierLbl.Location = new System.Drawing.Point(270, 163);
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
            this.NameSupplierLbl.Location = new System.Drawing.Point(270, 119);
            this.NameSupplierLbl.Name = "NameSupplierLbl";
            this.NameSupplierLbl.Size = new System.Drawing.Size(39, 15);
            this.NameSupplierLbl.TabIndex = 13;
            this.NameSupplierLbl.Text = "Name";
            // 
            // IdSupplierLbl
            // 
            this.IdSupplierLbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.IdSupplierLbl.AutoSize = true;
            this.IdSupplierLbl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IdSupplierLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.IdSupplierLbl.Location = new System.Drawing.Point(270, 75);
            this.IdSupplierLbl.Name = "IdSupplierLbl";
            this.IdSupplierLbl.Size = new System.Drawing.Size(17, 15);
            this.IdSupplierLbl.TabIndex = 12;
            this.IdSupplierLbl.Text = "Id";
            // 
            // CountrySupplierTxt
            // 
            this.CountrySupplierTxt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CountrySupplierTxt.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CountrySupplierTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.CountrySupplierTxt.Location = new System.Drawing.Point(269, 181);
            this.CountrySupplierTxt.MaxLength = 50;
            this.CountrySupplierTxt.Name = "CountrySupplierTxt";
            this.CountrySupplierTxt.Size = new System.Drawing.Size(200, 23);
            this.CountrySupplierTxt.TabIndex = 11;
            // 
            // IdSupplierTxt
            // 
            this.IdSupplierTxt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.IdSupplierTxt.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IdSupplierTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.IdSupplierTxt.Location = new System.Drawing.Point(269, 93);
            this.IdSupplierTxt.Name = "IdSupplierTxt";
            this.IdSupplierTxt.Size = new System.Drawing.Size(200, 23);
            this.IdSupplierTxt.TabIndex = 9;
            // 
            // NameSupplierTxt
            // 
            this.NameSupplierTxt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.NameSupplierTxt.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameSupplierTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.NameSupplierTxt.Location = new System.Drawing.Point(269, 137);
            this.NameSupplierTxt.MaxLength = 100;
            this.NameSupplierTxt.Name = "NameSupplierTxt";
            this.NameSupplierTxt.Size = new System.Drawing.Size(200, 23);
            this.NameSupplierTxt.TabIndex = 10;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(245)))), ((int)(((byte)(247)))));
            this.panel1.Controls.Add(this.IdSupplierLbl);
            this.panel1.Controls.Add(this.NameSupplierTxt);
            this.panel1.Controls.Add(this.IdSupplierTxt);
            this.panel1.Controls.Add(this.SaveEditSupplierBtn);
            this.panel1.Controls.Add(this.CountrySupplierTxt);
            this.panel1.Controls.Add(this.EditSupplierCbx);
            this.panel1.Controls.Add(this.NameSupplierLbl);
            this.panel1.Controls.Add(this.CountrySupplierLbl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(17, 17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(750, 427);
            this.panel1.TabIndex = 19;
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
            this.ResumeLayout(false);

        }

        #endregion

        private Button SaveEditSupplierBtn;
        private CheckBox EditSupplierCbx;
        private Label CountrySupplierLbl;
        private Label NameSupplierLbl;
        private Label IdSupplierLbl;
        private TextBox CountrySupplierTxt;
        private TextBox IdSupplierTxt;
        private TextBox NameSupplierTxt;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
    }
}