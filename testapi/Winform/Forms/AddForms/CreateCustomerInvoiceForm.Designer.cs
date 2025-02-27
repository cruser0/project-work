namespace Winform.Forms.AddForms
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
            this.integerTextBoxUserControl1 = new Winform.Forms.control.IntegerTextBoxUserControl();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.OpenSale = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(302, 209);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 15);
            this.label2.TabIndex = 19;
            this.label2.Text = "Invoice Date *";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(300, 227);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.ShowCheckBox = true;
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 23);
            this.dateTimePicker1.TabIndex = 18;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.NameTxt_TextChanged);
            // 
            // integerTextBoxUserControl1
            // 
            this.integerTextBoxUserControl1.Location = new System.Drawing.Point(300, 174);
            this.integerTextBoxUserControl1.Name = "integerTextBoxUserControl1";
            this.integerTextBoxUserControl1.Size = new System.Drawing.Size(200, 23);
            this.integerTextBoxUserControl1.TabIndex = 17;
            // 
            // SaveBtn
            // 
            this.SaveBtn.Enabled = false;
            this.SaveBtn.Location = new System.Drawing.Point(425, 278);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(75, 23);
            this.SaveBtn.TabIndex = 16;
            this.SaveBtn.Text = "Save";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(302, 149);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 15);
            this.label1.TabIndex = 15;
            this.label1.Text = "Sale ID *";
            // 
            // OpenSale
            // 
            this.OpenSale.FlatAppearance.BorderSize = 0;
            this.OpenSale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OpenSale.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            this.OpenSale.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.OpenSale.Location = new System.Drawing.Point(506, 174);
            this.OpenSale.Name = "OpenSale";
            this.OpenSale.Size = new System.Drawing.Size(64, 23);
            this.OpenSale.TabIndex = 32;
            this.OpenSale.Text = "Open-->";
            this.OpenSale.UseVisualStyleBackColor = true;
            this.OpenSale.Click += new System.EventHandler(this.OpenSale_Click);
            // 
            // CreateCustomerInvoiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.OpenSale);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.integerTextBoxUserControl1);
            this.Controls.Add(this.SaveBtn);
            this.Controls.Add(this.label1);
            this.Name = "CreateCustomerInvoiceForm";
            this.Text = "CreateCustomerInvoiceForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label2;
        private DateTimePicker dateTimePicker1;
        private control.IntegerTextBoxUserControl integerTextBoxUserControl1;
        private Button SaveBtn;
        private Label label1;
        private Button OpenSale;
    }
}