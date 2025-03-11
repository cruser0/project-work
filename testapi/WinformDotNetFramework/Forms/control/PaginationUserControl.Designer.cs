using System.Windows.Forms;

namespace WinformDotNetFramework.Forms.control
{
    partial class PaginationUserControl
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
            this.PageNumber = new System.Windows.Forms.Label();
            this.DoubleRightArrow = new System.Windows.Forms.Button();
            this.SingleRightArrow = new System.Windows.Forms.Button();
            this.SingleLeftArrow = new System.Windows.Forms.Button();
            this.DoubleLeftArrow = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.panel1.Controls.Add(this.PageNumber);
            this.panel1.Controls.Add(this.DoubleRightArrow);
            this.panel1.Controls.Add(this.SingleRightArrow);
            this.panel1.Controls.Add(this.SingleLeftArrow);
            this.panel1.Controls.Add(this.DoubleLeftArrow);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(316, 50);
            this.panel1.TabIndex = 0;
            // 
            // PageNumber
            // 
            this.PageNumber.AutoSize = true;
            this.PageNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.PageNumber.Location = new System.Drawing.Point(132, 16);
            this.PageNumber.Name = "PageNumber";
            this.PageNumber.Size = new System.Drawing.Size(38, 15);
            this.PageNumber.TabIndex = 4;
            this.PageNumber.Text = "label1";
            // 
            // DoubleRightArrow
            // 
            this.DoubleRightArrow.FlatAppearance.BorderSize = 0;
            this.DoubleRightArrow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DoubleRightArrow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.DoubleRightArrow.Image = global::WinformDotNetFramework.Properties.Resources.double_right_resize;
            this.DoubleRightArrow.Location = new System.Drawing.Point(273, 3);
            this.DoubleRightArrow.Name = "DoubleRightArrow";
            this.DoubleRightArrow.Size = new System.Drawing.Size(40, 40);
            this.DoubleRightArrow.TabIndex = 3;
            this.DoubleRightArrow.UseVisualStyleBackColor = true;
            this.DoubleRightArrow.Click += new System.EventHandler(this.DoubleRightArrow_Click);
            // 
            // SingleRightArrow
            // 
            this.SingleRightArrow.FlatAppearance.BorderSize = 0;
            this.SingleRightArrow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SingleRightArrow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.SingleRightArrow.Image = global::WinformDotNetFramework.Properties.Resources.single_right_resize;
            this.SingleRightArrow.Location = new System.Drawing.Point(227, 3);
            this.SingleRightArrow.Name = "SingleRightArrow";
            this.SingleRightArrow.Size = new System.Drawing.Size(40, 40);
            this.SingleRightArrow.TabIndex = 2;
            this.SingleRightArrow.UseVisualStyleBackColor = true;
            this.SingleRightArrow.Click += new System.EventHandler(this.SingleRightArrow_Click);
            // 
            // SingleLeftArrow
            // 
            this.SingleLeftArrow.FlatAppearance.BorderSize = 0;
            this.SingleLeftArrow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SingleLeftArrow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.SingleLeftArrow.Image = global::WinformDotNetFramework.Properties.Resources.single_left_resize;
            this.SingleLeftArrow.Location = new System.Drawing.Point(49, 3);
            this.SingleLeftArrow.Name = "SingleLeftArrow";
            this.SingleLeftArrow.Size = new System.Drawing.Size(40, 40);
            this.SingleLeftArrow.TabIndex = 1;
            this.SingleLeftArrow.UseVisualStyleBackColor = true;
            this.SingleLeftArrow.Click += new System.EventHandler(this.SingleLeftArrow_Click);
            // 
            // DoubleLeftArrow
            // 
            this.DoubleLeftArrow.FlatAppearance.BorderSize = 0;
            this.DoubleLeftArrow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DoubleLeftArrow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.DoubleLeftArrow.Image = global::WinformDotNetFramework.Properties.Resources.double_left_resize;
            this.DoubleLeftArrow.Location = new System.Drawing.Point(3, 3);
            this.DoubleLeftArrow.Name = "DoubleLeftArrow";
            this.DoubleLeftArrow.Size = new System.Drawing.Size(40, 40);
            this.DoubleLeftArrow.TabIndex = 0;
            this.DoubleLeftArrow.UseVisualStyleBackColor = true;
            this.DoubleLeftArrow.Click += new System.EventHandler(this.DoubleLeftArrow_Click);
            // 
            // PaginationUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "PaginationUserControl";
            this.Size = new System.Drawing.Size(316, 50);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Label PageNumber;
        private Button DoubleRightArrow;
        private Button SingleRightArrow;
        private Button SingleLeftArrow;
        private Button DoubleLeftArrow;
    }
}
