namespace Winform.Forms
{
    partial class CustomerInvoiceDetailsForm
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
            this.DeleteBtn = new System.Windows.Forms.Button();
            this.CustomerInvoiceIdTxt = new System.Windows.Forms.TextBox();
            this.SaleIdTxt = new Winform.Forms.control.IntegerTextBoxUserControl();
            this.InvoiceDateDTP = new System.Windows.Forms.DateTimePicker();
            this.StatusCB = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.InvoiceAmountTxt = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DeleteBtn
            // 
            this.DeleteBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.DeleteBtn.Location = new System.Drawing.Point(479, 329);
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.Size = new System.Drawing.Size(75, 23);
            this.DeleteBtn.TabIndex = 19;
            this.DeleteBtn.Text = "Delete";
            this.DeleteBtn.UseVisualStyleBackColor = true;
            this.DeleteBtn.Click += new System.EventHandler(this.DeleteBtn_Click_1);
            // 
            // CustomerInvoiceIdTxt
            // 
            this.CustomerInvoiceIdTxt.Location = new System.Drawing.Point(279, 79);
            this.CustomerInvoiceIdTxt.Name = "CustomerInvoiceIdTxt";
            this.CustomerInvoiceIdTxt.Size = new System.Drawing.Size(194, 23);
            this.CustomerInvoiceIdTxt.TabIndex = 20;
            // 
            // SaleIdTxt
            // 
            this.SaleIdTxt.Location = new System.Drawing.Point(279, 145);
            this.SaleIdTxt.Name = "SaleIdTxt";
            this.SaleIdTxt.Size = new System.Drawing.Size(194, 23);
            this.SaleIdTxt.TabIndex = 21;
            // 
            // InvoiceDateDTP
            // 
            this.InvoiceDateDTP.Location = new System.Drawing.Point(279, 239);
            this.InvoiceDateDTP.Name = "InvoiceDateDTP";
            this.InvoiceDateDTP.Size = new System.Drawing.Size(194, 23);
            this.InvoiceDateDTP.TabIndex = 22;
            // 
            // StatusCB
            // 
            this.StatusCB.FormattingEnabled = true;
            this.StatusCB.Items.AddRange(new object[] {
            "Paid",
            "Unpaid"});
            this.StatusCB.Location = new System.Drawing.Point(279, 283);
            this.StatusCB.Name = "StatusCB";
            this.StatusCB.Size = new System.Drawing.Size(194, 23);
            this.StatusCB.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(279, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 15);
            this.label1.TabIndex = 24;
            this.label1.Text = "Customer Invoice Id";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(279, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 15);
            this.label2.TabIndex = 25;
            this.label2.Text = "Sale Id";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(279, 221);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 15);
            this.label3.TabIndex = 26;
            this.label3.Text = "Invoice Date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(279, 265);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 15);
            this.label4.TabIndex = 27;
            this.label4.Text = "Status";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(279, 177);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 15);
            this.label5.TabIndex = 29;
            this.label5.Text = "Invoice Amount";
            // 
            // InvoiceAmountTxt
            // 
            this.InvoiceAmountTxt.Location = new System.Drawing.Point(279, 195);
            this.InvoiceAmountTxt.Name = "InvoiceAmountTxt";
            this.InvoiceAmountTxt.Size = new System.Drawing.Size(194, 23);
            this.InvoiceAmountTxt.TabIndex = 28;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(282, 333);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(46, 19);
            this.checkBox1.TabIndex = 30;
            this.checkBox1.Text = "Edit";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(380, 329);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 23);
            this.button1.TabIndex = 31;
            this.button1.Text = "Save Changes";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CustomerInvoiceDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.InvoiceAmountTxt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.StatusCB);
            this.Controls.Add(this.InvoiceDateDTP);
            this.Controls.Add(this.SaleIdTxt);
            this.Controls.Add(this.CustomerInvoiceIdTxt);
            this.Controls.Add(this.DeleteBtn);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "CustomerInvoiceDetailsForm";
            this.Text = "CustomerInvoiceDetailsForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button DeleteBtn;
        private TextBox CustomerInvoiceIdTxt;
        private control.IntegerTextBoxUserControl SaleIdTxt;
        private DateTimePicker InvoiceDateDTP;
        private ComboBox StatusCB;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox InvoiceAmountTxt;
        private CheckBox checkBox1;
        private Button button1;
    }
}