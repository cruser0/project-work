namespace Winform.Forms
{
    partial class CreateCustomerForm
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
            this.CreateCustomerUserControl = new Winform.Forms.control.CreateCustomerSupplierUserControl();
            this.SuspendLayout();
            // 
            // CreateCustomerUserControl
            // 
            this.CreateCustomerUserControl.Location = new System.Drawing.Point(51, 0);
            this.CreateCustomerUserControl.Name = "CreateCustomerUserControl";
            this.CreateCustomerUserControl.Size = new System.Drawing.Size(676, 469);
            this.CreateCustomerUserControl.TabIndex = 0;
            // 
            // CreateCustomerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CreateCustomerUserControl);
            this.Name = "CreateCustomerForm";
            this.Text = "CreateCustomerForm";
            this.ResumeLayout(false);

        }

        #endregion

        private control.CreateCustomerSupplierUserControl CreateCustomerUserControl;
    }
}