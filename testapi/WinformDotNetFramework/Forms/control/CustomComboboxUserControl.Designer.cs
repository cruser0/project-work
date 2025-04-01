namespace WinformDotNetFramework.Forms.control
{
    partial class CustomComboboxUserControl
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.Errorlbl = new System.Windows.Forms.Label();
            this.PropLbl = new System.Windows.Forms.Label();
            this.customComboBox1 = new WinformDotNetFramework.Forms.CustomComboBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.customComboBox1);
            this.panel1.Controls.Add(this.Errorlbl);
            this.panel1.Controls.Add(this.PropLbl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 71);
            this.panel1.TabIndex = 1;
            // 
            // Errorlbl
            // 
            this.Errorlbl.AutoSize = true;
            this.Errorlbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Errorlbl.Location = new System.Drawing.Point(0, 13);
            this.Errorlbl.Name = "Errorlbl";
            this.Errorlbl.Size = new System.Drawing.Size(43, 13);
            this.Errorlbl.TabIndex = 1;
            this.Errorlbl.Text = "ErrorLbl";
            this.Errorlbl.Visible = false;
            // 
            // PropLbl
            // 
            this.PropLbl.Dock = System.Windows.Forms.DockStyle.Top;
            this.PropLbl.Location = new System.Drawing.Point(0, 0);
            this.PropLbl.Name = "PropLbl";
            this.PropLbl.Size = new System.Drawing.Size(200, 13);
            this.PropLbl.TabIndex = 2;
            this.PropLbl.Text = "PropLbl";
            // 
            // customComboBox1
            // 
            this.customComboBox1.BorderColor = System.Drawing.Color.Black;
            this.customComboBox1.FormattingEnabled = true;
            this.customComboBox1.Location = new System.Drawing.Point(0, 50);
            this.customComboBox1.Name = "customComboBox1";
            this.customComboBox1.Size = new System.Drawing.Size(200, 21);
            this.customComboBox1.TabIndex = 3;
            // 
            // CustomComboboxUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "CustomComboboxUserControl";
            this.Size = new System.Drawing.Size(200, 71);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private CustomComboBox customComboBox1;
        private System.Windows.Forms.Label Errorlbl;
        private System.Windows.Forms.Label PropLbl;
    }
}
