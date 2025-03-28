namespace WinformDotNetFramework.Forms.control
{
    partial class SearchCostRegistry
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
            this.TextBoxesRightPanel = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CountryLvl = new System.Windows.Forms.Label();
            this.CodeCmbx = new System.Windows.Forms.ComboBox();
            this.NameCmbx = new System.Windows.Forms.ComboBox();
            this.TextBoxesRightPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // TextBoxesRightPanel
            // 
            this.TextBoxesRightPanel.AutoScroll = true;
            this.TextBoxesRightPanel.AutoScrollMargin = new System.Drawing.Size(0, 20);
            this.TextBoxesRightPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.TextBoxesRightPanel.Controls.Add(this.NameCmbx);
            this.TextBoxesRightPanel.Controls.Add(this.CodeCmbx);
            this.TextBoxesRightPanel.Controls.Add(this.label4);
            this.TextBoxesRightPanel.Controls.Add(this.label1);
            this.TextBoxesRightPanel.Controls.Add(this.CountryLvl);
            this.TextBoxesRightPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBoxesRightPanel.Location = new System.Drawing.Point(0, 0);
            this.TextBoxesRightPanel.Name = "TextBoxesRightPanel";
            this.TextBoxesRightPanel.Size = new System.Drawing.Size(210, 125);
            this.TextBoxesRightPanel.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.label4.Location = new System.Drawing.Point(3, 1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 17);
            this.label4.TabIndex = 20;
            this.label4.Text = "Cost Registry";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.label1.Location = new System.Drawing.Point(3, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Cost Registry Name";
            // 
            // CountryLvl
            // 
            this.CountryLvl.AutoSize = true;
            this.CountryLvl.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.CountryLvl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.CountryLvl.Location = new System.Drawing.Point(3, 64);
            this.CountryLvl.Name = "CountryLvl";
            this.CountryLvl.Size = new System.Drawing.Size(121, 17);
            this.CountryLvl.TabIndex = 4;
            this.CountryLvl.Text = "Cost RegistryCode";
            // 
            // CodeCmbx
            // 
            this.CodeCmbx.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.CodeCmbx.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CodeCmbx.FormattingEnabled = true;
            this.CodeCmbx.Location = new System.Drawing.Point(3, 84);
            this.CodeCmbx.Name = "CodeCmbx";
            this.CodeCmbx.Size = new System.Drawing.Size(180, 21);
            this.CodeCmbx.TabIndex = 24;
            // 
            // NameCmbx
            // 
            this.NameCmbx.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.NameCmbx.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.NameCmbx.FormattingEnabled = true;
            this.NameCmbx.Location = new System.Drawing.Point(3, 40);
            this.NameCmbx.Name = "NameCmbx";
            this.NameCmbx.Size = new System.Drawing.Size(180, 21);
            this.NameCmbx.TabIndex = 25;
            // 
            // SearchCostRegistry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TextBoxesRightPanel);
            this.Name = "SearchCostRegistry";
            this.Size = new System.Drawing.Size(210, 125);
            this.TextBoxesRightPanel.ResumeLayout(false);
            this.TextBoxesRightPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel TextBoxesRightPanel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label CountryLvl;
        private System.Windows.Forms.ComboBox CodeCmbx;
        private System.Windows.Forms.ComboBox NameCmbx;
    }
}
