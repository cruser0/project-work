using Entity_Validator;
using Entity_Validator.Entity.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WinformDotNetFramework
{
    public partial class Form1 : Form
    {
        public HashSet<RedTextBox> Wrongtextboxes = new HashSet<RedTextBox>();
        public Form1()
        {
            InitializeComponent();
            CustomerInvoiceId.Tag = CustomerInvoiceIdLbl;
            Cost.Tag = CostLbl;
            Quantity.Tag = QuantityLbl;
            name.Tag = NameLbl;
            CostRegistryCode.Tag = CostRegistryCodeLbl;
            CustomerInvoiceCode.Tag = CustomerInvoiceCodeLbl;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ResetLbl();

            var invoiceCost = new CustomerInvoiceCostDTO
            {
                CustomerInvoiceId = 1, // Un esempio di ID della fattura
                Cost = -100.50m, // Valore negativo per il costo
                Quantity = 10, // Esempio di quantità
                IsPost = true // Indica che si tratta di un'inserimento (Post)
            };

            ValidateTextBoxes(invoiceCost);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ResetLbl();

            var invoiceCost = new CustomerInvoiceCostDTO
            {
                CustomerInvoiceId = 1, // Un esempio di ID della fattura
                Cost = 100.50m, // Valore negativo per il costo
                CostRegistryCode = "COST123", // Codice di registrazione del costo
                IsPost = false // Indica che si tratta di un'inserimento (Post)
            };

            ValidateTextBoxes(invoiceCost);
        }


        private void ValidateTextBoxes(CustomerInvoiceCostDTO invoiceCost)
        {
            Wrongtextboxes.Clear();

            CustomerInvoiceId.Text = invoiceCost.CustomerInvoiceId?.ToString() ?? string.Empty;
            Cost.Text = invoiceCost.Cost?.ToString() ?? string.Empty;
            Quantity.Text = invoiceCost.Quantity?.ToString() ?? string.Empty;
            name.Text = invoiceCost.Name ?? string.Empty;
            CostRegistryCode.Text = invoiceCost.CostRegistryCode ?? string.Empty;
            CustomerInvoiceCode.Text = invoiceCost.CustomerInvoiceCode ?? string.Empty;

            List<ValidationResult> validationResults = ValidatorEntity.Validate(invoiceCost);

            string results = "";
            foreach (var item in validationResults)
            {
                results += item.ToString() + "\n";

                string n = item.MemberNames.First().Trim('"');

                RedTextBox rtb = (RedTextBox)Controls.Find(n, true).First();
                Label lbl = (Label)rtb.Tag;

                lbl.ForeColor = System.Drawing.Color.Red;

                Wrongtextboxes.Add(rtb);
            }

            if (validationResults.Count == 0)
                results = "validato";

            this.Refresh();
            MessageBox.Show(results);
        }

        private void ResetLbl()
        {
            foreach (var label in Controls.OfType<Label>())
            {
                label.ForeColor = SystemColors.ControlText;
            }
        }
    }
}
