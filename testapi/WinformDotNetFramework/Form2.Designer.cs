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
            this.button1 = new System.Windows.Forms.Button();
            this.customTextBoxUserControl1 = new WinformDotNetFramework.Forms.control.CustomTextBoxUserControl();
            this.customTextBoxUserControl2 = new WinformDotNetFramework.Forms.control.CustomTextBoxUserControl();
            this.customTextBoxUserControl3 = new WinformDotNetFramework.Forms.control.CustomTextBoxUserControl();
            this.customTextBoxUserControl4 = new WinformDotNetFramework.Forms.control.CustomTextBoxUserControl();
            this.customTextBoxUserControl5 = new WinformDotNetFramework.Forms.control.CustomTextBoxUserControl();
            this.SuspendLayout();
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
            // customTextBoxUserControl1
            // 
            this.customTextBoxUserControl1.Location = new System.Drawing.Point(221, 47);
            this.customTextBoxUserControl1.Name = "customTextBoxUserControl1";
            this.customTextBoxUserControl1.Size = new System.Drawing.Size(200, 46);
            this.customTextBoxUserControl1.TabIndex = 40;
            // 
            // customTextBoxUserControl2
            // 
            this.customTextBoxUserControl2.Location = new System.Drawing.Point(221, 99);
            this.customTextBoxUserControl2.Name = "customTextBoxUserControl2";
            this.customTextBoxUserControl2.Size = new System.Drawing.Size(200, 46);
            this.customTextBoxUserControl2.TabIndex = 41;
            // 
            // customTextBoxUserControl3
            // 
            this.customTextBoxUserControl3.Location = new System.Drawing.Point(221, 151);
            this.customTextBoxUserControl3.Name = "customTextBoxUserControl3";
            this.customTextBoxUserControl3.Size = new System.Drawing.Size(200, 46);
            this.customTextBoxUserControl3.TabIndex = 42;
            // 
            // customTextBoxUserControl4
            // 
            this.customTextBoxUserControl4.Location = new System.Drawing.Point(221, 203);
            this.customTextBoxUserControl4.Name = "customTextBoxUserControl4";
            this.customTextBoxUserControl4.Size = new System.Drawing.Size(200, 46);
            this.customTextBoxUserControl4.TabIndex = 43;
            // 
            // customTextBoxUserControl5
            // 
            this.customTextBoxUserControl5.Location = new System.Drawing.Point(221, 255);
            this.customTextBoxUserControl5.Name = "customTextBoxUserControl5";
            this.customTextBoxUserControl5.Size = new System.Drawing.Size(200, 46);
            this.customTextBoxUserControl5.TabIndex = 44;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.customTextBoxUserControl5);
            this.Controls.Add(this.customTextBoxUserControl4);
            this.Controls.Add(this.customTextBoxUserControl3);
            this.Controls.Add(this.customTextBoxUserControl2);
            this.Controls.Add(this.customTextBoxUserControl1);
            this.Controls.Add(this.button1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private Forms.control.CustomTextBoxUserControl customTextBoxUserControl1;
        private Forms.control.CustomTextBoxUserControl customTextBoxUserControl2;
        private Forms.control.CustomTextBoxUserControl customTextBoxUserControl3;
        private Forms.control.CustomTextBoxUserControl customTextBoxUserControl4;
        private Forms.control.CustomTextBoxUserControl customTextBoxUserControl5;
    }
}