namespace Winform.Forms
{
    partial class CustomerForm
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
            this.baseGridComponent = new Winform.Forms.control.BaseGridUserControl();
            this.NameTxt = new System.Windows.Forms.TextBox();
            this.CountryTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // baseGridComponent
            // 
            this.baseGridComponent.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.baseGridComponent.Location = new System.Drawing.Point(0, 94);
            this.baseGridComponent.Name = "baseGridComponent";
            this.baseGridComponent.Size = new System.Drawing.Size(1255, 529);
            this.baseGridComponent.TabIndex = 0;
            this.baseGridComponent.Load += new System.EventHandler(this.baseGridComponent_Load);
            // 
            // NameTxt
            // 
            this.NameTxt.Location = new System.Drawing.Point(25, 48);
            this.NameTxt.Name = "NameTxt";
            this.NameTxt.Size = new System.Drawing.Size(100, 23);
            this.NameTxt.TabIndex = 1;
            // 
            // CountryTxt
            // 
            this.CountryTxt.Location = new System.Drawing.Point(256, 48);
            this.CountryTxt.Name = "CountryTxt";
            this.CountryTxt.Size = new System.Drawing.Size(100, 23);
            this.CountryTxt.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(256, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Country";
            // 
            // CustomerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1255, 623);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CountryTxt);
            this.Controls.Add(this.NameTxt);
            this.Controls.Add(this.baseGridComponent);
            this.Name = "CustomerForm";
            this.Text = "testForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private control.BaseGridUserControl baseGridComponent;
        private TextBox NameTxt;
        private TextBox CountryTxt;
        private Label label1;
        private Label label2;
    }
}