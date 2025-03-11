using System.Windows.Forms;

namespace WinformDotNetFramework.Forms.AddForms
{
    partial class CreateCustomerInvoiceForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.integerTextBoxUserControl1 = new WinformDotNetFramework.Forms.control.IntegerTextBoxUserControl();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.OpenSale = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.label2.Location = new System.Drawing.Point(289, 185);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 15);
            this.label2.TabIndex = 19;
            this.label2.Text = "Invoice Date *";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dateTimePicker1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Location = new System.Drawing.Point(289, 203);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.ShowCheckBox = true;
            this.dateTimePicker1.Size = new System.Drawing.Size(172, 23);
            this.dateTimePicker1.TabIndex = 18;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.NameTxt_TextChanged);
            // 
            // integerTextBoxUserControl1
            // 
            this.integerTextBoxUserControl1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.integerTextBoxUserControl1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.integerTextBoxUserControl1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.integerTextBoxUserControl1.Location = new System.Drawing.Point(289, 157);
            this.integerTextBoxUserControl1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.integerTextBoxUserControl1.Name = "integerTextBoxUserControl1";
            this.integerTextBoxUserControl1.Size = new System.Drawing.Size(171, 25);
            this.integerTextBoxUserControl1.TabIndex = 17;
            // 
            // SaveBtn
            // 
            this.SaveBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SaveBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.SaveBtn.Enabled = false;
            this.SaveBtn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.SaveBtn.Location = new System.Drawing.Point(397, 232);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(64, 25);
            this.SaveBtn.TabIndex = 16;
            this.SaveBtn.Text = "Save";
            this.SaveBtn.UseVisualStyleBackColor = false;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.label1.Location = new System.Drawing.Point(289, 138);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 15);
            this.label1.TabIndex = 15;
            this.label1.Text = "Sale ID *";
            // 
            // OpenSale
            // 
            this.OpenSale.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.OpenSale.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(124)))), ((int)(((byte)(166)))));
            this.OpenSale.FlatAppearance.BorderSize = 0;
            this.OpenSale.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.OpenSale.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(245)))), ((int)(((byte)(247)))));
            this.OpenSale.Location = new System.Drawing.Point(466, 157);
            this.OpenSale.Name = "OpenSale";
            this.OpenSale.Size = new System.Drawing.Size(55, 25);
            this.OpenSale.TabIndex = 32;
            this.OpenSale.Text = "Open";
            this.OpenSale.UseVisualStyleBackColor = false;
            this.OpenSale.Click += new System.EventHandler(this.OpenSale_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(245)))), ((int)(((byte)(247)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.SaveBtn);
            this.panel1.Controls.Add(this.integerTextBoxUserControl1);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.OpenSale);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(17, 17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(750, 427);
            this.panel1.TabIndex = 33;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(180)))), ((int)(((byte)(194)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(784, 17);
            this.panel2.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(180)))), ((int)(((byte)(194)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 17);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(17, 427);
            this.panel3.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(180)))), ((int)(((byte)(194)))));
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(767, 17);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(17, 427);
            this.panel4.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(180)))), ((int)(((byte)(194)))));
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 444);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(784, 17);
            this.panel5.TabIndex = 0;
            // 
            // CreateCustomerInvoiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel2);
            this.MaximumSize = new System.Drawing.Size(800, 500);
            this.Name = "CreateCustomerInvoiceForm";
            this.Text = "CreateCustomerInvoiceForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Label label2;
        private DateTimePicker dateTimePicker1;
        private control.IntegerTextBoxUserControl integerTextBoxUserControl1;
        private Button SaveBtn;
        private Label label1;
        private Button OpenSale;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
    }
}