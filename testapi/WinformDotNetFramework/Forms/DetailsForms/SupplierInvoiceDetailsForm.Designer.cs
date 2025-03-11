using System.Windows.Forms;

namespace WinformDotNetFramework.Forms.DetailsForms
{
    partial class SupplierInvoiceDetailsForm
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
            this.SaveEditCustomerBtn = new System.Windows.Forms.Button();
            this.EditCbx = new System.Windows.Forms.CheckBox();
            this.SupplierIDLbl = new System.Windows.Forms.Label();
            this.SaleIDLbl = new System.Windows.Forms.Label();
            this.IdSupplierInvoiceLbl = new System.Windows.Forms.Label();
            this.IdTxt = new System.Windows.Forms.TextBox();
            this.StatusCmbx = new System.Windows.Forms.ComboBox();
            this.StatusLbl = new System.Windows.Forms.Label();
            this.DateClnd = new System.Windows.Forms.DateTimePicker();
            this.SaleIDTxt1 = new WinformDotNetFramework.Forms.control.IntegerTextBoxUserControl();
            this.SupplierIDTxt1 = new WinformDotNetFramework.Forms.control.IntegerTextBoxUserControl();
            this.DeleteBtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // SaveEditCustomerBtn
            // 
            this.SaveEditCustomerBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SaveEditCustomerBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.SaveEditCustomerBtn.Location = new System.Drawing.Point(261, 340);
            this.SaveEditCustomerBtn.Name = "SaveEditCustomerBtn";
            this.SaveEditCustomerBtn.Size = new System.Drawing.Size(107, 23);
            this.SaveEditCustomerBtn.TabIndex = 16;
            this.SaveEditCustomerBtn.Text = "Save changes";
            this.SaveEditCustomerBtn.UseVisualStyleBackColor = false;
            this.SaveEditCustomerBtn.Click += new System.EventHandler(this.SaveEditCustomerBtn_Click);
            // 
            // EditCbx
            // 
            this.EditCbx.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.EditCbx.AutoSize = true;
            this.EditCbx.Location = new System.Drawing.Point(261, 315);
            this.EditCbx.Name = "EditCbx";
            this.EditCbx.Size = new System.Drawing.Size(46, 19);
            this.EditCbx.TabIndex = 15;
            this.EditCbx.Text = "Edit";
            this.EditCbx.UseVisualStyleBackColor = true;
            this.EditCbx.CheckedChanged += new System.EventHandler(this.EditCustomerCbx_CheckedChanged);
            // 
            // SupplierIDLbl
            // 
            this.SupplierIDLbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SupplierIDLbl.AutoSize = true;
            this.SupplierIDLbl.Location = new System.Drawing.Point(263, 141);
            this.SupplierIDLbl.Name = "SupplierIDLbl";
            this.SupplierIDLbl.Size = new System.Drawing.Size(61, 15);
            this.SupplierIDLbl.TabIndex = 14;
            this.SupplierIDLbl.Text = "SupplierID";
            // 
            // SaleIDLbl
            // 
            this.SaleIDLbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SaleIDLbl.AutoSize = true;
            this.SaleIDLbl.Location = new System.Drawing.Point(263, 86);
            this.SaleIDLbl.Name = "SaleIDLbl";
            this.SaleIDLbl.Size = new System.Drawing.Size(39, 15);
            this.SaleIDLbl.TabIndex = 13;
            this.SaleIDLbl.Text = "SaleID";
            // 
            // IdSupplierInvoiceLbl
            // 
            this.IdSupplierInvoiceLbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.IdSupplierInvoiceLbl.AutoSize = true;
            this.IdSupplierInvoiceLbl.Location = new System.Drawing.Point(263, 30);
            this.IdSupplierInvoiceLbl.Name = "IdSupplierInvoiceLbl";
            this.IdSupplierInvoiceLbl.Size = new System.Drawing.Size(17, 15);
            this.IdSupplierInvoiceLbl.TabIndex = 12;
            this.IdSupplierInvoiceLbl.Text = "Id";
            // 
            // IdTxt
            // 
            this.IdTxt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.IdTxt.Location = new System.Drawing.Point(261, 48);
            this.IdTxt.Name = "IdTxt";
            this.IdTxt.Size = new System.Drawing.Size(206, 23);
            this.IdTxt.TabIndex = 9;
            // 
            // StatusCmbx
            // 
            this.StatusCmbx.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.StatusCmbx.FormattingEnabled = true;
            this.StatusCmbx.Items.AddRange(new object[] {
            "Approved",
            "Unapproved"});
            this.StatusCmbx.Location = new System.Drawing.Point(261, 213);
            this.StatusCmbx.Name = "StatusCmbx";
            this.StatusCmbx.Size = new System.Drawing.Size(206, 23);
            this.StatusCmbx.TabIndex = 17;
            // 
            // StatusLbl
            // 
            this.StatusLbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.StatusLbl.AutoSize = true;
            this.StatusLbl.Location = new System.Drawing.Point(262, 195);
            this.StatusLbl.Name = "StatusLbl";
            this.StatusLbl.Size = new System.Drawing.Size(39, 15);
            this.StatusLbl.TabIndex = 18;
            this.StatusLbl.Text = "Status";
            // 
            // DateClnd
            // 
            this.DateClnd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DateClnd.Location = new System.Drawing.Point(261, 268);
            this.DateClnd.Name = "DateClnd";
            this.DateClnd.Size = new System.Drawing.Size(206, 23);
            this.DateClnd.TabIndex = 19;
            // 
            // SaleIDTxt1
            // 
            this.SaleIDTxt1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SaleIDTxt1.Location = new System.Drawing.Point(261, 104);
            this.SaleIDTxt1.Name = "SaleIDTxt1";
            this.SaleIDTxt1.Size = new System.Drawing.Size(206, 23);
            this.SaleIDTxt1.TabIndex = 20;
            // 
            // SupplierIDTxt1
            // 
            this.SupplierIDTxt1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SupplierIDTxt1.Location = new System.Drawing.Point(261, 159);
            this.SupplierIDTxt1.Name = "SupplierIDTxt1";
            this.SupplierIDTxt1.Size = new System.Drawing.Size(206, 23);
            this.SupplierIDTxt1.TabIndex = 21;
            // 
            // DeleteBtn
            // 
            this.DeleteBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DeleteBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.DeleteBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.DeleteBtn.Location = new System.Drawing.Point(392, 340);
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.Size = new System.Drawing.Size(75, 23);
            this.DeleteBtn.TabIndex = 22;
            this.DeleteBtn.Text = "Delete";
            this.DeleteBtn.UseVisualStyleBackColor = false;
            this.DeleteBtn.Click += new System.EventHandler(this.DeleteBtn_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(180)))), ((int)(((byte)(194)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(20, 461);
            this.panel1.TabIndex = 23;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(180)))), ((int)(((byte)(194)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(764, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(20, 461);
            this.panel2.TabIndex = 24;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(180)))), ((int)(((byte)(194)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(20, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(744, 20);
            this.panel3.TabIndex = 25;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(180)))), ((int)(((byte)(194)))));
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(20, 441);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(744, 20);
            this.panel4.TabIndex = 26;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(245)))), ((int)(((byte)(247)))));
            this.panel5.Controls.Add(this.IdSupplierInvoiceLbl);
            this.panel5.Controls.Add(this.IdTxt);
            this.panel5.Controls.Add(this.SaleIDLbl);
            this.panel5.Controls.Add(this.SupplierIDLbl);
            this.panel5.Controls.Add(this.EditCbx);
            this.panel5.Controls.Add(this.DeleteBtn);
            this.panel5.Controls.Add(this.SaveEditCustomerBtn);
            this.panel5.Controls.Add(this.SupplierIDTxt1);
            this.panel5.Controls.Add(this.StatusCmbx);
            this.panel5.Controls.Add(this.SaleIDTxt1);
            this.panel5.Controls.Add(this.StatusLbl);
            this.panel5.Controls.Add(this.DateClnd);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(20, 20);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(744, 421);
            this.panel5.TabIndex = 27;
            // 
            // SupplierInvoiceDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "SupplierInvoiceDetailsForm";
            this.Text = "SupplierInvoiceDetailsForm";
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Button SaveEditCustomerBtn;
        private CheckBox EditCbx;
        private Label SupplierIDLbl;
        private Label SaleIDLbl;
        private Label IdSupplierInvoiceLbl;
        private TextBox IdTxt;
        private ComboBox StatusCmbx;
        private Label StatusLbl;
        private DateTimePicker DateClnd;
        private control.IntegerTextBoxUserControl SaleIDTxt1;
        private control.IntegerTextBoxUserControl SupplierIDTxt1;
        private Button DeleteBtn;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
    }
}