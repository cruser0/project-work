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
            this.IdCustomerTxt = new System.Windows.Forms.TextBox();
            this.CountryCustomerTxt = new System.Windows.Forms.TextBox();
            this.IdCustomerLbl = new System.Windows.Forms.Label();
            this.NameCustomerLbl = new System.Windows.Forms.Label();
            this.CountryCustomerLbl = new System.Windows.Forms.Label();
            this.EditCustomerCbx = new System.Windows.Forms.CheckBox();
            this.SaveEditCustomerBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // NameCustomerTxt
            // 
            this.NameCustomerTxt.Location = new System.Drawing.Point(91, 163);
            this.NameCustomerTxt.Name = "NameCustomerTxt";
            this.NameCustomerTxt.Size = new System.Drawing.Size(100, 23);
            this.NameCustomerTxt.TabIndex = 2;
            // 
            // IdCustomerTxt
            // 
            this.IdCustomerTxt.Location = new System.Drawing.Point(91, 99);
            this.IdCustomerTxt.Name = "IdCustomerTxt";
            this.IdCustomerTxt.Size = new System.Drawing.Size(100, 23);
            this.IdCustomerTxt.TabIndex = 1;
            // 
            // CountryCustomerTxt
            // 
            this.CountryCustomerTxt.Location = new System.Drawing.Point(91, 230);
            this.CountryCustomerTxt.Name = "CountryCustomerTxt";
            this.CountryCustomerTxt.Size = new System.Drawing.Size(100, 23);
            this.CountryCustomerTxt.TabIndex = 3;
            // 
            // IdCustomerLbl
            // 
            this.IdCustomerLbl.AutoSize = true;
            this.IdCustomerLbl.Location = new System.Drawing.Point(93, 81);
            this.IdCustomerLbl.Name = "IdCustomerLbl";
            this.IdCustomerLbl.Size = new System.Drawing.Size(17, 15);
            this.IdCustomerLbl.TabIndex = 4;
            this.IdCustomerLbl.Text = "Id";
            // 
            // NameCustomerLbl
            // 
            this.NameCustomerLbl.AutoSize = true;
            this.NameCustomerLbl.Location = new System.Drawing.Point(93, 147);
            this.NameCustomerLbl.Name = "NameCustomerLbl";
            this.NameCustomerLbl.Size = new System.Drawing.Size(39, 15);
            this.NameCustomerLbl.TabIndex = 5;
            this.NameCustomerLbl.Text = "Name";
            // 
            // CountryCustomerLbl
            // 
            this.CountryCustomerLbl.AutoSize = true;
            this.CountryCustomerLbl.Location = new System.Drawing.Point(93, 212);
            this.CountryCustomerLbl.Name = "CountryCustomerLbl";
            this.CountryCustomerLbl.Size = new System.Drawing.Size(50, 15);
            this.CountryCustomerLbl.TabIndex = 6;
            this.CountryCustomerLbl.Text = "Country";
            // 
            // EditCustomerCbx
            // 
            this.EditCustomerCbx.AutoSize = true;
            this.EditCustomerCbx.Location = new System.Drawing.Point(91, 261);
            this.EditCustomerCbx.Name = "EditCustomerCbx";
            this.EditCustomerCbx.Size = new System.Drawing.Size(46, 19);
            this.EditCustomerCbx.TabIndex = 7;
            this.EditCustomerCbx.Text = "Edit";
            this.EditCustomerCbx.UseVisualStyleBackColor = true;
            this.EditCustomerCbx.CheckedChanged += new System.EventHandler(this.EditCustomerCbx_CheckedChanged);
            // 
            // SaveEditCustomerBtn
            // 
            this.SaveEditCustomerBtn.Location = new System.Drawing.Point(91, 303);
            this.SaveEditCustomerBtn.Name = "SaveEditCustomerBtn";
            this.SaveEditCustomerBtn.Size = new System.Drawing.Size(107, 23);
            this.SaveEditCustomerBtn.TabIndex = 8;
            this.SaveEditCustomerBtn.Text = "Save changes";
            this.SaveEditCustomerBtn.UseVisualStyleBackColor = true;
            this.SaveEditCustomerBtn.Click += new System.EventHandler(this.SaveEditCustomerBtn_Click);
            // 
            // CustomerDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.SaveEditCustomerBtn);
            this.Controls.Add(this.EditCustomerCbx);
            this.Controls.Add(this.CountryCustomerLbl);
            this.Controls.Add(this.NameCustomerLbl);
            this.Controls.Add(this.IdCustomerLbl);
            this.Controls.Add(this.CountryCustomerTxt);
            this.Controls.Add(this.IdCustomerTxt);
            this.Controls.Add(this.NameCustomerTxt);
            this.Name = "CustomerDetailsForm";
            this.Text = "CustomerDetailsForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox NameCustomerTxt;
        private TextBox IdCustomerTxt;
        private TextBox CountryCustomerTxt;
        private Label IdCustomerLbl;
        private Label NameCustomerLbl;
        private Label CountryCustomerLbl;
        private CheckBox EditCustomerCbx;
        private Button SaveEditCustomerBtn;
    }
}