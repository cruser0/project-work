using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Winform.Entities;
using Winform.Services;

namespace Winform.Forms
{
    public partial class CreateCustomerForm : Form
    {
        CustomerService _customerService;
        public CreateCustomerForm()
        {
            _customerService = new CustomerService();
            InitializeComponent();
            CreateCustomerUserControl.createButton += CreateCustomerUserControl_createButton;
        }

        private void CreateCustomerUserControl_createButton(object? sender, Entities.DTO.SupplierCustomerDTO e)
        {
            if (!string.IsNullOrEmpty(e.Name) || !string.IsNullOrEmpty(e.Country))
            {
                Customer customer = new Customer { CustomerName = e.Name, Country = e.Country };
                try
                {
                    _customerService.Create(customer);
                    MessageBox.Show("Customer created Successfully!");
                    this.Close();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }

            }else
                MessageBox.Show("Name and Country must not be empty");

        }
    }
}
