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
            this.PropLbl = new System.Windows.Forms.Label();
            this.Errorlbl = new System.Windows.Forms.Label();
            this.PropTxt = new WinformDotNetFramework.Forms.CustomComboBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.PropTxt);
            this.panel1.Controls.Add(this.PropLbl);
            this.panel1.Controls.Add(this.Errorlbl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 47);
            this.panel1.TabIndex = 1;
            // 
            // PropLbl
            // 
            this.PropLbl.Dock = System.Windows.Forms.DockStyle.Top;
            this.PropLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PropLbl.Location = new System.Drawing.Point(0, 0);
            this.PropLbl.Name = "PropLbl";
            this.PropLbl.Size = new System.Drawing.Size(200, 13);
            this.PropLbl.TabIndex = 2;
            this.PropLbl.Text = "PropLbl";
            // 
            // Errorlbl
            // 
            this.Errorlbl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Errorlbl.Font = new System.Drawing.Font("Segoe UI", 6.5F);
            this.Errorlbl.Location = new System.Drawing.Point(0, 35);
            this.Errorlbl.Name = "Errorlbl";
            this.Errorlbl.Size = new System.Drawing.Size(200, 12);
            this.Errorlbl.TabIndex = 1;
            this.Errorlbl.Text = "ErrorLbl";
            this.Errorlbl.Visible = false;
            // 
            // PropTxt
            // 
            this.PropTxt.BorderColor = System.Drawing.Color.Black;
            this.PropTxt.FormattingEnabled = true;
            this.PropTxt.Location = new System.Drawing.Point(0, 15);
            this.PropTxt.Name = "PropTxt";
            this.PropTxt.Size = new System.Drawing.Size(200, 21);
            this.PropTxt.TabIndex = 3;
            // 
            // CustomComboboxUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "CustomComboboxUserControl";
            this.Size = new System.Drawing.Size(200, 47);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel panel1;
        private CustomComboBox PropTxt;
        public System.Windows.Forms.Label PropLbl;
        public System.Windows.Forms.Label Errorlbl;
    }
}
