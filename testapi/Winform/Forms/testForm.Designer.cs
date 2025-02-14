namespace Winform.Forms
{
    partial class testForm
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
            this.SuspendLayout();
            // 
            // baseGridComponent
            // 
            this.baseGridComponent.Location = new System.Drawing.Point(12, 85);
            this.baseGridComponent.Name = "baseGridComponent";
            this.baseGridComponent.Size = new System.Drawing.Size(1239, 533);
            this.baseGridComponent.TabIndex = 0;
            // 
            // testForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1255, 623);
            this.Controls.Add(this.baseGridComponent);
            this.Name = "testForm";
            this.Text = "testForm";
            this.ResumeLayout(false);

        }

        #endregion

        private control.BaseGridUserControl baseGridComponent;
    }
}