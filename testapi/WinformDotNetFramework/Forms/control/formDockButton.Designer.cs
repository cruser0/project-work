using System.Windows.Forms;

namespace WinformDotNetFramework.Forms.control
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
            this.AddFavoriteButton = new System.Windows.Forms.Button();
            this.buttonCloseForm = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonShowForm
            // 
            this.buttonShowForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.buttonShowForm.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(124)))), ((int)(((byte)(166)))));
            this.buttonShowForm.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonShowForm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.buttonShowForm.Location = new System.Drawing.Point(4, 4);
            this.buttonShowForm.Name = "buttonShowForm";
            this.buttonShowForm.Size = new System.Drawing.Size(120, 22);
            this.buttonShowForm.TabIndex = 0;
            this.buttonShowForm.Text = "button1";
            this.buttonShowForm.UseVisualStyleBackColor = false;
            this.buttonShowForm.Click += new System.EventHandler(this.buttonShowForm_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.AddFavoriteButton);
            this.panel1.Controls.Add(this.buttonCloseForm);
            this.panel1.Controls.Add(this.buttonShowForm);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(171, 30);
            this.panel1.TabIndex = 1;
            // 
            // AddFavoriteButton
            // 
            this.AddFavoriteButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.AddFavoriteButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(124)))), ((int)(((byte)(166)))));
            this.AddFavoriteButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.AddFavoriteButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.AddFavoriteButton.Image = global::WinformDotNetFramework.Properties.Resources.star_yellow25x25;
            this.AddFavoriteButton.Location = new System.Drawing.Point(124, 4);
            this.AddFavoriteButton.Name = "AddFavoriteButton";
            this.AddFavoriteButton.Padding = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.AddFavoriteButton.Size = new System.Drawing.Size(21, 22);
            this.AddFavoriteButton.TabIndex = 2;
            this.AddFavoriteButton.UseVisualStyleBackColor = false;
            this.AddFavoriteButton.Click += new System.EventHandler(this.AddFavoriteButton_Click);
            // 
            // buttonCloseForm
            // 
            this.buttonCloseForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.buttonCloseForm.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(124)))), ((int)(((byte)(166)))));
            this.buttonCloseForm.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.buttonCloseForm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.buttonCloseForm.Location = new System.Drawing.Point(146, 4);
            this.buttonCloseForm.Name = "buttonCloseForm";
            this.buttonCloseForm.Size = new System.Drawing.Size(21, 22);
            this.buttonCloseForm.TabIndex = 1;
            this.buttonCloseForm.Text = "X";
            this.buttonCloseForm.UseVisualStyleBackColor = false;
            this.buttonCloseForm.Click += new System.EventHandler(this.buttonCloseForm_Click);
            // 
            // formDockButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "formDockButton";
            this.Size = new System.Drawing.Size(171, 30);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Panel panel1;
        private Button buttonCloseForm;
        private Button buttonShowForm;
        private Button AddFavoriteButton;
    }
}
