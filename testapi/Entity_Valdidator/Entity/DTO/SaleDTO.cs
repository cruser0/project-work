
using Entity_Validator.Entity.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace Entity_Validator.Entity.DTO
{
    public class SaleDTO
    {
        [RequiredIf("IsPost", true)]
        [MaxLength(50, ErrorMessage = "Must be at most {1} characters.")]
        public string BookingNumber { get; set; }

        [RequiredIf("IsPost", true)]
        [MaxLength(50, ErrorMessage = "Must be at most {1} characters.")]
        public string BoLnumber { get; set; }

        [RequiredIf("IsPost", true)]
        public DateTime? SaleDate { get; set; }

        [RequiredIf("IsPost", true)]
        public int? CustomerId { get; set; }

        [Range(0.0, 0.0, ErrorMessage = "{0} must be equal to 0.")]
        public decimal? TotalRevenue { get; set; }

        [RequiredIf("IsPost", true)]
        public string Status { get; set; } //active/closed

        public bool IsPost { get; set; }
    }

    public class SaleDTOGet : SaleDTO
    {
        public int? SaleId { get; set; }
    }
    public class SaleCustomerDTO : SaleDTOGet
    {
        [RequiredIf("IsPost", true)]
        [MaxLength(100, ErrorMessage = "Must be at most {1} characters.")]
        public string CustomerName { get; set; }

        [RequiredIf("IsPost", true)]
        [MaxLength(100, ErrorMessage = "Must be at most {1} characters.")]
        [RegularExpression("^[A-Za-z ]+$", ErrorMessage = "Only alphabetical characters and spaces are allowed.")]
        public string Country { get; set; }

        public SaleCustomerDTO()
        {

        }
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