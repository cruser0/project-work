
using API.Models.Exceptions;

using API.Models.Mapper;
using Entity_Validator.Entity.DTO;
using Entity_Validator.Entity.Filters;
using Microsoft.EntityFrameworkCore;

namespace API.Models.Services
{


    public class ValueServices
    {
        private readonly Progetto_FormativoContext _context;
        private readonly int itemsPerPage;

        public ValueServices(Progetto_FormativoContext ctx)
        {
            itemsPerPage = 10;
            _context = ctx;
        }

        public async Task<TabelleCustomerDto> GetCustomerInvoiceCosts(CustomerInvoiceCostFilter? costFilter,
                                                CustomerInvoiceFilter? invoiceFilter,
                                                SaleCustomerFilter? saleFilter,
                                                CustomerFilter? customerFilter)
        {
            var customerInvoiceCosts = await ApplyFilter(costFilter).ToListAsync();
            var customerInvoices = await ApplyFilter(invoiceFilter).ToListAsync();
            var customers = await ApplyFilter(customerFilter).ToListAsync();
            var sales = await ApplyFilter(saleFilter).ToListAsync();


            return new TabelleCustomerDto(customers, sales, customerInvoices, customerInvoiceCosts);
        }


        public async Task<TabelleSupplierDto> GetSupplierInvoiceCosts(SupplierInvoiceCostFilter? costFilter,
                                                SupplierInvoiceFilter? invoiceFilter,
                                                SupplierFilter? supplierFilter)
        {
            var supplierInvoiceCosts = await ApplyFilter(costFilter).ToListAsync();
            var supplierInvoices = await ApplyFilter(invoiceFilter).ToListAsync();
            var suppliers = await ApplyFilter(supplierFilter).ToListAsync();

            return new TabelleSupplierDto(suppliers, supplierInvoices, supplierInvoiceCosts);
        }

