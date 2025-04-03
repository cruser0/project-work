namespace WinformDotNetFramework.Forms
{
    partial class Form1
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
            this.paginationUserControl1 = new WinformDotNetFramework.Forms.control.PaginationUserControl();
            this.SuspendLayout();
            // 
            // paginationUserControl1
            // 
            this.paginationUserControl1.CurrentPage = 0;
            this.paginationUserControl1.Location = new System.Drawing.Point(237, 148);
            this.paginationUserControl1.Name = "paginationUserControl1";
            this.paginationUserControl1.Size = new System.Drawing.Size(271, 43);
            this.paginationUserControl1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.paginationUserControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private control.PaginationUserControl paginationUserControl1;
    }
}