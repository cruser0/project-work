namespace Winform.Forms.control
{
    partial class CreateCustomerSupplierUserControl
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
            this.CreateSaveBtn = new System.Windows.Forms.Button();
            this.CreateCountryLbl = new System.Windows.Forms.Label();
            this.CreateNameLbl = new System.Windows.Forms.Label();
            this.CreateCountryTxt = new System.Windows.Forms.TextBox();
            this.CreateNameTxt = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // CreateSaveBtn
            // 
            this.CreateSaveBtn.Location = new System.Drawing.Point(263, 310);
            this.CreateSaveBtn.Name = "CreateSaveBtn";
            this.CreateSaveBtn.Size = new System.Drawing.Size(107, 23);
            this.CreateSaveBtn.TabIndex = 22;
            this.CreateSaveBtn.Text = "Save changes";
            this.CreateSaveBtn.UseVisualStyleBackColor = true;
            this.CreateSaveBtn.Click += new System.EventHandler(this.CreateSaveBtn_Click);
            // 
            // CreateCountryLbl
            // 
            this.CreateCountryLbl.AutoSize = true;
            this.CreateCountryLbl.Location = new System.Drawing.Point(265, 190);
            this.CreateCountryLbl.Name = "CreateCountryLbl";
            this.CreateCountryLbl.Size = new System.Drawing.Size(58, 15);
            this.CreateCountryLbl.TabIndex = 20;
            this.CreateCountryLbl.Text = "Country *";
            // 
            // CreateNameLbl
            // 
            this.CreateNameLbl.AutoSize = true;
            this.CreateNameLbl.Location = new System.Drawing.Point(265, 125);
            this.CreateNameLbl.Name = "CreateNameLbl";
            this.CreateNameLbl.Size = new System.Drawing.Size(47, 15);
            this.CreateNameLbl.TabIndex = 19;
            this.CreateNameLbl.Text = "Name *";
            // 
            // CreateCountryTxt
            // 
            this.CreateCountryTxt.Location = new System.Drawing.Point(263, 208);
            this.CreateCountryTxt.MaxLength = 50;
            this.CreateCountryTxt.Name = "CreateCountryTxt";
            this.CreateCountryTxt.Size = new System.Drawing.Size(100, 23);
            this.CreateCountryTxt.TabIndex = 18;
            // 
            // CreateNameTxt
            // 
            this.CreateNameTxt.Location = new System.Drawing.Point(263, 141);
            this.CreateNameTxt.MaxLength = 100;
            this.CreateNameTxt.Name = "CreateNameTxt";
            this.CreateNameTxt.Size = new System.Drawing.Size(100, 23);
            this.CreateNameTxt.TabIndex = 17;
            // 
            // CreateCustomerSupplierUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CreateSaveBtn);
            this.Controls.Add(this.CreateCountryLbl);
            this.Controls.Add(this.CreateNameLbl);
            this.Controls.Add(this.CreateCountryTxt);
            this.Controls.Add(this.CreateNameTxt);
            this.Name = "CreateCustomerSupplierUserControl";
            this.Size = new System.Drawing.Size(676, 469);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button CreateSaveBtn;
        private Label CreateCountryLbl;
        private Label CreateNameLbl;
        private TextBox CreateCountryTxt;
        private TextBox CreateNameTxt;
    }
}
