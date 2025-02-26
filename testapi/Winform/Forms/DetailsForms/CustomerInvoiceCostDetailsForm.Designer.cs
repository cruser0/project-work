namespace Winform.Forms.DetailsForms
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
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.QuantityTxt = new Winform.Forms.control.IntegerTextBoxUserControl();
            this.CustomerInvoiceIDtxt = new Winform.Forms.control.IntegerTextBoxUserControl();
            this.CostTxt = new Winform.Forms.control.DecimalTextBoxUserControl();
            this.CustomerInvoiceCostIDtxt = new System.Windows.Forms.TextBox();
            this.DeleteBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(216, 347);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 23);
            this.button1.TabIndex = 40;
            this.button1.Text = "Save Changes";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(114, 351);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(46, 19);
            this.checkBox1.TabIndex = 39;
            this.checkBox1.Text = "Edit";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(114, 285);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 15);
            this.label4.TabIndex = 38;
            this.label4.Text = "Quantity";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(114, 204);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 15);
            this.label3.TabIndex = 37;
            this.label3.Text = "Cost";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(114, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 15);
            this.label2.TabIndex = 36;
            this.label2.Text = "Customer Invoice ID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(115, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 15);
            this.label1.TabIndex = 35;
            this.label1.Text = "Customer Invoice Cost ID";
            // 
            // QuantityTxt
            // 
            this.QuantityTxt.Location = new System.Drawing.Point(114, 303);
            this.QuantityTxt.Name = "QuantityTxt";
            this.QuantityTxt.Size = new System.Drawing.Size(194, 23);
            this.QuantityTxt.TabIndex = 34;
            // 
            // SupplierInvoiceIDtxt
            // 
            this.CustomerInvoiceIDtxt.Location = new System.Drawing.Point(114, 146);
            this.CustomerInvoiceIDtxt.Name = "SupplierInvoiceIDtxt";
            this.CustomerInvoiceIDtxt.Size = new System.Drawing.Size(194, 23);
            this.CustomerInvoiceIDtxt.TabIndex = 33;
            // 
            // CostTxt
            // 
            this.CostTxt.Location = new System.Drawing.Point(114, 222);
            this.CostTxt.Name = "CostTxt";
            this.CostTxt.Size = new System.Drawing.Size(194, 23);
            this.CostTxt.TabIndex = 32;
            // 
            // SupplierInvoiceCostIDtxt
            // 
            this.CustomerInvoiceCostIDtxt.Location = new System.Drawing.Point(114, 73);
            this.CustomerInvoiceCostIDtxt.Name = "SupplierInvoiceCostIDtxt";
            this.CustomerInvoiceCostIDtxt.Size = new System.Drawing.Size(194, 23);
            this.CustomerInvoiceCostIDtxt.TabIndex = 31;
            // 
            // DeleteBtn
            // 
            this.DeleteBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.DeleteBtn.Location = new System.Drawing.Point(611, 372);
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.Size = new System.Drawing.Size(75, 23);
            this.DeleteBtn.TabIndex = 30;
            this.DeleteBtn.Text = "Delete";
            this.DeleteBtn.UseVisualStyleBackColor = true;
            // 
            // CustomerInvoiceCostDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.QuantityTxt);
            this.Controls.Add(this.CustomerInvoiceIDtxt);
            this.Controls.Add(this.CostTxt);
            this.Controls.Add(this.CustomerInvoiceCostIDtxt);
            this.Controls.Add(this.DeleteBtn);
            this.Name = "CustomerInvoiceCostDetailsForm";
            this.Text = "CustomerInvoiceCostDetailsForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button button1;
        private CheckBox checkBox1;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private control.IntegerTextBoxUserControl QuantityTxt;
        private control.IntegerTextBoxUserControl CustomerInvoiceIDtxt;
        private control.DecimalTextBoxUserControl CostTxt;
        private TextBox CustomerInvoiceCostIDtxt;
        private Button DeleteBtn;
    }
}