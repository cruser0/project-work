﻿using System.Windows.Forms;

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
            this.buttonCloseForm = new System.Windows.Forms.Button();
            this.AddFavoriteButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonShowForm
            // 
            this.buttonShowForm.AutoSize = true;
            this.buttonShowForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.buttonShowForm.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonShowForm.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(124)))), ((int)(((byte)(166)))));
            this.buttonShowForm.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonShowForm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.buttonShowForm.Location = new System.Drawing.Point(1, 1);
            this.buttonShowForm.Name = "buttonShowForm";
            this.buttonShowForm.Size = new System.Drawing.Size(120, 28);
            this.buttonShowForm.TabIndex = 0;
            this.buttonShowForm.Text = "button1";
            this.buttonShowForm.UseVisualStyleBackColor = false;
            this.buttonShowForm.Click += new System.EventHandler(this.buttonShowForm_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(180)))), ((int)(((byte)(194)))));
            this.panel1.Controls.Add(this.buttonCloseForm);
            this.panel1.Controls.Add(this.AddFavoriteButton);
            this.panel1.Controls.Add(this.buttonShowForm);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(1);
            this.panel1.Size = new System.Drawing.Size(181, 30);
            this.panel1.TabIndex = 1;
            // 
            // buttonCloseForm
            // 
            this.buttonCloseForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.buttonCloseForm.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonCloseForm.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(124)))), ((int)(((byte)(166)))));
            this.buttonCloseForm.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.buttonCloseForm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.buttonCloseForm.Location = new System.Drawing.Point(150, 1);
            this.buttonCloseForm.Name = "buttonCloseForm";
            this.buttonCloseForm.Size = new System.Drawing.Size(28, 28);
            this.buttonCloseForm.TabIndex = 1;
            this.buttonCloseForm.Text = "X";
            this.buttonCloseForm.UseVisualStyleBackColor = false;
            this.buttonCloseForm.Click += new System.EventHandler(this.buttonCloseForm_Click);
            // 
            // AddFavoriteButton
            // 
            this.AddFavoriteButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.AddFavoriteButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.AddFavoriteButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(124)))), ((int)(((byte)(166)))));
            this.AddFavoriteButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.AddFavoriteButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.AddFavoriteButton.Image = global::WinformDotNetFramework.Properties.Resources.star_yellow25x25;
            this.AddFavoriteButton.Location = new System.Drawing.Point(121, 1);
            this.AddFavoriteButton.Name = "AddFavoriteButton";
            this.AddFavoriteButton.Padding = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.AddFavoriteButton.Size = new System.Drawing.Size(29, 28);
            this.AddFavoriteButton.TabIndex = 2;
            this.AddFavoriteButton.UseVisualStyleBackColor = false;
            this.AddFavoriteButton.Click += new System.EventHandler(this.AddFavoriteButton_Click);
            // 
            // formDockButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "formDockButton";
            this.Size = new System.Drawing.Size(181, 30);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Button buttonShowForm;
        private Button AddFavoriteButton;
        public Panel panel1;
        public Button buttonCloseForm;
    }
}