        private IQueryable<CustomerInvoiceCostDTOGet> ApplyFilter(CustomerInvoiceCostFilter? filter)
        {
            var query = _context.CustomerInvoiceCosts.Include(x => x.CostRegistry).Include(x => x.CustomerInvoice).AsQueryable();

            if (filter != null)
            {
                if (!string.IsNullOrEmpty(filter.CustomerInvoiceCostCustomerInvoiceCode))
                {
                    query = query.Where(x => x.CustomerInvoice.CustomerInvoiceCode.Contains(filter.CustomerInvoiceCostCustomerInvoiceCode));
                }
                if (!string.IsNullOrEmpty(filter.CustomerInvoiceCostName))
                {
                    query = query.Where(x => x.Name.Contains(filter.CustomerInvoiceCostName));
                }

                if (filter.CustomerInvoiceCostCostFrom != null && filter.CustomerInvoiceCostCostTo != null)
                {
                    if (filter.CustomerInvoiceCostCostFrom > filter.CustomerInvoiceCostCostTo)
                    {
                        throw new ErrorInputPropertyException("CostFrom cannot be more than CostTo.");
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

                if (!string.IsNullOrEmpty(filter.RegistryCode))
                {
                    query = query.Where(x => x.CostRegistry.CostRegistryName.Contains(filter.RegistryCode));
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
            var query = _context.CustomerInvoices.Include(x => x.Status).Include(x => x.Sale).AsQueryable();

            if (filter != null)
            {
                if (filter.CustomerInvoiceSaleID != null)
                {
                    query = query.Where(x => x.SaleID == filter.CustomerInvoiceSaleID);
                }

                if (!string.IsNullOrEmpty(filter.CustomerInvoiceSaleBoL))
                {
                    query = query.Where(x => x.Sale.BoLnumber.Contains(filter.CustomerInvoiceSaleBoL));
                }

                if (!string.IsNullOrEmpty(filter.CustomerInvoiceSaleBk))
                {
                    query = query.Where(x => x.Sale.BookingNumber.Contains(filter.CustomerInvoiceSaleBk));
                }
                if (!string.IsNullOrEmpty(filter.CustomerInvoiceCode))
                {
                    query = query.Where(x => x.CustomerInvoiceCode.Contains(filter.CustomerInvoiceCode));
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
                    query = query.Where(s => s.Status.StatusName == filter.CustomerInvoiceStatus);
                }

            }

            return query.Select(x => CustomerInvoiceMapper.MapGet(x));
        }

        private IQueryable<SaleDTOGet> ApplyFilter(SaleCustomerFilter? filter)
        {
            var query = _context.Sales.Include(x => x.Status).Include(x => x.Customer).ThenInclude(x => x.Country).AsQueryable();

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
                        throw new ErrorInputPropertyException("SaleDateFrom cannot be later than SaleDateTo.");
                    }

                    query = query.Where(s => s.SaleDate >= filter.SaleDateFrom && s.SaleDate <= filter.SaleDateTo);
                }
                else if (filter.SaleDateFrom != null)
                {
                    query = query.Where(s => s.SaleDate >= filter.SaleDateFrom);
                }
                else if (filter.SaleDateTo != null)
                {
                    query = query.Where(s => s.SaleDate <= filter.SaleDateTo);
                }

                if (filter.SaleRevenueFrom != null && filter.SaleRevenueTo != null)
                {
                    if (filter.SaleRevenueFrom > filter.SaleRevenueTo)
                    {
                        throw new ErrorInputPropertyException("RevenueFrom cannot be later than RevenueTo.");
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

                if (!string.IsNullOrEmpty(filter.SaleCustomerName))
                {
                    query = query.Where(s => s.Customer.CustomerName.Contains(filter.SaleCustomerName));
                }
                if (!string.IsNullOrEmpty(filter.SaleCustomerCountry))
                {
                    query = query.Where(s => s.Customer.Country.CountryName.Contains(filter.SaleCustomerCountry));
                }

                if (!string.IsNullOrEmpty(filter.SaleStatus))
                {
                    query = query.Where(s => s.Status.StatusName == filter.SaleStatus);
                }

            }

            return query.Select(x => SaleMapper.MapGet(x));
        }

        private IQueryable<CustomerDTOGet> ApplyFilter(CustomerFilter? filter)
        {

            var query = _context.Customers.Include(x => x.Country).AsQueryable();

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
                    query = query.Where(x => x.Country.CountryName.Contains(filter.CustomerCountry));
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

            var query = _context.Suppliers.Include(x => x.Country).AsQueryable();


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
                    query = query.Where(x => x.Country.CountryName.Contains(filter.SupplierCountry));
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

            var query = _context.SupplierInvoices.Include(x => x.Status).Include(x => x.Sale).AsQueryable();

            if (filter != null)
            {
                if (filter.SupplierInvoiceSaleID != null)
                {
                    query = query.Where(x => x.SaleID == filter.SupplierInvoiceSaleID);
                }

                if (!string.IsNullOrEmpty(filter.SupplierInvoiceCode))
                {
                    query = query.Where(x => x.SupplierInvoiceCode.Contains(filter.SupplierInvoiceCode));
                }

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

                if (!string.IsNullOrEmpty(filter.SupplierInvoiceSaleBoL))
                {
                    query = query.Where(s => s.Sale.BoLnumber.Contains(filter.SupplierInvoiceSaleBoL));
                }
                if (!string.IsNullOrEmpty(filter.SupplierInvoiceSaleBk))
                {
                    query = query.Where(s => s.Sale.BookingNumber.Contains(filter.SupplierInvoiceSaleBk));
                }

                if (!string.IsNullOrEmpty(filter.SupplierInvoiceStatus))
                {
                    if (!filter.SupplierInvoiceStatus.Equals("All"))
                        query = query.Where(x => x.Status.StatusName == filter.SupplierInvoiceStatus.ToLower());
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
            var query = _context.SupplierInvoiceCosts.Include(x => x.CostRegistry).Include(x => x.SupplierInvoice).AsQueryable();

            if (filter != null)
            {

                if (!string.IsNullOrEmpty(filter.SupplierInvoiceCostSupplierInvoiceCode))
                {
                    query = query.Where(x => x.SupplierInvoice.SupplierInvoiceCode.Contains(filter.SupplierInvoiceCostSupplierInvoiceCode));
                }

                if (!string.IsNullOrEmpty(filter.SupplierInvoiceCostName))
                {
                    query = query.Where(x => x.Name.Contains(filter.SupplierInvoiceCostName));
                }

                if (filter.SupplierInvoiceCostCostFrom != null && filter.SupplierInvoiceCostCostTo != null)
                {
                    if (filter.SupplierInvoiceCostCostFrom > filter.SupplierInvoiceCostCostTo)
                    {
                        throw new ErrorInputPropertyException("CostFrom cannot be more than CostTo.");
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
                if (filter.SupplierInvoiceCostRegistryCode != null)
                {
                    query = query.Where(x => x.CostRegistry.CostRegistryUniqueCode.Contains(filter.SupplierInvoiceCostRegistryCode));
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
