using Entity_Validator.Entity.DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WinformDotNetFramework
{
    public partial class Form2 : Form
    {
        List<CustomerDTO> dtoList = new List<CustomerDTO>
        {
        // 1. Entità valida (senza errori)
        new CustomerDTO
        {
            CustomerName = "John Doe",
            Country = "USA",
            Deprecated = false,
            CreatedAt = DateTime.Now,
            IsPost = true
        },

        // 2. Customer con errore nel nome (troppo lungo)
        new CustomerDTO
        {
            CustomerName = new string('A', 101), // Troppo lungo
            Country = "USA",
            Deprecated = false,
            CreatedAt = DateTime.Now,
            IsPost = true
        },

        // 3. Customer con errore nel nome (vuoto)
        new CustomerDTO
        {
            CustomerName = string.Empty, // Vuoto
            Country = "USA",
            Deprecated = false,
            CreatedAt = DateTime.Now,
            IsPost = true
        },

        // 4. Customer con errore nel paese (numero)
        new CustomerDTO
        {
            CustomerName = "John Doe",
            Country = "USA123", // Contiene numeri
            Deprecated = false,
            CreatedAt = DateTime.Now,
            IsPost = true
        },

        // 5. Customer con errore nel paese (vuoto)
        new CustomerDTO
        {
            CustomerName = "John Doe",
            Country = string.Empty, // Vuoto
            Deprecated = false,
            CreatedAt = DateTime.Now,
            IsPost = true
        },

        // 6. Customer con errore nella data (null)
        new CustomerDTO
        {
            CustomerName = "John Doe",
            Country = "USA",
            Deprecated = false,
            CreatedAt = null, // Data nulla
            IsPost = true
        },

        // 7. Customer con errore nella proprietà booleana (nulla)
        new CustomerDTO
        {
            CustomerName = "John Doe",
            Country = "USA",
            Deprecated = null, // Nullable ma non valorizzata
            CreatedAt = DateTime.Now,
            IsPost = true
        },

        // 8. Customer con errore IsPost mancante (nessuna validazione per RequiredIf)
        new CustomerDTO
        {
            CustomerName = "John Doe",
            Country = "USA",
            Deprecated = false,
            CreatedAt = DateTime.Now,
            IsPost = false // Non post, quindi non richiesto
        },

        // 9. Customer con errore Country che contiene caratteri speciali
        new CustomerDTO
        {
            CustomerName = "John Doe",
            Country = "USA@#", // Caratteri speciali
            Deprecated = false,
            CreatedAt = DateTime.Now,
            IsPost = true
        },

        // 10. Customer con errore nella validazione boolean (nulla)
        new CustomerDTO
        {
            CustomerName = "John Doe",
            Country = "USA",
            Deprecated = null, // Nullable ma non valorizzato
            CreatedAt = DateTime.Now,
            IsPost = true
        }

    };

        public Form2()
        {
            InitializeComponent();
            CustomerNameTxt.propName = "CustomerName";
            CountryTxt.propName = "Country";
            DeprecatedTxt.propName = "Deprecated";
            CreatedAtTxt.propName = "CreatedAt";
            IsPostTxt.propName = "IsPost";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ResetLbl();

            Random random = new Random();
            int randomIndex = random.Next(0, dtoList.Count);
            var customer = dtoList[randomIndex];

            ValidateTextBoxes(customer);
        }




        private void ValidateTextBoxes(CustomerDTO customer)
        {
            // assegna il testo alle textbox
            CustomerNameTxt.Text = customer.CustomerName ?? string.Empty;
            CountryTxt.Text = customer.Country ?? string.Empty;
            DeprecatedTxt.Text = customer.Deprecated?.ToString() ?? string.Empty;
            CreatedAtTxt.Text = customer.CreatedAt?.ToString("yyyy-MM-ddTHH:mm:ss") ?? string.Empty;
            IsPostTxt.Text = customer.IsPost.ToString();

            UtilityFunctions.ValidateTextBoxes(this, customer);
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
