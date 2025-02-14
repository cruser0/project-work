using API.Models.DTO;

namespace Winform
{
    public partial class CustomerForm : BaseGridForm<CustomerDTOGet>
    {
        public CustomerForm() : base(new Uri("http://localhost:5069/api/customer"))
        {
            InitializeComponent();
        }
    }
}
