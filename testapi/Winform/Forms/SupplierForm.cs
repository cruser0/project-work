using API.Models.DTO;

namespace Winform
{
    public partial class SupplierForm : BaseGridForm<SupplierDTOGet>
    {
        public SupplierForm() : base(new Uri("http://localhost:5069/api/supplier"))
        {
            InitializeComponent();
        }
    }
}
