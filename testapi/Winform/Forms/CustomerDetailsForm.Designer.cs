namespace Winform.Forms
{
    partial class CustomerDetailsForm
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
            this.NameCustomerTxt = new System.Windows.Forms.TextBox();
            this.NameCustomerLbl = new System.Windows.Forms.Label();
            this.IdCustomerLbl = new System.Windows.Forms.Label();
            this.EditCustomerCbx = new System.Windows.Forms.CheckBox();
            this.CountryCustomerLbl = new System.Windows.Forms.Label();
            this.CountryCustomerTxt = new System.Windows.Forms.TextBox();
            this.SaveEditCustomerBtn = new System.Windows.Forms.Button();
            this.StatusLbl = new System.Windows.Forms.Label();
            this.StatusTxt = new System.Windows.Forms.TextBox();
            this.IdCustomerTxt = new System.Windows.Forms.TextBox();
            this.DeleteBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // NameCustomerTxt
            // 
            this.NameCustomerTxt.Location = new System.Drawing.Point(324, 195);
            this.NameCustomerTxt.Name = "NameCustomerTxt";
            this.NameCustomerTxt.Size = new System.Drawing.Size(100, 23);
            this.NameCustomerTxt.TabIndex = 2;
            // 
            // NameCustomerLbl
            // 
            this.NameCustomerLbl.AutoSize = true;
            this.NameCustomerLbl.Location = new System.Drawing.Point(326, 179);
            this.NameCustomerLbl.Name = "NameCustomerLbl";
            this.NameCustomerLbl.Size = new System.Drawing.Size(39, 15);
            this.NameCustomerLbl.TabIndex = 5;
            this.NameCustomerLbl.Text = "Name";
            // 
            // IdCustomerLbl
            // 
            this.IdCustomerLbl.AutoSize = true;
            this.IdCustomerLbl.Location = new System.Drawing.Point(326, 85);
            this.IdCustomerLbl.Name = "IdCustomerLbl";
            this.IdCustomerLbl.Size = new System.Drawing.Size(17, 15);
            this.IdCustomerLbl.TabIndex = 4;
            this.IdCustomerLbl.Text = "Id";
            // 
            // EditCustomerCbx
            // 
            this.EditCustomerCbx.AutoSize = true;
            this.EditCustomerCbx.Location = new System.Drawing.Point(324, 290);
            this.EditCustomerCbx.Name = "EditCustomerCbx";
            this.EditCustomerCbx.Size = new System.Drawing.Size(46, 19);
            this.EditCustomerCbx.TabIndex = 7;
            this.EditCustomerCbx.Text = "Edit";
            this.EditCustomerCbx.UseVisualStyleBackColor = true;
            this.EditCustomerCbx.CheckedChanged += new System.EventHandler(this.EditCustomerCbx_CheckedChanged);
            // 
            // CountryCustomerLbl
            // 
            this.CountryCustomerLbl.AutoSize = true;
            this.CountryCustomerLbl.Location = new System.Drawing.Point(326, 228);
            this.CountryCustomerLbl.Name = "CountryCustomerLbl";
            this.CountryCustomerLbl.Size = new System.Drawing.Size(50, 15);
            this.CountryCustomerLbl.TabIndex = 6;
            this.CountryCustomerLbl.Text = "Country";
            this.CountryCustomerLbl.Click += new System.EventHandler(this.CountryCustomerLbl_Click);
            // 
            // CountryCustomerTxt
            // 
            this.CountryCustomerTxt.Location = new System.Drawing.Point(324, 246);
            this.CountryCustomerTxt.Name = "CountryCustomerTxt";
            this.CountryCustomerTxt.Size = new System.Drawing.Size(100, 23);
            this.CountryCustomerTxt.TabIndex = 3;
            // 
            // SaveEditCustomerBtn
            // 
            this.SaveEditCustomerBtn.Location = new System.Drawing.Point(324, 315);
            this.SaveEditCustomerBtn.Name = "SaveEditCustomerBtn";
            this.SaveEditCustomerBtn.Size = new System.Drawing.Size(107, 23);
            this.SaveEditCustomerBtn.TabIndex = 8;
            this.SaveEditCustomerBtn.Text = "Save changes";
            this.SaveEditCustomerBtn.UseVisualStyleBackColor = true;
            this.SaveEditCustomerBtn.Click += new System.EventHandler(this.SaveEditCustomerBtn_Click);
            // 
            // StatusLbl
            // 
            this.StatusLbl.AutoSize = true;
            this.StatusLbl.Location = new System.Drawing.Point(326, 129);
            this.StatusLbl.Name = "StatusLbl";
            this.StatusLbl.Size = new System.Drawing.Size(39, 15);
            this.StatusLbl.TabIndex = 10;
            this.StatusLbl.Text = "Status";
            // 
            // StatusTxt
            // 
            this.StatusTxt.Location = new System.Drawing.Point(324, 147);
            this.StatusTxt.Name = "StatusTxt";
            this.StatusTxt.Size = new System.Drawing.Size(100, 23);
            this.StatusTxt.TabIndex = 9;
            // 
            // IdCustomerTxt
            // 
            this.IdCustomerTxt.Location = new System.Drawing.Point(324, 103);
            this.IdCustomerTxt.Name = "IdCustomerTxt";
            this.IdCustomerTxt.Size = new System.Drawing.Size(100, 23);
            this.IdCustomerTxt.TabIndex = 11;
            // 
            // DeleteBtn
            // 
            this.DeleteBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.DeleteBtn.Location = new System.Drawing.Point(713, 415);
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.Size = new System.Drawing.Size(75, 23);
            this.DeleteBtn.TabIndex = 23;
            this.DeleteBtn.Text = "Delete";
            this.DeleteBtn.UseVisualStyleBackColor = true;
            this.DeleteBtn.Click += new System.EventHandler(this.DeleteBtn_Click);
            // 
            // CustomerDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DeleteBtn);
            this.Controls.Add(this.IdCustomerTxt);
            this.Controls.Add(this.StatusLbl);
            this.Controls.Add(this.StatusTxt);
            this.Controls.Add(this.SaveEditCustomerBtn);
            this.Controls.Add(this.EditCustomerCbx);
            this.Controls.Add(this.CountryCustomerLbl);
            this.Controls.Add(this.NameCustomerLbl);
            this.Controls.Add(this.IdCustomerLbl);
            this.Controls.Add(this.CountryCustomerTxt);
            this.Controls.Add(this.NameCustomerTxt);
            this.Name = "CustomerDetailsForm";
            this.Text = "CustomerDetailsForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox NameCustomerTxt;
        private Label NameCustomerLbl;
        private Label IdCustomerLbl;
        private CheckBox EditCustomerCbx;
        private Label CountryCustomerLbl;
        private TextBox CountryCustomerTxt;
        private Button SaveEditCustomerBtn;
        private Label StatusLbl;
        private TextBox StatusTxt;
        private TextBox IdCustomerTxt;
        private Button DeleteBtn;
    }
}