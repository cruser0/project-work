﻿using System.Windows.Forms;

namespace WinformDotNetFramework.Forms.DetailsForms
{
    partial class CustomerDetailsForm
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
            this.NameCustomerTxt = new System.Windows.Forms.TextBox();
            this.NameCustomerLbl = new System.Windows.Forms.Label();
            this.IdCustomerLbl = new System.Windows.Forms.Label();
            this.EditCustomerCbx = new System.Windows.Forms.CheckBox();
            this.CountryCustomerLbl = new System.Windows.Forms.Label();
            this.CountryCustomerTxt = new System.Windows.Forms.TextBox();
            this.SaveEditCustomerBtn = new System.Windows.Forms.Button();
            this.StatusLbl = new System.Windows.Forms.Label();
            this.StatusTxt = new System.Windows.Forms.TextBox();
            this.IdCustomerTxt = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // NameCustomerTxt
            // 
            this.NameCustomerTxt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.NameCustomerTxt.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameCustomerTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.NameCustomerTxt.Location = new System.Drawing.Point(273, 194);
            this.NameCustomerTxt.Name = "NameCustomerTxt";
            this.NameCustomerTxt.Size = new System.Drawing.Size(200, 23);
            this.NameCustomerTxt.TabIndex = 2;
            // 
            // NameCustomerLbl
            // 
            this.NameCustomerLbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.NameCustomerLbl.AutoSize = true;
            this.NameCustomerLbl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameCustomerLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.NameCustomerLbl.Location = new System.Drawing.Point(274, 176);
            this.NameCustomerLbl.Name = "NameCustomerLbl";
            this.NameCustomerLbl.Size = new System.Drawing.Size(39, 15);
            this.NameCustomerLbl.TabIndex = 5;
            this.NameCustomerLbl.Text = "Name";
            // 
            // IdCustomerLbl
            // 
            this.IdCustomerLbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.IdCustomerLbl.AutoSize = true;
            this.IdCustomerLbl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IdCustomerLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.IdCustomerLbl.Location = new System.Drawing.Point(274, 86);
            this.IdCustomerLbl.Name = "IdCustomerLbl";
            this.IdCustomerLbl.Size = new System.Drawing.Size(17, 15);
            this.IdCustomerLbl.TabIndex = 4;
            this.IdCustomerLbl.Text = "Id";
            // 
            // EditCustomerCbx
            // 
            this.EditCustomerCbx.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.EditCustomerCbx.AutoSize = true;
            this.EditCustomerCbx.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditCustomerCbx.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.EditCustomerCbx.Location = new System.Drawing.Point(427, 267);
            this.EditCustomerCbx.Name = "EditCustomerCbx";
            this.EditCustomerCbx.Size = new System.Drawing.Size(46, 19);
            this.EditCustomerCbx.TabIndex = 7;
            this.EditCustomerCbx.Text = "Edit";
            this.EditCustomerCbx.UseVisualStyleBackColor = true;
            this.EditCustomerCbx.CheckedChanged += new System.EventHandler(this.EditCustomerCbx_CheckedChanged);
            // 
            // CountryCustomerLbl
            // 
            this.CountryCustomerLbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CountryCustomerLbl.AutoSize = true;
            this.CountryCustomerLbl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CountryCustomerLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.CountryCustomerLbl.Location = new System.Drawing.Point(274, 220);
            this.CountryCustomerLbl.Name = "CountryCustomerLbl";
            this.CountryCustomerLbl.Size = new System.Drawing.Size(50, 15);
            this.CountryCustomerLbl.TabIndex = 6;
            this.CountryCustomerLbl.Text = "Country";
            this.CountryCustomerLbl.Click += new System.EventHandler(this.CountryCustomerLbl_Click);
            // 
            // CountryCustomerTxt
            // 
            this.CountryCustomerTxt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CountryCustomerTxt.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CountryCustomerTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.CountryCustomerTxt.Location = new System.Drawing.Point(273, 238);
            this.CountryCustomerTxt.Name = "CountryCustomerTxt";
            this.CountryCustomerTxt.Size = new System.Drawing.Size(200, 23);
            this.CountryCustomerTxt.TabIndex = 3;
            // 
            // SaveEditCustomerBtn
            // 
            this.SaveEditCustomerBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SaveEditCustomerBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.SaveEditCustomerBtn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveEditCustomerBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.SaveEditCustomerBtn.Location = new System.Drawing.Point(381, 292);
            this.SaveEditCustomerBtn.Name = "SaveEditCustomerBtn";
            this.SaveEditCustomerBtn.Size = new System.Drawing.Size(92, 25);
            this.SaveEditCustomerBtn.TabIndex = 8;
            this.SaveEditCustomerBtn.Text = "Save changes";
            this.SaveEditCustomerBtn.UseVisualStyleBackColor = false;
            this.SaveEditCustomerBtn.Click += new System.EventHandler(this.SaveEditCustomerBtn_Click);
            // 
            // StatusLbl
            // 
            this.StatusLbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.StatusLbl.AutoSize = true;
            this.StatusLbl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.StatusLbl.Location = new System.Drawing.Point(274, 132);
            this.StatusLbl.Name = "StatusLbl";
            this.StatusLbl.Size = new System.Drawing.Size(39, 15);
            this.StatusLbl.TabIndex = 10;
            this.StatusLbl.Text = "Status";
            // 
            // StatusTxt
            // 
            this.StatusTxt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.StatusTxt.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.StatusTxt.Location = new System.Drawing.Point(273, 150);
            this.StatusTxt.Name = "StatusTxt";
            this.StatusTxt.Size = new System.Drawing.Size(200, 23);
            this.StatusTxt.TabIndex = 9;
            // 
            // IdCustomerTxt
            // 
            this.IdCustomerTxt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.IdCustomerTxt.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IdCustomerTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.IdCustomerTxt.Location = new System.Drawing.Point(273, 104);
            this.IdCustomerTxt.Name = "IdCustomerTxt";
            this.IdCustomerTxt.Size = new System.Drawing.Size(200, 23);
            this.IdCustomerTxt.TabIndex = 11;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(245)))), ((int)(((byte)(247)))));
            this.panel1.Controls.Add(this.IdCustomerLbl);
            this.panel1.Controls.Add(this.NameCustomerTxt);
            this.panel1.Controls.Add(this.IdCustomerTxt);
            this.panel1.Controls.Add(this.CountryCustomerTxt);
            this.panel1.Controls.Add(this.StatusLbl);
            this.panel1.Controls.Add(this.NameCustomerLbl);
            this.panel1.Controls.Add(this.StatusTxt);
            this.panel1.Controls.Add(this.CountryCustomerLbl);
            this.panel1.Controls.Add(this.SaveEditCustomerBtn);
            this.panel1.Controls.Add(this.EditCustomerCbx);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(17, 17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(750, 427);
            this.panel1.TabIndex = 24;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(180)))), ((int)(((byte)(194)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(17, 461);
            this.panel2.TabIndex = 25;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(180)))), ((int)(((byte)(194)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(767, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(17, 461);
            this.panel3.TabIndex = 26;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(180)))), ((int)(((byte)(194)))));
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(17, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(750, 17);
            this.panel4.TabIndex = 27;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(180)))), ((int)(((byte)(194)))));
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(17, 444);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(750, 17);
            this.panel5.TabIndex = 28;
            // 
            // CustomerDetailsForm
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
            this.Name = "CustomerDetailsForm";
            this.Text = "CustomerDetailsForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TextBox NameCustomerTxt;
        private Label NameCustomerLbl;
        private Label IdCustomerLbl;
        private CheckBox EditCustomerCbx;
        private Label CountryCustomerLbl;
        private TextBox CountryCustomerTxt;
        private Button SaveEditCustomerBtn;
        private Label StatusLbl;
        private TextBox StatusTxt;
        private TextBox IdCustomerTxt;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
    }
}