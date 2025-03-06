namespace Winform.Forms
{
    partial class SupplierInvoiceCostDetailsForm
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
            this.SupplierInvoiceCostIDtxt = new System.Windows.Forms.TextBox();
            this.CostTxt = new Winform.Forms.control.DecimalTextBoxUserControl();
            this.SupplierInvoiceIDtxt = new Winform.Forms.control.IntegerTextBoxUserControl();
            this.QuantityTxt = new Winform.Forms.control.IntegerTextBoxUserControl();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DeleteBtn
            // 
            this.DeleteBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.DeleteBtn.Location = new System.Drawing.Point(430, 390);
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.Size = new System.Drawing.Size(75, 23);
            this.DeleteBtn.TabIndex = 19;
            this.DeleteBtn.Text = "Delete";
            this.DeleteBtn.UseVisualStyleBackColor = true;
            this.DeleteBtn.Click += new System.EventHandler(this.DeleteBtn_Click);
            // 
            // SupplierInvoiceCostIDtxt
            // 
            this.SupplierInvoiceCostIDtxt.Location = new System.Drawing.Point(216, 116);
            this.SupplierInvoiceCostIDtxt.Name = "SupplierInvoiceCostIDtxt";
            this.SupplierInvoiceCostIDtxt.Size = new System.Drawing.Size(194, 23);
            this.SupplierInvoiceCostIDtxt.TabIndex = 20;
            // 
            // CostTxt
            // 
            this.CostTxt.Location = new System.Drawing.Point(216, 265);
            this.CostTxt.Name = "CostTxt";
            this.CostTxt.Size = new System.Drawing.Size(194, 23);
            this.CostTxt.TabIndex = 21;
            // 
            // SupplierInvoiceIDtxt
            // 
            this.SupplierInvoiceIDtxt.Location = new System.Drawing.Point(216, 189);
            this.SupplierInvoiceIDtxt.Name = "SupplierInvoiceIDtxt";
            this.SupplierInvoiceIDtxt.Size = new System.Drawing.Size(194, 23);
            this.SupplierInvoiceIDtxt.TabIndex = 22;
            // 
            // QuantityTxt
            // 
            this.QuantityTxt.Location = new System.Drawing.Point(216, 346);
            this.QuantityTxt.Name = "QuantityTxt";
            this.QuantityTxt.Size = new System.Drawing.Size(194, 23);
            this.QuantityTxt.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(217, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 15);
            this.label1.TabIndex = 24;
            this.label1.Text = "Supplier Invoice Cost ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(216, 171);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 15);
            this.label2.TabIndex = 25;
            this.label2.Text = "Supplier Invoice ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(216, 247);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 15);
            this.label3.TabIndex = 26;
            this.label3.Text = "Cost";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(216, 328);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 15);
            this.label4.TabIndex = 27;
            this.label4.Text = "Quantity";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(216, 394);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(46, 19);
            this.checkBox1.TabIndex = 28;
            this.checkBox1.Text = "Edit";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.EditCB_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(318, 390);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 23);
            this.button1.TabIndex = 29;
            this.button1.Text = "Save Changes";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // SupplierInvoiceCostDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.QuantityTxt);
            this.Controls.Add(this.SupplierInvoiceIDtxt);
            this.Controls.Add(this.CostTxt);
            this.Controls.Add(this.SupplierInvoiceCostIDtxt);
            this.Controls.Add(this.DeleteBtn);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "SupplierInvoiceCostDetailsForm";
            this.Text = "SupplierInvoiceCostDetailsForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button DeleteBtn;
        private TextBox SupplierInvoiceCostIDtxt;
        private control.DecimalTextBoxUserControl CostTxt;
        private control.IntegerTextBoxUserControl SupplierInvoiceIDtxt;
        private control.IntegerTextBoxUserControl QuantityTxt;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private CheckBox checkBox1;
        private Button button1;
    }
}