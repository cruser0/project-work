using System.Windows.Forms;

namespace WinformDotNetFramework.Forms.control
{
    partial class SearchCustomerInvoice
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
            this.TextBoxesRightPanel = new System.Windows.Forms.Panel();
            this.CustomerInvoiceCodeTxt = new System.Windows.Forms.TextBox();
            this.CustomerInvoiceCodeLbl = new System.Windows.Forms.Label();
            this.InvoiceSaleBkTxt = new System.Windows.Forms.TextBox();
            this.InvoiceSaleBKLbl = new System.Windows.Forms.Label();
            this.InvoiceBoLTxt = new System.Windows.Forms.TextBox();
            this.InvoiceSaleBoLLbl = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.AmountToTxt = new WinformDotNetFramework.Forms.control.IntegerTextBoxUserControl();
            this.AmountFromTxt = new WinformDotNetFramework.Forms.control.IntegerTextBoxUserControl();
            this.label1 = new System.Windows.Forms.Label();
            this.DateFromLbl = new System.Windows.Forms.Label();
            this.DateToLbl = new System.Windows.Forms.Label();
            this.StatusCmb = new System.Windows.Forms.ComboBox();
            this.DateToClnd = new System.Windows.Forms.DateTimePicker();
            this.DateFromClnd = new System.Windows.Forms.DateTimePicker();
            this.TextBoxesRightPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // TextBoxesRightPanel
            // 
            this.TextBoxesRightPanel.AutoScrollMargin = new System.Drawing.Size(0, 20);
            this.TextBoxesRightPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.TextBoxesRightPanel.Controls.Add(this.CustomerInvoiceCodeTxt);
            this.TextBoxesRightPanel.Controls.Add(this.CustomerInvoiceCodeLbl);
            this.TextBoxesRightPanel.Controls.Add(this.InvoiceSaleBkTxt);
            this.TextBoxesRightPanel.Controls.Add(this.InvoiceSaleBKLbl);
            this.TextBoxesRightPanel.Controls.Add(this.InvoiceBoLTxt);
            this.TextBoxesRightPanel.Controls.Add(this.InvoiceSaleBoLLbl);
            this.TextBoxesRightPanel.Controls.Add(this.label4);
            this.TextBoxesRightPanel.Controls.Add(this.label3);
            this.TextBoxesRightPanel.Controls.Add(this.label2);
            this.TextBoxesRightPanel.Controls.Add(this.AmountToTxt);
            this.TextBoxesRightPanel.Controls.Add(this.AmountFromTxt);
            this.TextBoxesRightPanel.Controls.Add(this.label1);
            this.TextBoxesRightPanel.Controls.Add(this.DateFromLbl);
            this.TextBoxesRightPanel.Controls.Add(this.DateToLbl);
            this.TextBoxesRightPanel.Controls.Add(this.StatusCmb);
            this.TextBoxesRightPanel.Controls.Add(this.DateToClnd);
            this.TextBoxesRightPanel.Controls.Add(this.DateFromClnd);
            this.TextBoxesRightPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBoxesRightPanel.Location = new System.Drawing.Point(0, 0);
            this.TextBoxesRightPanel.Name = "TextBoxesRightPanel";
            this.TextBoxesRightPanel.Size = new System.Drawing.Size(200, 353);
            this.TextBoxesRightPanel.TabIndex = 9;
            // 
            // CustomerInvoiceCodeTxt
            // 
            this.CustomerInvoiceCodeTxt.BackColor = System.Drawing.SystemColors.Window;
            this.CustomerInvoiceCodeTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CustomerInvoiceCodeTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.CustomerInvoiceCodeTxt.Location = new System.Drawing.Point(3, 326);
            this.CustomerInvoiceCodeTxt.MaxLength = 100;
            this.CustomerInvoiceCodeTxt.Name = "CustomerInvoiceCodeTxt";
            this.CustomerInvoiceCodeTxt.Size = new System.Drawing.Size(180, 20);
            this.CustomerInvoiceCodeTxt.TabIndex = 27;
            // 
            // CustomerInvoiceCodeLbl
            // 
            this.CustomerInvoiceCodeLbl.AutoSize = true;
            this.CustomerInvoiceCodeLbl.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.CustomerInvoiceCodeLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.CustomerInvoiceCodeLbl.Location = new System.Drawing.Point(3, 307);
            this.CustomerInvoiceCodeLbl.Name = "CustomerInvoiceCodeLbl";
            this.CustomerInvoiceCodeLbl.Size = new System.Drawing.Size(150, 17);
            this.CustomerInvoiceCodeLbl.TabIndex = 28;
            this.CustomerInvoiceCodeLbl.Text = "Customer Invoice Code";
            // 
            // InvoiceSaleBkTxt
            // 
            this.InvoiceSaleBkTxt.BackColor = System.Drawing.SystemColors.Window;
            this.InvoiceSaleBkTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.InvoiceSaleBkTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.InvoiceSaleBkTxt.Location = new System.Drawing.Point(3, 285);
            this.InvoiceSaleBkTxt.MaxLength = 100;
            this.InvoiceSaleBkTxt.Name = "InvoiceSaleBkTxt";
            this.InvoiceSaleBkTxt.Size = new System.Drawing.Size(180, 20);
            this.InvoiceSaleBkTxt.TabIndex = 25;
            // 
            // InvoiceSaleBKLbl
            // 
            this.InvoiceSaleBKLbl.AutoSize = true;
            this.InvoiceSaleBKLbl.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.InvoiceSaleBKLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.InvoiceSaleBKLbl.Location = new System.Drawing.Point(3, 266);
            this.InvoiceSaleBKLbl.Name = "InvoiceSaleBKLbl";
            this.InvoiceSaleBKLbl.Size = new System.Drawing.Size(142, 17);
            this.InvoiceSaleBKLbl.TabIndex = 26;
            this.InvoiceSaleBKLbl.Text = "Sale Booking Number";
            // 
            // InvoiceBoLTxt
            // 
            this.InvoiceBoLTxt.BackColor = System.Drawing.SystemColors.Window;
            this.InvoiceBoLTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.InvoiceBoLTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.InvoiceBoLTxt.Location = new System.Drawing.Point(3, 244);
            this.InvoiceBoLTxt.MaxLength = 100;
            this.InvoiceBoLTxt.Name = "InvoiceBoLTxt";
            this.InvoiceBoLTxt.Size = new System.Drawing.Size(180, 20);
            this.InvoiceBoLTxt.TabIndex = 23;
            // 
            // InvoiceSaleBoLLbl
            // 
            this.InvoiceSaleBoLLbl.AutoSize = true;
            this.InvoiceSaleBoLLbl.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.InvoiceSaleBoLLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.InvoiceSaleBoLLbl.Location = new System.Drawing.Point(3, 225);
            this.InvoiceSaleBoLLbl.Name = "InvoiceSaleBoLLbl";
            this.InvoiceSaleBoLLbl.Size = new System.Drawing.Size(60, 17);
            this.InvoiceSaleBoLLbl.TabIndex = 24;
            this.InvoiceSaleBoLLbl.Text = "Sale BoL";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 17);
            this.label4.TabIndex = 20;
            this.label4.Text = "Customer Invoice";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.label3.Location = new System.Drawing.Point(3, 184);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 17);
            this.label3.TabIndex = 15;
            this.label3.Text = "Invoice Amount To";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.label2.Location = new System.Drawing.Point(3, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 17);
            this.label2.TabIndex = 14;
            this.label2.Text = "Invoice Amount From";
            // 
            // AmountToTxt
            // 
            this.AmountToTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.AmountToTxt.Location = new System.Drawing.Point(3, 203);
            this.AmountToTxt.Name = "AmountToTxt";
            this.AmountToTxt.Size = new System.Drawing.Size(180, 20);
            this.AmountToTxt.TabIndex = 13;
            // 
            // AmountFromTxt
            // 
            this.AmountFromTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.AmountFromTxt.Location = new System.Drawing.Point(3, 162);
            this.AmountFromTxt.Name = "AmountFromTxt";
            this.AmountFromTxt.Size = new System.Drawing.Size(180, 20);
            this.AmountFromTxt.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.label1.Location = new System.Drawing.Point(3, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "Date To";
            // 
            // DateFromLbl
            // 
            this.DateFromLbl.AutoSize = true;
            this.DateFromLbl.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.DateFromLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.DateFromLbl.Location = new System.Drawing.Point(3, 19);
            this.DateFromLbl.Name = "DateFromLbl";
            this.DateFromLbl.Size = new System.Drawing.Size(73, 17);
            this.DateFromLbl.TabIndex = 9;
            this.DateFromLbl.Text = "Date From";
            // 
            // DateToLbl
            // 
            this.DateToLbl.AutoSize = true;
            this.DateToLbl.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.DateToLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.DateToLbl.Location = new System.Drawing.Point(3, 101);
            this.DateToLbl.Name = "DateToLbl";
            this.DateToLbl.Size = new System.Drawing.Size(46, 17);
            this.DateToLbl.TabIndex = 6;
            this.DateToLbl.Text = "Status";
            // 
            // StatusCmb
            // 
            this.StatusCmb.BackColor = System.Drawing.SystemColors.Window;
            this.StatusCmb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.StatusCmb.FormattingEnabled = true;
            this.StatusCmb.Items.AddRange(new object[] {
            "All",
            "Paid",
            "Unpaid"});
            this.StatusCmb.Location = new System.Drawing.Point(3, 120);
            this.StatusCmb.Name = "StatusCmb";
            this.StatusCmb.Size = new System.Drawing.Size(180, 21);
            this.StatusCmb.TabIndex = 5;
            // 
            // DateToClnd
            // 
            this.DateToClnd.Checked = false;
            this.DateToClnd.CustomFormat = "ddMMMMyyyy";
            this.DateToClnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DateToClnd.Location = new System.Drawing.Point(3, 79);
            this.DateToClnd.Name = "DateToClnd";
            this.DateToClnd.ShowCheckBox = true;
            this.DateToClnd.Size = new System.Drawing.Size(180, 20);
            this.DateToClnd.TabIndex = 6;
            // 
            // DateFromClnd
            // 
            this.DateFromClnd.Checked = false;
            this.DateFromClnd.CustomFormat = "ddMMMMyyyy";
            this.DateFromClnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DateFromClnd.Location = new System.Drawing.Point(3, 38);
            this.DateFromClnd.Name = "DateFromClnd";
            this.DateFromClnd.ShowCheckBox = true;
            this.DateFromClnd.Size = new System.Drawing.Size(180, 20);
            this.DateFromClnd.TabIndex = 5;
            // 
            // SearchCustomerInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TextBoxesRightPanel);
            this.Name = "SearchCustomerInvoice";
            this.Size = new System.Drawing.Size(200, 353);
            this.TextBoxesRightPanel.ResumeLayout(false);
            this.TextBoxesRightPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel TextBoxesRightPanel;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label DateFromLbl;
        private Label DateToLbl;
        private Label label4;
        public IntegerTextBoxUserControl AmountToTxt;
        public IntegerTextBoxUserControl AmountFromTxt;
        public ComboBox StatusCmb;
        public DateTimePicker DateToClnd;
        public DateTimePicker DateFromClnd;
        public TextBox InvoiceSaleBkTxt;
        private Label InvoiceSaleBKLbl;
        public TextBox InvoiceBoLTxt;
        private Label InvoiceSaleBoLLbl;
        public TextBox CustomerInvoiceCodeTxt;
        private Label CustomerInvoiceCodeLbl;
    }
}
