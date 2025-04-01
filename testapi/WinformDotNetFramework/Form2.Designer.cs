namespace WinformDotNetFramework
{
    partial class Form2
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
            this.IsPostTxt = new WinformDotNetFramework.RedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CreatedAtLbl = new System.Windows.Forms.Label();
            this.DeprecatedLbl = new System.Windows.Forms.Label();
            this.CountryLbl = new System.Windows.Forms.Label();
            this.CustomerNameLbl = new System.Windows.Forms.Label();
            this.CreatedAtTxt = new WinformDotNetFramework.RedTextBox();
            this.DeprecatedTxt = new WinformDotNetFramework.RedTextBox();
            this.CountryTxt = new WinformDotNetFramework.RedTextBox();
            this.CustomerNameTxt = new WinformDotNetFramework.RedTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // IsPostTxt
            // 
            this.IsPostTxt.Location = new System.Drawing.Point(218, 276);
            this.IsPostTxt.Name = "IsPostTxt";
            this.IsPostTxt.Size = new System.Drawing.Size(199, 20);
            this.IsPostTxt.TabIndex = 32;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(218, 259);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "IsPost";
            // 
            // CreatedAtLbl
            // 
            this.CreatedAtLbl.AutoSize = true;
            this.CreatedAtLbl.Location = new System.Drawing.Point(219, 204);
            this.CreatedAtLbl.Name = "CreatedAtLbl";
            this.CreatedAtLbl.Size = new System.Drawing.Size(54, 13);
            this.CreatedAtLbl.TabIndex = 27;
            this.CreatedAtLbl.Text = "CreatedAt";
            // 
            // DeprecatedLbl
            // 
            this.DeprecatedLbl.AutoSize = true;
            this.DeprecatedLbl.Location = new System.Drawing.Point(219, 153);
            this.DeprecatedLbl.Name = "DeprecatedLbl";
            this.DeprecatedLbl.Size = new System.Drawing.Size(63, 13);
            this.DeprecatedLbl.TabIndex = 26;
            this.DeprecatedLbl.Text = "Deprecated";
            // 
            // CountryLbl
            // 
            this.CountryLbl.AutoSize = true;
            this.CountryLbl.Location = new System.Drawing.Point(219, 102);
            this.CountryLbl.Name = "CountryLbl";
            this.CountryLbl.Size = new System.Drawing.Size(43, 13);
            this.CountryLbl.TabIndex = 25;
            this.CountryLbl.Text = "Country";
            // 
            // CustomerNameLbl
            // 
            this.CustomerNameLbl.AutoSize = true;
            this.CustomerNameLbl.Location = new System.Drawing.Point(219, 51);
            this.CustomerNameLbl.Name = "CustomerNameLbl";
            this.CustomerNameLbl.Size = new System.Drawing.Size(79, 13);
            this.CustomerNameLbl.TabIndex = 24;
            this.CustomerNameLbl.Text = "CustomerName";
            // 
            // CreatedAtTxt
            // 
            this.CreatedAtTxt.Location = new System.Drawing.Point(219, 226);
            this.CreatedAtTxt.Name = "CreatedAtTxt";
            this.CreatedAtTxt.Size = new System.Drawing.Size(199, 20);
            this.CreatedAtTxt.TabIndex = 21;
            // 
            // DeprecatedTxt
            // 
            this.DeprecatedTxt.Location = new System.Drawing.Point(219, 175);
            this.DeprecatedTxt.Name = "DeprecatedTxt";
            this.DeprecatedTxt.Size = new System.Drawing.Size(199, 20);
            this.DeprecatedTxt.TabIndex = 20;
            // 
            // CountryTxt
            // 
            this.CountryTxt.Location = new System.Drawing.Point(219, 124);
            this.CountryTxt.Name = "CountryTxt";
            this.CountryTxt.Size = new System.Drawing.Size(199, 20);
            this.CountryTxt.TabIndex = 19;
            // 
            // CustomerNameTxt
            // 
            this.CustomerNameTxt.Location = new System.Drawing.Point(219, 73);
            this.CustomerNameTxt.Name = "CustomerNameTxt";
            this.CustomerNameTxt.Size = new System.Drawing.Size(199, 20);
            this.CustomerNameTxt.TabIndex = 18;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(64, 70);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 17;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.IsPostTxt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CreatedAtLbl);
            this.Controls.Add(this.DeprecatedLbl);
            this.Controls.Add(this.CountryLbl);
            this.Controls.Add(this.CustomerNameLbl);
            this.Controls.Add(this.CreatedAtTxt);
            this.Controls.Add(this.DeprecatedTxt);
            this.Controls.Add(this.CountryTxt);
            this.Controls.Add(this.CustomerNameTxt);
            this.Controls.Add(this.button1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RedTextBox IsPostTxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label CreatedAtLbl;
        private System.Windows.Forms.Label DeprecatedLbl;
        private System.Windows.Forms.Label CountryLbl;
        private System.Windows.Forms.Label CustomerNameLbl;
        private RedTextBox CreatedAtTxt;
        private RedTextBox DeprecatedTxt;
        private RedTextBox CountryTxt;
        private RedTextBox CustomerNameTxt;
        private System.Windows.Forms.Button button1;
    }
}