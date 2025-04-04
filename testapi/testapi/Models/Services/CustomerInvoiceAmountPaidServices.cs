using API.Models.Exceptions;
using API.Models.Mapper;
using Entity_Validator;
using Entity_Validator.Entity.DTO;
using Entity_Validator.Entity.Entities;
using Entity_Validator.Entity.Filters;
using Microsoft.EntityFrameworkCore;

namespace API.Models.Services
{
    public interface ICustomerInvoiceAmountPaidServices
    {
        Task<List<CustomerInvoiceAmountPaidDTOGet>> GetBySale(CustomerInvoiceAmountPaidFilter filter);
        Task<CustomerInvoiceAmountPaidDTOGet?> GetByID(int id);
        Task<CustomerInvoiceAmountPaid?> GetOnlyByID(int id);

        Task<CustomerInvoiceAmountPaidDTOGet> Pay(int id, CustomerInvoiceAmountPaidDTO amountPaid);
    }
    public class CustomerInvoiceAmountPaidServices : ICustomerInvoiceAmountPaidServices
    {
        private readonly Progetto_FormativoContext _context;
        public CustomerInvoiceAmountPaidServices(Progetto_FormativoContext ctx)
        {
            _context = ctx;
        }

        private IQueryable<CustomerInvoiceAmountPaidDTOGet> ApplyFilter(CustomerInvoiceAmountPaidFilter filter)
        {
            var query = _context.CustomerInvoiceAmountPaids.Include(x => x.CustomerInvoice).AsQueryable();

            if (filter.PaidCustomerSaleID != null)
                query = query.Where(x => x.CustomerInvoice.SaleID == filter.PaidCustomerSaleID);

            return query.Select(x => CustomerInvoiceAmountPaidMapper.MapGet(x));
        }

        public async Task<List<CustomerInvoiceAmountPaidDTOGet>> GetBySale(CustomerInvoiceAmountPaidFilter filter)
        {
            var data = await ApplyFilter(filter)
                .ToListAsync();

            return data;
        }

        public async Task<CustomerInvoiceAmountPaidDTOGet?> GetByID(int id)
        {
            var data = await _context.CustomerInvoiceAmountPaids
                .Where(x => x.CustomerInvoiceAmountPaidID == id)
                .Include(x => x.CustomerInvoice)
                .Select(x => CustomerInvoiceAmountPaidMapper.MapGet(x))
                .FirstOrDefaultAsync();

            return data;
        }

        public async Task<CustomerInvoiceAmountPaid?> GetOnlyByID(int id)
        {
            var data = await _context.CustomerInvoiceAmountPaids
                .Where(x => x.CustomerInvoiceAmountPaidID == id)
                .FirstOrDefaultAsync();

            return data;
        }

        public async Task<CustomerInvoiceAmountPaidDTOGet> Pay(int id, CustomerInvoiceAmountPaidDTO amountPaid)
        {
            try
            {

                var ap = await _context.CustomerInvoiceAmountPaids.Where(x => x.CustomerInvoiceAmountPaidID == id).Include(x => x.CustomerInvoice).FirstOrDefaultAsync();

                ap.AmountPaid += amountPaid.AmountPaid;

                CustomerInvoiceAmountPaidDTOGet newAmountPaid = CustomerInvoiceAmountPaidMapper.MapGet(ap);

                var results = ValidatorEntity.Validate(newAmountPaid);
                if (results.Count > 0)
                    throw new ValidateException(string.Join('\n', results.First().ErrorMessage));

                _context.CustomerInvoiceAmountPaids.Update(ap);
                await _context.SaveChangesAsync();

                return newAmountPaid;
            }
            catch
            {
                throw;
            }

        }
    }
}
