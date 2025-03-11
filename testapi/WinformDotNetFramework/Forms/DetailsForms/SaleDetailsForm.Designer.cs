using System.Windows.Forms;

namespace WinformDotNetFramework.Forms.DetailsForms
{
    partial class SaleDetailsForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.SaleIdtxt = new System.Windows.Forms.TextBox();
            this.bntxt = new System.Windows.Forms.TextBox();
            this.boltxt = new System.Windows.Forms.TextBox();
            this.saleDateDtp = new System.Windows.Forms.DateTimePicker();
            this.CustomerIdtxt = new WinformDotNetFramework.Forms.control.IntegerTextBoxUserControl();
            this.StatusTxt = new System.Windows.Forms.TextBox();
            this.RevenueTxt = new WinformDotNetFramework.Forms.control.IntegerTextBoxUserControl();
            this.EditCB = new System.Windows.Forms.CheckBox();
            this.saveBtn = new System.Windows.Forms.Button();
            this.DeleteBtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(171, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "SaleId";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(173, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Booking Number";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(175, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "BoL Number";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(395, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Sale Date";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(395, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "Customer Id";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(395, 158);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 15);
            this.label6.TabIndex = 5;
            this.label6.Text = "Total Revenue";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(395, 214);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 15);
            this.label7.TabIndex = 6;
            this.label7.Text = "Status";
            // 
            // SaleIdtxt
            // 
            this.SaleIdtxt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SaleIdtxt.Enabled = false;
            this.SaleIdtxt.Location = new System.Drawing.Point(173, 64);
            this.SaleIdtxt.Name = "SaleIdtxt";
            this.SaleIdtxt.Size = new System.Drawing.Size(194, 23);
            this.SaleIdtxt.TabIndex = 7;
            // 
            // bntxt
            // 
            this.bntxt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bntxt.Location = new System.Drawing.Point(174, 118);
            this.bntxt.Name = "bntxt";
            this.bntxt.Size = new System.Drawing.Size(194, 23);
            this.bntxt.TabIndex = 8;
            // 
            // boltxt
            // 
            this.boltxt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.boltxt.Location = new System.Drawing.Point(175, 165);
            this.boltxt.Name = "boltxt";
            this.boltxt.Size = new System.Drawing.Size(194, 23);
            this.boltxt.TabIndex = 9;
            // 
            // saleDateDtp
            // 
            this.saleDateDtp.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.saleDateDtp.Location = new System.Drawing.Point(395, 64);
            this.saleDateDtp.Name = "saleDateDtp";
            this.saleDateDtp.Size = new System.Drawing.Size(194, 23);
            this.saleDateDtp.TabIndex = 10;
            // 
            // CustomerIdtxt
            // 
            this.CustomerIdtxt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CustomerIdtxt.Location = new System.Drawing.Point(395, 121);
            this.CustomerIdtxt.Name = "CustomerIdtxt";
            this.CustomerIdtxt.Size = new System.Drawing.Size(194, 23);
            this.CustomerIdtxt.TabIndex = 11;
            // 
            // StatusTxt
            // 
            this.StatusTxt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.StatusTxt.Location = new System.Drawing.Point(395, 232);
            this.StatusTxt.Name = "StatusTxt";
            this.StatusTxt.Size = new System.Drawing.Size(100, 23);
            this.StatusTxt.TabIndex = 12;
            // 
            // RevenueTxt
            // 
            this.RevenueTxt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RevenueTxt.Enabled = false;
            this.RevenueTxt.Location = new System.Drawing.Point(395, 176);
            this.RevenueTxt.Name = "RevenueTxt";
            this.RevenueTxt.Size = new System.Drawing.Size(194, 23);
            this.RevenueTxt.TabIndex = 13;
            // 
            // EditCB
            // 
            this.EditCB.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.EditCB.AutoSize = true;
            this.EditCB.Location = new System.Drawing.Point(220, 307);
            this.EditCB.Name = "EditCB";
            this.EditCB.Size = new System.Drawing.Size(46, 19);
            this.EditCB.TabIndex = 14;
            this.EditCB.Text = "Edit";
            this.EditCB.UseVisualStyleBackColor = true;
            this.EditCB.CheckedChanged += new System.EventHandler(this.EditCB_CheckedChanged);
            // 
            // saveBtn
            // 
            this.saveBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.saveBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.saveBtn.Location = new System.Drawing.Point(339, 304);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 15;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = false;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // DeleteBtn
            // 
            this.DeleteBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DeleteBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.DeleteBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.DeleteBtn.Location = new System.Drawing.Point(420, 303);
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.Size = new System.Drawing.Size(75, 23);
            this.DeleteBtn.TabIndex = 19;
            this.DeleteBtn.Text = "Delete";
            this.DeleteBtn.UseVisualStyleBackColor = false;
            this.DeleteBtn.Click += new System.EventHandler(this.DeleteBtn_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(245)))), ((int)(((byte)(247)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.DeleteBtn);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.saveBtn);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.EditCB);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.RevenueTxt);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.StatusTxt);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.CustomerIdtxt);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.saleDateDtp);
            this.panel1.Controls.Add(this.SaleIdtxt);
            this.panel1.Controls.Add(this.boltxt);
            this.panel1.Controls.Add(this.bntxt);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(20, 20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(744, 421);
            this.panel1.TabIndex = 20;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(180)))), ((int)(((byte)(194)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(20, 461);
            this.panel2.TabIndex = 21;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(180)))), ((int)(((byte)(194)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(764, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(20, 461);
            this.panel3.TabIndex = 22;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(180)))), ((int)(((byte)(194)))));
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(20, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(744, 20);
            this.panel4.TabIndex = 23;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(180)))), ((int)(((byte)(194)))));
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(20, 441);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(744, 20);
            this.panel5.TabIndex = 24;
            // 
            // SaleDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "SaleDetailsForm";
            this.Text = "SaleDetailsForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox SaleIdtxt;
        private TextBox bntxt;
        private TextBox boltxt;
        private DateTimePicker saleDateDtp;
        private control.IntegerTextBoxUserControl CustomerIdtxt;
        private TextBox StatusTxt;
        private control.IntegerTextBoxUserControl RevenueTxt;
        private CheckBox EditCB;
        private Button saveBtn;
        private Button DeleteBtn;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
    }
}