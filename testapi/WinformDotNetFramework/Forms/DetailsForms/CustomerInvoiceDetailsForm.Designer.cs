using System.Windows.Forms;

namespace WinformDotNetFramework.Forms.DetailsForms
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
            this.CustomerInvoiceIdTxt = new System.Windows.Forms.TextBox();
            this.SaleIdTxt = new WinformDotNetFramework.Forms.control.IntegerTextBoxUserControl();
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CustomerInvoiceIdTxt
            // 
            this.CustomerInvoiceIdTxt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CustomerInvoiceIdTxt.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustomerInvoiceIdTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.CustomerInvoiceIdTxt.Location = new System.Drawing.Point(293, 95);
            this.CustomerInvoiceIdTxt.Name = "CustomerInvoiceIdTxt";
            this.CustomerInvoiceIdTxt.Size = new System.Drawing.Size(200, 23);
            this.CustomerInvoiceIdTxt.TabIndex = 20;
            // 
            // SaleIdTxt
            // 
            this.SaleIdTxt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SaleIdTxt.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaleIdTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.SaleIdTxt.Location = new System.Drawing.Point(293, 139);
            this.SaleIdTxt.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.SaleIdTxt.Name = "SaleIdTxt";
            this.SaleIdTxt.Size = new System.Drawing.Size(200, 25);
            this.SaleIdTxt.TabIndex = 21;
            // 
            // InvoiceDateDTP
            // 
            this.InvoiceDateDTP.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.InvoiceDateDTP.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InvoiceDateDTP.Location = new System.Drawing.Point(293, 229);
            this.InvoiceDateDTP.Name = "InvoiceDateDTP";
            this.InvoiceDateDTP.Size = new System.Drawing.Size(200, 23);
            this.InvoiceDateDTP.TabIndex = 22;
            // 
            // StatusCB
            // 
            this.StatusCB.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.StatusCB.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusCB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.StatusCB.FormattingEnabled = true;
            this.StatusCB.Items.AddRange(new object[] {
            "Paid",
            "Unpaid"});
            this.StatusCB.Location = new System.Drawing.Point(292, 273);
            this.StatusCB.Name = "StatusCB";
            this.StatusCB.Size = new System.Drawing.Size(200, 23);
            this.StatusCB.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.label1.Location = new System.Drawing.Point(293, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 15);
            this.label1.TabIndex = 24;
            this.label1.Text = "Customer Invoice Id";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.label2.Location = new System.Drawing.Point(293, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 15);
            this.label2.TabIndex = 25;
            this.label2.Text = "Sale Id";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.label3.Location = new System.Drawing.Point(293, 211);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 15);
            this.label3.TabIndex = 26;
            this.label3.Text = "Invoice Date";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.label4.Location = new System.Drawing.Point(293, 255);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 15);
            this.label4.TabIndex = 27;
            this.label4.Text = "Status";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.label5.Location = new System.Drawing.Point(293, 167);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 15);
            this.label5.TabIndex = 29;
            this.label5.Text = "Invoice Amount";
            // 
            // InvoiceAmountTxt
            // 
            this.InvoiceAmountTxt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.InvoiceAmountTxt.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InvoiceAmountTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.InvoiceAmountTxt.Location = new System.Drawing.Point(293, 185);
            this.InvoiceAmountTxt.Name = "InvoiceAmountTxt";
            this.InvoiceAmountTxt.Size = new System.Drawing.Size(200, 23);
            this.InvoiceAmountTxt.TabIndex = 28;
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.checkBox1.Location = new System.Drawing.Point(446, 302);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(46, 19);
            this.checkBox1.TabIndex = 30;
            this.checkBox1.Text = "Edit";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.button1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.button1.Location = new System.Drawing.Point(412, 327);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 25);
            this.button1.TabIndex = 31;
            this.button1.Text = "Save Changes";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(245)))), ((int)(((byte)(247)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.CustomerInvoiceIdTxt);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.SaleIdTxt);
            this.panel1.Controls.Add(this.InvoiceAmountTxt);
            this.panel1.Controls.Add(this.InvoiceDateDTP);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.StatusCB);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.panel1.Location = new System.Drawing.Point(17, 17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(750, 427);
            this.panel1.TabIndex = 32;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(180)))), ((int)(((byte)(194)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(17, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(750, 17);
            this.panel2.TabIndex = 33;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(180)))), ((int)(((byte)(194)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(17, 444);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(750, 17);
            this.panel3.TabIndex = 34;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(180)))), ((int)(((byte)(194)))));
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(767, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(17, 461);
            this.panel4.TabIndex = 35;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(180)))), ((int)(((byte)(194)))));
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(17, 461);
            this.panel5.TabIndex = 36;
            // 
            // CustomerInvoiceDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "CustomerInvoiceDetailsForm";
            this.Text = "CustomerInvoiceDetailsForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
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
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
    }
}