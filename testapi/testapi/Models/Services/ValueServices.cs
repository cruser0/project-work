using API.Models.DTO;
using API.Models.Filters;
using API.Models.Mapper;

namespace API.Models.Services
{


    public class ValueServices
    {
        private readonly Progetto_FormativoContext _context;
        private int itemsPerPage;

        public ValueServices(Progetto_FormativoContext ctx)
        {
            itemsPerPage = 10;
            _context = ctx;
        }

        public ICollection<testDTO> GetCustomerInvoiceCosts(CustomerInvoiceCostFilter? costFilter,
                                                                             CustomerInvoiceFilter? invoiceFilter,
                                                                             SaleFilter? saleFilter,
                                                                             CustomerFilter? customerFilter)
        {
            var customerInvoiceCosts = ApplyFilter(costFilter).AsEnumerable();
            var customerInvoices = ApplyFilter(invoiceFilter).AsEnumerable();
            var customers = ApplyFilter(customerFilter).AsEnumerable();
            var sales = ApplyFilter(saleFilter).AsEnumerable();

            //if (filter.SalePage != null)
            //{
            //    query = query.Skip(((int)filter.SalePage - 1) * itemsPerPage).Take(itemsPerPage);
            //}

            var query = (from customer in customers
                         join sale in sales on customer.CustomerId equals sale.CustomerId
                         join invoice in customerInvoices on sale.SaleId equals invoice.SaleId
                         join invoiceCost in customerInvoiceCosts on invoice.CustomerInvoiceId equals invoiceCost.CustomerInvoiceId
                         select new { Customers = customer, Sales = sale, Invoices = invoice, Costs = invoiceCost }).ToList();




            return query.Select(x => new testDTO(x.Customers, x.Sales, x.Invoices, x.Costs)).ToList();
        }


        private IQueryable<CustomerInvoiceCostDTOGet> ApplyFilter(CustomerInvoiceCostFilter? filter)
        {
            var query = _context.CustomerInvoiceCosts.AsQueryable();

            if (filter != null)
            {
                if (filter.CustomerInvoiceCostCustomerInvoiceId != null)
                {
                    query = query.Where(x => x.CustomerInvoiceId == filter.CustomerInvoiceCostCustomerInvoiceId);
                }
                if (!string.IsNullOrEmpty(filter.CustomerInvoiceCostName))
                {
                    query = query.Where(x => x.Name.Contains(filter.CustomerInvoiceCostName));
                }

                if (filter.CustomerInvoiceCostCostFrom != null && filter.CustomerInvoiceCostCostTo != null)
                {
                    if (filter.CustomerInvoiceCostCostFrom > filter.CustomerInvoiceCostCostTo)
                    {
                        throw new ArgumentException("CostFrom cannot be more than CostTo.");
                    }

                    query = query.Where(s => s.Cost >= filter.CustomerInvoiceCostCostFrom && s.Cost <= filter.CustomerInvoiceCostCostTo);
                }
                else if (filter.CustomerInvoiceCostCostFrom != null)
                {
                    query = query.Where(s => s.Cost >= filter.CustomerInvoiceCostCostFrom);
                }
                else if (filter.CustomerInvoiceCostCostTo != null)
                {
                    query = query.Where(s => s.Cost <= filter.CustomerInvoiceCostCostTo);
                }

                if (filter.CustomerInvoiceCostQuantity != null)
                {
                    query = query.Where(x => x.Quantity == filter.CustomerInvoiceCostQuantity);
                }
            }

            return query.Select(x => CustomerInvoiceCostMapper.MapGet(x));
        }

        private IQueryable<CustomerInvoiceDTOGet> ApplyFilter(CustomerInvoiceFilter? filter)
        {
            var query = _context.CustomerInvoices.AsQueryable();

            if (filter != null)
            {
                if (filter.CustomerInvoiceSaleId != null)
                {
                    query = query.Where(x => x.SaleId == filter.CustomerInvoiceSaleId);
                }

                if (filter.CustomerInvoiceInvoiceAmountFrom != null && filter.CustomerInvoiceInvoiceAmountTo != null)
                {
                    query = query.Where(s => s.InvoiceAmount >= filter.CustomerInvoiceInvoiceAmountFrom && s.InvoiceAmount <= filter.CustomerInvoiceInvoiceAmountTo);
                }
                else if (filter.CustomerInvoiceInvoiceAmountFrom != null)
                {
                    query = query.Where(s => s.InvoiceAmount >= filter.CustomerInvoiceInvoiceAmountFrom);
                }
                else if (filter.CustomerInvoiceInvoiceAmountTo != null)
                {
                    query = query.Where(s => s.InvoiceAmount <= filter.CustomerInvoiceInvoiceAmountTo);
                }

                if (filter.CustomerInvoiceInvoiceDateFrom != null && filter.CustomerInvoiceInvoiceDateTo != null)
                {
                    query = query.Where(s => s.InvoiceDate >= filter.CustomerInvoiceInvoiceDateFrom && s.InvoiceDate <= filter.CustomerInvoiceInvoiceDateTo);
                }
                else if (filter.CustomerInvoiceInvoiceDateFrom != null)
                {
                    query = query.Where(s => s.InvoiceDate >= filter.CustomerInvoiceInvoiceDateFrom);
                }
                else if (filter.CustomerInvoiceInvoiceDateTo != null)
                {
                    query = query.Where(s => s.InvoiceDate <= filter.CustomerInvoiceInvoiceDateTo);
                }

                if (!string.IsNullOrEmpty(filter.CustomerInvoiceStatus))
                {
                    query = query.Where(s => s.Status == filter.CustomerInvoiceStatus);
                }

            }

            return query.Select(x => CustomerInvoiceMapper.MapGet(x));
        }

