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

        // Lista di 10 CustomerInvoiceCostDTO con 9 che contengono errori
        List<CustomerInvoiceCostDTO> dtoList = new List<CustomerInvoiceCostDTO>
{
    // 1. DTO valido
    new CustomerInvoiceCostDTO
    {
        CustomerInvoiceId = 1,
        Cost = 100.50m,
        Quantity = 5,
        Name = "Valid Invoice Item",
        CostRegistryCode = "REG-12345",
        CustomerInvoiceCode = "INV-2025-001",
        IsPost = true
    },
    
    // 2. Errore: CustomerInvoiceId mancante (null)
    new CustomerInvoiceCostDTO
    {
        CustomerInvoiceId = null,
        Cost = 75.99m,
        Quantity = 3,
        Name = "Office Supplies",
        CostRegistryCode = "REG-1001",
        CustomerInvoiceCode = "INV-2025-002",
        IsPost = true
    },
    
    // 3. Errore: Cost negativo (viola il constraint Range)
    new CustomerInvoiceCostDTO
    {
        CustomerInvoiceId = 3,
        Cost = -50.00m,
        Quantity = 2,
        Name = "Software License",
        CostRegistryCode = "REG-2002",
        CustomerInvoiceCode = "INV-2025-003",
        IsPost = true
    },
    
    // 4. Errore: Quantity zero (viola il constraint Range)
    new CustomerInvoiceCostDTO
    {
        CustomerInvoiceId = 4,
        Cost = 199.99m,
        Quantity = 0,
        Name = "Hardware Maintenance",
        CostRegistryCode = "REG-3003",
        CustomerInvoiceCode = "INV-2025-004",
        IsPost = true
    },
    
    // 5. Errore: Name troppo lungo (eccede MaxLength)
    new CustomerInvoiceCostDTO
    {
        CustomerInvoiceId = 5,
        Cost = 349.50m,
        Quantity = 1,
        Name = "This name is intentionally very long to exceed the MaxLength attribute of 100 characters which is set on the Name property of the DTO class and will cause validation to fail",
        CostRegistryCode = "REG-4004",
        CustomerInvoiceCode = "INV-2025-005",
        IsPost = true
    },
    
    // 6. Errore: CostRegistryCode troppo lungo (eccede MaxLength)
    new CustomerInvoiceCostDTO
    {
        CustomerInvoiceId = 6,
        Cost = 89.99m,
        Quantity = 10,
        Name = "Monthly Support",
        CostRegistryCode = "REG-5005-EXTRA-LONG-CODE-THAT-EXCEEDS-THE-MAXIMUM-LENGTH-OF-100-CHARACTERS-SPECIFIED-IN-THE-CONSTRAINTS-OF-THE-CUSTOMER-INVOICE-COST-DTO-CLASS",
        CustomerInvoiceCode = "INV-2025-006",
        IsPost = true
    },
    
    // 7. Errore: CustomerInvoiceCode troppo lungo (eccede MaxLength)
    new CustomerInvoiceCostDTO
    {
        CustomerInvoiceId = 7,
        Cost = 125.00m,
        Quantity = 5,
        Name = "Cloud Storage",
        CostRegistryCode = "REG-6006",
        CustomerInvoiceCode = "INV-2025-007-THIS-INVOICE-CODE-IS-INTENTIONALLY-LONGER-THAN-THE-ALLOWED-50-CHARACTERS",
        IsPost = true
    },
    
    // 8. Errore: Campi multipli mancanti (Cost e Name null)
    new CustomerInvoiceCostDTO
    {
        CustomerInvoiceId = 8,
        Cost = null,
        Quantity = 2,
        Name = null,
        CostRegistryCode = "REG-7007",
        CustomerInvoiceCode = "INV-2025-008",
        IsPost = true
    },
    
    // 9. Nessun errore: Tutte le proprietà null ma IsPost è false
    new CustomerInvoiceCostDTO
    {
        CustomerInvoiceId = null,
        Cost = null,
        Quantity = null,
        Name = null,
        CostRegistryCode = null,
        CustomerInvoiceCode = null,
        IsPost = false
    },
    
    // 10. Errore: Tutte le proprietà richieste mancanti
    new CustomerInvoiceCostDTO
    {
        IsPost = true
        // Tutte le proprietà richieste quando IsPost=true sono mancanti
    }
};
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

            Random random = new Random();
            int randomIndex = random.Next(0, dtoList.Count);
            var invoiceCost = dtoList[randomIndex];

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
