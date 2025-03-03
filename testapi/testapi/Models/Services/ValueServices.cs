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

        public TabelleCustomerDto GetCustomerInvoiceCosts(CustomerInvoiceCostFilter? costFilter,
                                                CustomerInvoiceFilter? invoiceFilter,
                                                SaleFilter? saleFilter,
                                                CustomerFilter? customerFilter)
        {
            var customerInvoiceCosts = ApplyFilter(costFilter).ToList();
            var customerInvoices = ApplyFilter(invoiceFilter).ToList();
            var customers = ApplyFilter(customerFilter).ToList();
            var sales = ApplyFilter(saleFilter).ToList();


            return new TabelleCustomerDto(customers, sales, customerInvoices, customerInvoiceCosts);
        }

        //if (filter.SalePage != null)
        //{
        //    query = query.Skip(((int)filter.SalePage - 1) * itemsPerPage).Take(itemsPerPage);
        //}


        public TabelleSupplierDto GetSupplierInvoiceCosts(SupplierInvoiceCostFilter? costFilter,
                                                SupplierInvoiceFilter? invoiceFilter,
                                                SupplierFilter? supplierFilter)
        {
            var supplierInvoiceCosts = ApplyFilter(costFilter).ToList();
            var supplierInvoices = ApplyFilter(invoiceFilter).ToList();
            var suppliers = ApplyFilter(supplierFilter).ToList();

            var query1 = (from s in suppliers
                          join si in supplierInvoices on s.SupplierId equals si.SupplierId
                          join sic in supplierInvoiceCosts on si.InvoiceId equals sic.SupplierInvoiceId
                          select new SupplierDTOGet
                          {
                              SupplierId = s.SupplierId,
                              Country = s.Country,
                              CreatedAt = s.CreatedAt,
                              SupplierName = s.SupplierName,
                              Deprecated = s.Deprecated,
                              OriginalID = s.OriginalID
                          }).DistinctBy(x => x.SupplierId).ToList();

            var query2 = (from s in suppliers
                          join si in supplierInvoices on s.SupplierId equals si.SupplierId
                          join sic in supplierInvoiceCosts on si.InvoiceId equals sic.SupplierInvoiceId
                          select new SupplierInvoiceDTOGet
                          {
                              InvoiceId = si.InvoiceId,
                              SupplierId = si.SupplierId,
                              InvoiceAmount = si.InvoiceAmount,
                              InvoiceDate = si.InvoiceDate,
                              SaleId = si.SaleId,
                              Status = si.Status
                          }).DistinctBy(x => x.InvoiceId).ToList();

            var query3 = (from s in suppliers
                          join si in supplierInvoices on s.SupplierId equals si.SupplierId
                          join sic in supplierInvoiceCosts on si.InvoiceId equals sic.SupplierInvoiceId
                          select new SupplierInvoiceCostDTOGet
                          {
                              SupplierInvoiceCostsId = sic.SupplierInvoiceCostsId,
                              Cost = sic.Cost,
                              Name = sic.Name,
                              Quantity = sic.Quantity,
                              SupplierInvoiceId = sic.SupplierInvoiceId
                          }).DistinctBy(x => x.SupplierInvoiceCostsId).ToList();


            return new TabelleSupplierDto(query1, query2, query3);
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

        private IQueryable<SupplierDTOGet> ApplyFilter(SupplierFilter? filter)
        {

            var query = _context.Suppliers.AsQueryable();


            if (filter != null)
            {
                if (filter.SupplierOriginalID != null)
                {
                    query = query.Where(x => x.OriginalID == filter.SupplierOriginalID);
                }
                if (!string.IsNullOrEmpty(filter.SupplierName))
                {
                    query = query.Where(x => x.SupplierName.Contains(filter.SupplierName));
                }
                if (filter.SupplierCreatedDateFrom.HasValue)
                {
                    if ((filter.SupplierCreatedDateFrom <= DateTime.Now && filter.SupplierCreatedDateFrom > new DateTime(1975, 1, 1)))
                    {
                        query = query.Where(x => x.CreatedAt >= filter.SupplierCreatedDateFrom);
                    }
                }
                if (filter.SupplierCreatedDateTo.HasValue)
                {
                    if (filter.SupplierCreatedDateTo <= DateTime.Now && filter.SupplierCreatedDateTo >= filter.SupplierCreatedDateTo)
                        query = query.Where(x => x.CreatedAt <= filter.SupplierCreatedDateTo);
                }



                if (!string.IsNullOrEmpty(filter.SupplierCountry))
                {
                    query = query.Where(x => x.Country.Contains(filter.SupplierCountry));
                }

                if (filter.SupplierDeprecated != null)
                {
                    query = query.Where(x => x.Deprecated == filter.SupplierDeprecated);
                }
                if (filter.SupplierPage != null)
                {
                    query = query.Skip(((int)filter.SupplierPage - 1) * itemsPerPage).Take(itemsPerPage);
                }
            }
            return query.Select(x => SupplierMapper.MapGet(x));
        }

        private IQueryable<SupplierInvoiceDTOGet> ApplyFilter(SupplierInvoiceFilter? filter)
        {

            var query = _context.SupplierInvoices.AsQueryable();

            if (filter != null)
            {
                if (filter.SupplierInvoiceInvoiceDateFrom.HasValue)
                {
                    if ((filter.SupplierInvoiceInvoiceDateFrom <= DateTime.Now && filter.SupplierInvoiceInvoiceDateFrom > new DateTime(1975, 1, 1)))
                    {
                        query = query.Where(x => x.InvoiceDate >= filter.SupplierInvoiceInvoiceDateFrom);
                    }
                }
                if (filter.SupplierInvoiceInvoiceDateTo.HasValue)
                {
                    if (filter.SupplierInvoiceInvoiceDateTo <= DateTime.Now && filter.SupplierInvoiceInvoiceDateTo >= filter.SupplierInvoiceInvoiceDateFrom)
                        query = query.Where(x => x.InvoiceDate <= filter.SupplierInvoiceInvoiceDateTo);
                }

                if (filter.SupplierInvoiceInvoiceAmountFrom != null && filter.SupplierInvoiceInvoiceAmountTo != null)
                {
                    query = query.Where(s => s.InvoiceAmount >= filter.SupplierInvoiceInvoiceAmountFrom && s.InvoiceAmount <= filter.SupplierInvoiceInvoiceAmountTo);
                }
                else if (filter.SupplierInvoiceInvoiceAmountFrom != null)
                {
                    query = query.Where(s => s.InvoiceAmount >= filter.SupplierInvoiceInvoiceAmountFrom);
                }
                else if (filter.SupplierInvoiceInvoiceAmountTo != null)
                {
                    query = query.Where(s => s.InvoiceAmount <= filter.SupplierInvoiceInvoiceAmountTo);
                }

                if (filter.SupplierInvoiceSaleID != null)
                {
                    query = query.Where(x => x.SaleId == filter.SupplierInvoiceSaleID);
                }
                if (filter.SupplierInvoiceSupplierID != null)
                {
                    query = query.Where(x => x.SupplierId == filter.SupplierInvoiceSupplierID);
                }
                if (!string.IsNullOrEmpty(filter.SupplierInvoiceStatus))
                {
                    if (!filter.SupplierInvoiceStatus.Equals("All"))
                        query = query.Where(x => x.Status == filter.SupplierInvoiceStatus.ToLower());
                }
                if (filter.SupplierInvoicePage != null)
                {
                    query = query.Skip(((int)filter.SupplierInvoicePage - 1) * itemsPerPage).Take(itemsPerPage);
                }
            }


            return query.Select(x => SupplierInvoiceMapper.MapGet(x));
        }

        public IQueryable<SupplierInvoiceCostDTOGet> ApplyFilter(SupplierInvoiceCostFilter? filter)
        {
            var query = _context.SupplierInvoiceCosts.AsQueryable();

            if (filter != null)
            {
                if (filter.SupplierInvoiceCostSupplierInvoiceId != null)
                {
                    query = query.Where(x => x.SupplierInvoiceId == filter.SupplierInvoiceCostSupplierInvoiceId);
                }
                if (!string.IsNullOrEmpty(filter.SupplierInvoiceCostName))
                {
                    query = query.Where(x => x.Name.Contains(filter.SupplierInvoiceCostName));
                }

                if (filter.SupplierInvoiceCostCostFrom != null && filter.SupplierInvoiceCostCostTo != null)
                {
                    if (filter.SupplierInvoiceCostCostFrom > filter.SupplierInvoiceCostCostTo)
                    {
                        throw new ArgumentException("CostFrom cannot be more than CostTo.");
                    }

                    query = query.Where(s => s.Cost >= filter.SupplierInvoiceCostCostFrom && s.Cost <= filter.SupplierInvoiceCostCostTo);
                }
                else if (filter.SupplierInvoiceCostCostFrom != null)
                {
                    query = query.Where(s => s.Cost >= filter.SupplierInvoiceCostCostFrom);
                }
                else if (filter.SupplierInvoiceCostCostTo != null)
                {
                    query = query.Where(s => s.Cost <= filter.SupplierInvoiceCostCostTo);
                }

                if (filter.SupplierInvoiceCostQuantity != null)
                {
                    query = query.Where(x => x.Quantity == filter.SupplierInvoiceCostQuantity);
                }
                if (filter.SupplierInvoiceCostPage != null)
                {
                    query = query.Skip(((int)filter.SupplierInvoiceCostPage - 1) * itemsPerPage).Take(itemsPerPage);
                }
            }

            return query.Select(x => SupplierInvoiceCostMapper.MapGet(x));
        }

    }
}
