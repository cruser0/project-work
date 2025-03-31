using Entity_Validator;
using Entity_Validator.Entity.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Windows.Forms;

namespace WinformDotNetFramework
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var invoiceCost = new CustomerInvoiceCostDTO
            {
                CustomerInvoiceId = 1, // Un esempio di ID della fattura
                Cost = -100.50m, // Valore negativo per il costo
                Quantity = -10, // Esempio di quantità
                Name = "Prodotto Esempio", // Nome del prodotto
                CostRegistryCode = "COST123", // Codice di registrazione del costo
                IsPost = true // Indica che si tratta di un'inserimento (Post)
            };

            List<ValidationResult> validationResults = ValidatorEntity.Validate(invoiceCost);

            string results = "";
            foreach (var item in validationResults)
            {
                results += item.ToString() + "\n";
            }
            if (validationResults.Count == 0)
                results = "validato";
            MessageBox.Show(results);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CustomerDTOGet c = new CustomerDTOGet() { IsPost = false, CustomerName = "aaa" };
            List<ValidationResult> validationResults = ValidatorEntity.Validate(c);

            string results = "";
            foreach (var item in validationResults)
            {
                results += item.ErrorMessage + "\n";
            }

            if (validationResults.Count == 0)
                results = "validato";

            MessageBox.Show(results);
        }
    }
}
