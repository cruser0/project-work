namespace Winform.Forms
{
    partial class SupplierForm
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
            this.baseGridUserControl1 = new Winform.Forms.control.BaseGridUserControl();
            this.CountrySupplierLbl = new System.Windows.Forms.Label();
            this.NameSupplierLbl = new System.Windows.Forms.Label();
            this.CountrySupplierTxt = new System.Windows.Forms.TextBox();
            this.NameSupplierTxt = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // baseGridUserControl1
            // 
            this.baseGridUserControl1.Location = new System.Drawing.Point(3, -7);
            this.baseGridUserControl1.Name = "baseGridUserControl1";
            this.baseGridUserControl1.Size = new System.Drawing.Size(1239, 533);
            this.baseGridUserControl1.TabIndex = 0;
            // 
            // CountrySupplierLbl
            // 
            this.CountrySupplierLbl.AutoSize = true;
            this.CountrySupplierLbl.Location = new System.Drawing.Point(235, 14);
            this.CountrySupplierLbl.Name = "CountrySupplierLbl";
            this.CountrySupplierLbl.Size = new System.Drawing.Size(50, 15);
            this.CountrySupplierLbl.TabIndex = 9;
            this.CountrySupplierLbl.Text = "Country";
            // 
            // NameSupplierLbl
            // 
            this.NameSupplierLbl.AutoSize = true;
            this.NameSupplierLbl.Location = new System.Drawing.Point(24, 9);
            this.NameSupplierLbl.Name = "NameSupplierLbl";
            this.NameSupplierLbl.Size = new System.Drawing.Size(39, 15);
            this.NameSupplierLbl.TabIndex = 8;
            this.NameSupplierLbl.Text = "Name";
            // 
            // CountrySupplierTxt
            // 
            this.CountrySupplierTxt.Location = new System.Drawing.Point(235, 40);
            this.CountrySupplierTxt.Name = "CountrySupplierTxt";
            this.CountrySupplierTxt.Size = new System.Drawing.Size(100, 23);
            this.CountrySupplierTxt.TabIndex = 7;
            // 
            // NameSupplierTxt
            // 
            this.NameSupplierTxt.Location = new System.Drawing.Point(4, 40);
            this.NameSupplierTxt.Name = "NameSupplierTxt";
            this.NameSupplierTxt.Size = new System.Drawing.Size(100, 23);
            this.NameSupplierTxt.TabIndex = 6;
            // 
            // SupplierForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1362, 670);
            this.Controls.Add(this.CountrySupplierLbl);
            this.Controls.Add(this.NameSupplierLbl);
            this.Controls.Add(this.CountrySupplierTxt);
            this.Controls.Add(this.NameSupplierTxt);
            this.Controls.Add(this.baseGridUserControl1);
            this.Name = "SupplierForm";
            this.Text = "SupplierForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private control.BaseGridUserControl baseGridUserControl1;
        private Label CountrySupplierLbl;
        private Label NameSupplierLbl;
        private TextBox CountrySupplierTxt;
        private TextBox NameSupplierTxt;
    }
}