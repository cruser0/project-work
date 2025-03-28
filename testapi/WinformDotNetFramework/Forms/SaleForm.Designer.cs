using System.Windows.Forms;

namespace WinformDotNetFramework.Forms
{
    partial class SaleForm
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
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.leftSideBarUSerControl1 = new WinformDotNetFramework.Forms.control.LeftSideBarUSerControl();
            this.RigtPanel.SuspendLayout();
            this.BottomPanel.SuspendLayout();
            this.panel5.SuspendLayout();
            this.TextBoxesRightPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.Location = new System.Drawing.Point(171, 0);
            this.MainPanel.Size = new System.Drawing.Size(413, 374);
            // 
            // RigtPanel
            // 
            this.RigtPanel.Size = new System.Drawing.Size(200, 374);
            // 
            // RightSideBar
            // 
            this.RightSideBar.Size = new System.Drawing.Size(200, 374);
            // 
            // BottomPanel
            // 
            this.BottomPanel.Size = new System.Drawing.Size(784, 87);
            // 
            // panel5
            // 
            this.panel5.Location = new System.Drawing.Point(243, 0);
            // 
            // PaginationUserControl
            // 
            this.PaginationUserControl.Location = new System.Drawing.Point(24, 24);
            // 
            // panel4
            // 
            this.panel4.Location = new System.Drawing.Point(784, 0);
            // 
            // TextBoxesRightPanel
            // 
            this.TextBoxesRightPanel.Size = new System.Drawing.Size(200, 369);
            // 
            // searchSale1
            // 
            this.searchSale1.Size = new System.Drawing.Size(200, 369);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "CustomerName";
            this.dataGridViewTextBoxColumn1.HeaderText = "CustomerName";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Country";
            this.dataGridViewTextBoxColumn2.HeaderText = "Country";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "SaleId";
            this.dataGridViewTextBoxColumn3.HeaderText = "SaleId";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "BookingNumber";
            this.dataGridViewTextBoxColumn4.HeaderText = "BookingNumber";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "BoLnumber";
            this.dataGridViewTextBoxColumn5.HeaderText = "BoLnumber";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "SaleDate";
            this.dataGridViewTextBoxColumn6.HeaderText = "SaleDate";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "CustomerId";
            this.dataGridViewTextBoxColumn7.HeaderText = "CustomerId";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "TotalRevenue";
            this.dataGridViewTextBoxColumn8.HeaderText = "TotalRevenue";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "Status";
            this.dataGridViewTextBoxColumn9.HeaderText = "Status";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            // 
            // leftSideBarUSerControl1
            // 
            this.leftSideBarUSerControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.leftSideBarUSerControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftSideBarUSerControl1.Location = new System.Drawing.Point(0, 0);
            this.leftSideBarUSerControl1.Name = "leftSideBarUSerControl1";
            this.leftSideBarUSerControl1.Size = new System.Drawing.Size(171, 374);
            this.leftSideBarUSerControl1.TabIndex = 20;
            // 
            // SaleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.leftSideBarUSerControl1);
            this.MinimumSize = new System.Drawing.Size(688, 439);
            this.Name = "SaleForm";
            this.Controls.SetChildIndex(this.BottomPanel, 0);
            this.Controls.SetChildIndex(this.leftSideBarUSerControl1, 0);
            this.Controls.SetChildIndex(this.RigtPanel, 0);
            this.Controls.SetChildIndex(this.MainPanel, 0);
            this.RigtPanel.ResumeLayout(false);
            this.BottomPanel.ResumeLayout(false);
            this.BottomPanel.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.TextBoxesRightPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Label SaleLbl;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private control.LeftSideBarUSerControl leftSideBarUSerControl1;
    }
}