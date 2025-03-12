namespace WinformDotNetFramework.Forms
{
    partial class GraphTestForm
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
            this.components = new System.ComponentModel.Container();
            this.progetto_FormativoDataSet = new WinformDotNetFramework.Progetto_FormativoDataSet();
            this.pfClassifySalesByProfitBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pf_ClassifySalesByProfitTableAdapter = new WinformDotNetFramework.Progetto_FormativoDataSetTableAdapters.pf_ClassifySalesByProfitTableAdapter();
            this.progettoFormativoDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.progetto_FormativoDataSet1 = new WinformDotNetFramework.Progetto_FormativoDataSet1();
            this.salesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.salesTableAdapter = new WinformDotNetFramework.Progetto_FormativoDataSet1TableAdapters.SalesTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.progetto_FormativoDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pfClassifySalesByProfitBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.progettoFormativoDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.progetto_FormativoDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.salesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // progetto_FormativoDataSet
            // 
            this.progetto_FormativoDataSet.DataSetName = "Progetto_FormativoDataSet";
            this.progetto_FormativoDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pfClassifySalesByProfitBindingSource
            // 
            this.pfClassifySalesByProfitBindingSource.DataMember = "pf_ClassifySalesByProfit";
            this.pfClassifySalesByProfitBindingSource.DataSource = this.progetto_FormativoDataSet;
            // 
            // pf_ClassifySalesByProfitTableAdapter
            // 
            this.pf_ClassifySalesByProfitTableAdapter.ClearBeforeFill = true;
            // 
            // progettoFormativoDataSetBindingSource
            // 
            this.progettoFormativoDataSetBindingSource.DataSource = this.progetto_FormativoDataSet;
            this.progettoFormativoDataSetBindingSource.Position = 0;
            // 
            // progetto_FormativoDataSet1
            // 
            this.progetto_FormativoDataSet1.DataSetName = "Progetto_FormativoDataSet1";
            this.progetto_FormativoDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // salesBindingSource
            // 
            this.salesBindingSource.DataMember = "Sales";
            this.salesBindingSource.DataSource = this.progetto_FormativoDataSet1;
            // 
            // salesTableAdapter
            // 
            this.salesTableAdapter.ClearBeforeFill = true;
            // 
            // GraphTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "GraphTestForm";
            this.Text = "GraphTestForm";
            this.Load += new System.EventHandler(this.GraphTestForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.progetto_FormativoDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pfClassifySalesByProfitBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.progettoFormativoDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.progetto_FormativoDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.salesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource pfClassifySalesByProfitBindingSource;
        private Progetto_FormativoDataSet progetto_FormativoDataSet;
        private Progetto_FormativoDataSetTableAdapters.pf_ClassifySalesByProfitTableAdapter pf_ClassifySalesByProfitTableAdapter;
        private System.Windows.Forms.BindingSource progettoFormativoDataSetBindingSource;
        private Progetto_FormativoDataSet1 progetto_FormativoDataSet1;
        private System.Windows.Forms.BindingSource salesBindingSource;
        private Progetto_FormativoDataSet1TableAdapters.SalesTableAdapter salesTableAdapter;
    }
}