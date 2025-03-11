using System.Windows.Forms;

namespace WinformDotNetFramework.Forms.DetailsForms
{
    partial class CustomerInvoiceCostDetailsForm
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
            this.saveBtn = new System.Windows.Forms.Button();
            this.editchbx = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.QuantityTxt = new WinformDotNetFramework.Forms.control.IntegerTextBoxUserControl();
            this.CustomerInvoiceIDtxt = new WinformDotNetFramework.Forms.control.IntegerTextBoxUserControl();
            this.CostTxt = new WinformDotNetFramework.Forms.control.DecimalTextBoxUserControl();
            this.CustomerInvoiceCostIDtxt = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // saveBtn
            // 
            this.saveBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.saveBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.saveBtn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.saveBtn.Location = new System.Drawing.Point(407, 294);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(79, 25);
            this.saveBtn.TabIndex = 40;
            this.saveBtn.Text = "Save Changes";
            this.saveBtn.UseVisualStyleBackColor = false;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // editchbx
            // 
            this.editchbx.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.editchbx.AutoSize = true;
            this.editchbx.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editchbx.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.editchbx.Location = new System.Drawing.Point(440, 269);
            this.editchbx.Name = "editchbx";
            this.editchbx.Size = new System.Drawing.Size(46, 19);
            this.editchbx.TabIndex = 39;
            this.editchbx.Text = "Edit";
            this.editchbx.UseVisualStyleBackColor = true;
            this.editchbx.CheckedChanged += new System.EventHandler(this.EditCB_CheckedChanged);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.label4.Location = new System.Drawing.Point(287, 220);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 15);
            this.label4.TabIndex = 38;
            this.label4.Text = "Quantity";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.label3.Location = new System.Drawing.Point(287, 174);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 15);
            this.label3.TabIndex = 37;
            this.label3.Text = "Cost";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.label2.Location = new System.Drawing.Point(287, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 15);
            this.label2.TabIndex = 36;
            this.label2.Text = "Customer Invoice ID";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.label1.Location = new System.Drawing.Point(286, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 15);
            this.label1.TabIndex = 35;
            this.label1.Text = "Customer Invoice Cost ID";
            // 
            // QuantityTxt
            // 
            this.QuantityTxt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.QuantityTxt.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QuantityTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.QuantityTxt.Location = new System.Drawing.Point(286, 238);
            this.QuantityTxt.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.QuantityTxt.Name = "QuantityTxt";
            this.QuantityTxt.Size = new System.Drawing.Size(200, 25);
            this.QuantityTxt.TabIndex = 34;
            // 
            // CustomerInvoiceIDtxt
            // 
            this.CustomerInvoiceIDtxt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CustomerInvoiceIDtxt.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustomerInvoiceIDtxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.CustomerInvoiceIDtxt.Location = new System.Drawing.Point(286, 146);
            this.CustomerInvoiceIDtxt.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.CustomerInvoiceIDtxt.Name = "CustomerInvoiceIDtxt";
            this.CustomerInvoiceIDtxt.Size = new System.Drawing.Size(200, 25);
            this.CustomerInvoiceIDtxt.TabIndex = 33;
            // 
            // CostTxt
            // 
            this.CostTxt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CostTxt.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CostTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.CostTxt.Location = new System.Drawing.Point(286, 192);
            this.CostTxt.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.CostTxt.Name = "CostTxt";
            this.CostTxt.Size = new System.Drawing.Size(200, 25);
            this.CostTxt.TabIndex = 32;
            // 
            // CustomerInvoiceCostIDtxt
            // 
            this.CustomerInvoiceCostIDtxt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CustomerInvoiceCostIDtxt.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustomerInvoiceCostIDtxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.CustomerInvoiceCostIDtxt.Location = new System.Drawing.Point(286, 102);
            this.CustomerInvoiceCostIDtxt.Name = "CustomerInvoiceCostIDtxt";
            this.CustomerInvoiceCostIDtxt.Size = new System.Drawing.Size(200, 23);
            this.CustomerInvoiceCostIDtxt.TabIndex = 31;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(245)))), ((int)(((byte)(247)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.saveBtn);
            this.panel1.Controls.Add(this.editchbx);
            this.panel1.Controls.Add(this.CustomerInvoiceCostIDtxt);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.CostTxt);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.CustomerInvoiceIDtxt);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.QuantityTxt);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(17, 17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(750, 427);
            this.panel1.TabIndex = 41;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(180)))), ((int)(((byte)(194)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(17, 461);
            this.panel2.TabIndex = 42;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(180)))), ((int)(((byte)(194)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(767, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(17, 461);
            this.panel3.TabIndex = 43;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(180)))), ((int)(((byte)(194)))));
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(17, 444);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(750, 17);
            this.panel4.TabIndex = 44;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(180)))), ((int)(((byte)(194)))));
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(17, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(750, 17);
            this.panel5.TabIndex = 45;
            // 
            // CustomerInvoiceCostDetailsForm
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
            this.Name = "CustomerInvoiceCostDetailsForm";
            this.Text = "CustomerInvoiceCostDetailsForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Button saveBtn;
        private CheckBox editchbx;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private control.IntegerTextBoxUserControl QuantityTxt;
        private control.IntegerTextBoxUserControl CustomerInvoiceIDtxt;
        private control.DecimalTextBoxUserControl CostTxt;
        private TextBox CustomerInvoiceCostIDtxt;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
    }
}