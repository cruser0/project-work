
using Entity_Validator.Entity.Entities;
using System;

namespace Entity_Validator.Entity.DTO
{
    public class SaleDTO
    {

        public string BookingNumber { get; set; }
        public string BoLnumber { get; set; }
        public DateTime? SaleDate { get; set; }
        public int? CustomerId { get; set; }
        public decimal? TotalRevenue { get; set; }
        public string Status { get; set; } //active/closed
    }

    public class SaleDTOGet : SaleDTO
    {
        public int? SaleId { get; set; }
    }
    public class SaleCustomerDTO : SaleDTOGet
    {
        public string CustomerName { get; set; }
        public string Country { get; set; }
        public SaleCustomerDTO(Sale sale, Customer customer)
        {
            SaleId = sale.SaleID;
            BookingNumber = sale.BookingNumber;
            BoLnumber = sale.BoLnumber;
            SaleDate = sale.SaleDate;
            CustomerId = sale.CustomerID;
            TotalRevenue = sale.TotalRevenue;
            Status = sale.Status.StatusName;
            CustomerName = customer.CustomerName;
            Country = customer.Country.CountryName;
        }
    }
}