using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Winform.Entities.DTO;

namespace Winform.Forms.control
{
    public partial class CreateCustomerSupplierUserControl : UserControl
    {
        public event EventHandler<SupplierCustomerDTO> createButton;
        public CreateCustomerSupplierUserControl()
        {
            InitializeComponent();
        }

        private void CreateSaveBtn_Click(object sender, EventArgs e)
        {
            SupplierCustomerDTO supplierCustomerDTO= new SupplierCustomerDTO {Name=CreateNameTxt.Text,Country=CreateCountryTxt.Text };
            createButton.Invoke(this, supplierCustomerDTO);
        }
    }
}