        private IQueryable<SaleDTOGet> ApplyFilter(SaleFilter? filter)
        {
            var query = _context.Sales.AsQueryable();

            if (filter != null)
            {
                if (!string.IsNullOrEmpty(filter.SaleBookingNumber))
                {
                    query = query.Where(s => s.BookingNumber.StartsWith(filter.SaleBookingNumber));
                }

                if (!string.IsNullOrEmpty(filter.SaleBoLnumber))
                {
                    query = query.Where(s => s.BoLnumber.StartsWith(filter.SaleBoLnumber));
                }

                if (filter.SaleDateFrom != null && filter.SaleDateTo != null)
                {
                    if (filter.SaleDateFrom > filter.SaleDateTo)
                    {
                        throw new ArgumentException("SaleDateFrom cannot be later than SaleDateTo.");
                    }

                    query = query.Where(s => s.SaleDate >= filter.SaleDateFrom && s.SaleDate <= filter.SaleDateTo);
                }
                else if (filter.SaleRevenueFrom != null)
                {
                    query = query.Where(s => s.TotalRevenue >= filter.SaleRevenueFrom);
                }
                else if (filter.SaleRevenueTo != null)
                {
                    query = query.Where(s => s.TotalRevenue <= filter.SaleRevenueTo);
                }

                if (filter.SaleRevenueFrom != null && filter.SaleRevenueTo != null)
                {
                    if (filter.SaleRevenueFrom > filter.SaleRevenueTo)
                    {
                        throw new ArgumentException("RevenueFrom cannot be later than RevenueTo.");
                    }

                    query = query.Where(s => s.TotalRevenue >= filter.SaleRevenueFrom && s.TotalRevenue <= filter.SaleRevenueTo);
                }
                else if (filter.SaleRevenueFrom != null)
                {
                    query = query.Where(s => s.TotalRevenue >= filter.SaleRevenueFrom);
                }
                else if (filter.SaleRevenueTo != null)
                {
                    query = query.Where(s => s.TotalRevenue <= filter.SaleRevenueTo);
                }

                if (filter.SaleCustomerId != null)
                {
                    query = query.Where(s => s.CustomerId == filter.SaleCustomerId);
                }

                if (!string.IsNullOrEmpty(filter.SaleStatus))
                {
                    query = query.Where(s => s.Status == filter.SaleStatus);
                }

            }

            return query.Select(x => SaleMapper.MapGet(x));
        }

        private IQueryable<CustomerDTOGet> ApplyFilter(CustomerFilter? filter)
        {

            var query = _context.Customers.AsQueryable();

            if (filter != null)
            {
                // Filtra per OriginalID se specificato
                if (filter.CustomerOriginalID != null)
                {
                    query = query.Where(x => x.OriginalID == filter.CustomerOriginalID);
                }

                // Filtra per nome se specificato
                if (!string.IsNullOrEmpty(filter.CustomerName))
                {
                    query = query.Where(x => x.CustomerName.Contains(filter.CustomerName));
                }

                // Filtra per data di creazione
                if (filter.CustomerCreatedDateFrom != null || filter.CustomerCreatedDateTo != null)
                {
                    if (filter.CustomerCreatedDateFrom != null)
                    {
                        query = query.Where(s => s.CreatedAt >= filter.CustomerCreatedDateFrom);
                    }
                    if (filter.CustomerCreatedDateTo != null)
                    {
                        query = query.Where(s => s.CreatedAt <= filter.CustomerCreatedDateTo);
                    }
                }

                // Filtra per paese se specificato
                if (!string.IsNullOrEmpty(filter.CustomerCountry))
                {
                    query = query.Where(x => x.Country.Contains(filter.CustomerCountry));
                }

                // Filtra per stato di deprecazione se specificato
                if (filter.CustomerDeprecated != null)
                {
                    query = query.Where(x => x.Deprecated == filter.CustomerDeprecated);
                }


            }

            return query.Select(x => CustomerMapper.MapGet(x));
        }
    }
}
