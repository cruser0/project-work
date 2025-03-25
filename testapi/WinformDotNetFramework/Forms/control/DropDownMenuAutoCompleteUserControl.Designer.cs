namespace WinformDotNetFramework.Forms.control
{
    partial class DropDownMenuAutoCompleteUserControl
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
            this.components = new System.ComponentModel.Container();
            this.Cmbx = new System.Windows.Forms.ComboBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // Cmbx
            // 
            this.Cmbx.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.Cmbx.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.Cmbx.FormattingEnabled = true;
            this.Cmbx.Location = new System.Drawing.Point(0, 0);
            this.Cmbx.MaximumSize = new System.Drawing.Size(172, 0);
            this.Cmbx.Name = "Cmbx";
            this.Cmbx.Size = new System.Drawing.Size(172, 21);
            this.Cmbx.TabIndex = 38;
            this.Cmbx.SelectedIndexChanged += new System.EventHandler(this.Cmbx_SelectedIndexChanged);
            this.Cmbx.SelectionChangeCommitted += new System.EventHandler(this.Cmbx_SelectionChangeCommitted);
            this.Cmbx.TextChanged += new System.EventHandler(this.Cmbx_TextChanged);
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // DropDownMenuAutoCompleteUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Cmbx);
            this.Name = "DropDownMenuAutoCompleteUserControl";
            this.Size = new System.Drawing.Size(172, 21);
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.ComboBox Cmbx;
        public System.Windows.Forms.Timer timer;
    }
}
