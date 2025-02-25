namespace Winform.Forms.AddForms
{
    partial class CreateSaleForm
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
            this.CustomerIdtxt = new Winform.Forms.control.IntegerTextBoxUserControl();
            this.saleDateDtp = new System.Windows.Forms.DateTimePicker();
            this.boltxt = new System.Windows.Forms.TextBox();
            this.bntxt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.StatusLbl = new System.Windows.Forms.Label();
            this.StatusCmbx = new System.Windows.Forms.ComboBox();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.OpenSale = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CustomerIdtxt
            // 
            this.CustomerIdtxt.Location = new System.Drawing.Point(302, 246);
            this.CustomerIdtxt.Name = "CustomerIdtxt";
            this.CustomerIdtxt.Size = new System.Drawing.Size(194, 23);
            this.CustomerIdtxt.TabIndex = 23;
            // 
            // saleDateDtp
            // 
            this.saleDateDtp.Location = new System.Drawing.Point(302, 189);
            this.saleDateDtp.Name = "saleDateDtp";
            this.saleDateDtp.Size = new System.Drawing.Size(194, 23);
            this.saleDateDtp.TabIndex = 22;
            // 
            // boltxt
            // 
            this.boltxt.Location = new System.Drawing.Point(302, 135);
            this.boltxt.Name = "boltxt";
            this.boltxt.Size = new System.Drawing.Size(194, 23);
            this.boltxt.TabIndex = 21;
            // 
            // bntxt
            // 
            this.bntxt.Location = new System.Drawing.Point(303, 88);
            this.bntxt.Name = "bntxt";
            this.bntxt.Size = new System.Drawing.Size(194, 23);
            this.bntxt.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(302, 228);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 15);
            this.label5.TabIndex = 17;
            this.label5.Text = "Customer Id";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(302, 171);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 15);
            this.label4.TabIndex = 16;
            this.label4.Text = "Sale Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(302, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 15);
            this.label3.TabIndex = 15;
            this.label3.Text = "BoL Number";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(302, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 15);
            this.label2.TabIndex = 14;
            this.label2.Text = "Booking Number";
            // 
            // StatusLbl
            // 
            this.StatusLbl.AllowDrop = true;
            this.StatusLbl.AutoSize = true;
            this.StatusLbl.Location = new System.Drawing.Point(302, 287);
            this.StatusLbl.Name = "StatusLbl";
            this.StatusLbl.Size = new System.Drawing.Size(39, 15);
            this.StatusLbl.TabIndex = 29;
            this.StatusLbl.Text = "Status";
            // 
            // StatusCmbx
            // 
            this.StatusCmbx.AllowDrop = true;
            this.StatusCmbx.FormattingEnabled = true;
            this.StatusCmbx.Items.AddRange(new object[] {
            "Active",
            "Closed"});
            this.StatusCmbx.Location = new System.Drawing.Point(302, 305);
            this.StatusCmbx.Name = "StatusCmbx";
            this.StatusCmbx.Size = new System.Drawing.Size(194, 23);
            this.StatusCmbx.TabIndex = 28;
            // 
            // SaveBtn
            // 
            this.SaveBtn.AllowDrop = true;
            this.SaveBtn.Location = new System.Drawing.Point(302, 348);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(171, 23);
            this.SaveBtn.TabIndex = 30;
            this.SaveBtn.Text = "Create Supplier Invoice Cost";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // OpenSale
            // 
            this.OpenSale.FlatAppearance.BorderSize = 0;
            this.OpenSale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OpenSale.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            this.OpenSale.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.OpenSale.Location = new System.Drawing.Point(502, 246);
            this.OpenSale.Name = "OpenSale";
            this.OpenSale.Size = new System.Drawing.Size(64, 23);
            this.OpenSale.TabIndex = 31;
            this.OpenSale.Text = "Open-->";
            this.OpenSale.UseVisualStyleBackColor = true;
            this.OpenSale.Click += new System.EventHandler(this.OpenSale_Click);
            // 
            // CreateSaleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.OpenSale);
            this.Controls.Add(this.SaveBtn);
            this.Controls.Add(this.StatusLbl);
            this.Controls.Add(this.StatusCmbx);
            this.Controls.Add(this.CustomerIdtxt);
            this.Controls.Add(this.saleDateDtp);
            this.Controls.Add(this.boltxt);
            this.Controls.Add(this.bntxt);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "CreateSaleForm";
            this.Text = "CreateSaleForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private control.IntegerTextBoxUserControl CustomerIdtxt;
        private DateTimePicker saleDateDtp;
        private TextBox boltxt;
        private TextBox bntxt;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label StatusLbl;
        private ComboBox StatusCmbx;
        private Button SaveBtn;
        private Button OpenSale;
    }
}