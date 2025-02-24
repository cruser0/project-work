namespace Winform.Forms.control
{
    partial class formDockButton
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
            this.buttonShowForm = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonCloseForm = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonShowForm
            // 
            this.buttonShowForm.Location = new System.Drawing.Point(5, 5);
            this.buttonShowForm.Name = "buttonShowForm";
            this.buttonShowForm.Size = new System.Drawing.Size(160, 25);
            this.buttonShowForm.TabIndex = 0;
            this.buttonShowForm.Text = "button1";
            this.buttonShowForm.UseVisualStyleBackColor = true;
            this.buttonShowForm.Click += new System.EventHandler(this.buttonShowForm_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonCloseForm);
            this.panel1.Controls.Add(this.buttonShowForm);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 35);
            this.panel1.TabIndex = 1;
            // 
            // buttonCloseForm
            // 
            this.buttonCloseForm.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonCloseForm.Location = new System.Drawing.Point(170, 5);
            this.buttonCloseForm.Name = "buttonCloseForm";
            this.buttonCloseForm.Size = new System.Drawing.Size(25, 25);
            this.buttonCloseForm.TabIndex = 1;
            this.buttonCloseForm.Text = "X";
            this.buttonCloseForm.UseVisualStyleBackColor = true;
            this.buttonCloseForm.Click += new System.EventHandler(this.buttonCloseForm_Click);
            // 
            // formDockButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "formDockButton";
            this.Size = new System.Drawing.Size(200, 35);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Panel panel1;
        private Button buttonCloseForm;
        private Button buttonShowForm;
    }
}
