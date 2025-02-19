namespace Winform.Forms.control
{
    partial class IntegerTextBoxUserControl
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
            this.NumericTxt = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // NumericTxt
            // 
            this.NumericTxt.BackColor = System.Drawing.Color.Gainsboro;
            this.NumericTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NumericTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NumericTxt.Location = new System.Drawing.Point(0, 0);
            this.NumericTxt.Name = "NumericTxt";
            this.NumericTxt.Size = new System.Drawing.Size(194, 23);
            this.NumericTxt.TabIndex = 2;
            this.NumericTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumericTxt_OnKeyPress);
            // 
            // IntegerTextBoxUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.NumericTxt);
            this.Name = "IntegerTextBoxUserControl";
            this.Size = new System.Drawing.Size(194, 23);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox NumericTxt;
    }
}
