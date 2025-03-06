namespace Winform.Forms
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
            this.CustomerIdtxt = new Winform.Forms.control.IntegerTextBoxUserControl();
            this.StatusTxt = new System.Windows.Forms.TextBox();
            this.RevenueTxt = new Winform.Forms.control.IntegerTextBoxUserControl();
            this.EditCB = new System.Windows.Forms.CheckBox();
            this.saveBtn = new System.Windows.Forms.Button();
            this.DeleteBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(224, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "SaleId";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(226, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Booking Number";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(228, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "BoL Number";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(228, 186);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Sale Date";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(228, 243);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "Customer Id";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(228, 298);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 15);
            this.label6.TabIndex = 5;
            this.label6.Text = "Total Revenue";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(228, 354);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 15);
            this.label7.TabIndex = 6;
            this.label7.Text = "Status";
            // 
            // SaleIdtxt
            // 
            this.SaleIdtxt.Enabled = false;
            this.SaleIdtxt.Location = new System.Drawing.Point(226, 49);
            this.SaleIdtxt.Name = "SaleIdtxt";
            this.SaleIdtxt.Size = new System.Drawing.Size(194, 23);
            this.SaleIdtxt.TabIndex = 7;
            // 
            // bntxt
            // 
            this.bntxt.Location = new System.Drawing.Point(227, 103);
            this.bntxt.Name = "bntxt";
            this.bntxt.Size = new System.Drawing.Size(194, 23);
            this.bntxt.TabIndex = 8;
            // 
            // boltxt
            // 
            this.boltxt.Location = new System.Drawing.Point(228, 150);
            this.boltxt.Name = "boltxt";
            this.boltxt.Size = new System.Drawing.Size(194, 23);
            this.boltxt.TabIndex = 9;
            // 
            // saleDateDtp
            // 
            this.saleDateDtp.Location = new System.Drawing.Point(228, 204);
            this.saleDateDtp.Name = "saleDateDtp";
            this.saleDateDtp.Size = new System.Drawing.Size(194, 23);
            this.saleDateDtp.TabIndex = 10;
            // 
            // CustomerIdtxt
            // 
            this.CustomerIdtxt.Location = new System.Drawing.Point(228, 261);
            this.CustomerIdtxt.Name = "CustomerIdtxt";
            this.CustomerIdtxt.Size = new System.Drawing.Size(194, 23);
            this.CustomerIdtxt.TabIndex = 11;
            // 
            // StatusTxt
            // 
            this.StatusTxt.Location = new System.Drawing.Point(228, 372);
            this.StatusTxt.Name = "StatusTxt";
            this.StatusTxt.Size = new System.Drawing.Size(100, 23);
            this.StatusTxt.TabIndex = 12;
            // 
            // RevenueTxt
            // 
            this.RevenueTxt.Enabled = false;
            this.RevenueTxt.Location = new System.Drawing.Point(228, 316);
            this.RevenueTxt.Name = "RevenueTxt";
            this.RevenueTxt.Size = new System.Drawing.Size(194, 23);
            this.RevenueTxt.TabIndex = 13;
            // 
            // EditCB
            // 
            this.EditCB.AutoSize = true;
            this.EditCB.Location = new System.Drawing.Point(228, 419);
            this.EditCB.Name = "EditCB";
            this.EditCB.Size = new System.Drawing.Size(46, 19);
            this.EditCB.TabIndex = 14;
            this.EditCB.Text = "Edit";
            this.EditCB.UseVisualStyleBackColor = true;
            this.EditCB.CheckedChanged += new System.EventHandler(this.EditCB_CheckedChanged);
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(347, 416);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 15;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // DeleteBtn
            // 
            this.DeleteBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.DeleteBtn.Location = new System.Drawing.Point(428, 415);
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.Size = new System.Drawing.Size(75, 23);
            this.DeleteBtn.TabIndex = 19;
            this.DeleteBtn.Text = "Delete";
            this.DeleteBtn.UseVisualStyleBackColor = true;
            this.DeleteBtn.Click += new System.EventHandler(this.DeleteBtn_Click);
            // 
            // SaleDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.DeleteBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.EditCB);
            this.Controls.Add(this.RevenueTxt);
            this.Controls.Add(this.StatusTxt);
            this.Controls.Add(this.CustomerIdtxt);
            this.Controls.Add(this.saleDateDtp);
            this.Controls.Add(this.boltxt);
            this.Controls.Add(this.bntxt);
            this.Controls.Add(this.SaleIdtxt);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "SaleDetailsForm";
            this.Text = "SaleDetailsForm";
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}