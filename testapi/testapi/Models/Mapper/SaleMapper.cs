using API.Models.DTO;
using API.Models.Entities;

namespace API.Models.Mapper
{
    public class SaleMapper
    {
        public static SaleDTO Map(Sale sale)
        {
            if (sale == null)
                return null;
            return new SaleDTO()
            {

                BookingNumber = sale.BookingNumber,
                BoLnumber = sale.BoLnumber,
                SaleDate = sale.SaleDate,
                CustomerId = sale.CustomerID,
                TotalRevenue = sale.TotalRevenue,
                Status = sale.Status

            };
        }
        public static Sale Map(SaleDTO sale)
        {
            if (sale == null)
                return null;
            return new Sale()
            {

                BookingNumber = sale.BookingNumber,
                BoLnumber = sale.BoLnumber,
                SaleDate = sale.SaleDate,
                CustomerID = sale.CustomerId,
                TotalRevenue = sale.TotalRevenue,
                Status = sale.Status

            };
        }

        public static SaleDTOGet MapGet(Sale sale)
        {
            if (sale == null)
                return null;
            return new SaleDTOGet()
            {
                SaleId = sale.SaleID,
                BookingNumber = sale.BookingNumber,
                BoLnumber = sale.BoLnumber,
                SaleDate = sale.SaleDate,
                CustomerId = sale.CustomerID,
                TotalRevenue = sale.TotalRevenue,
                Status = sale.Status

            };
        }
        public static Sale MapGet(SaleDTOGet sale)
        {
            if (sale == null)
                return null;
            return new Sale()
            {
                SaleID = (int)sale.SaleId,
                BookingNumber = sale.BookingNumber,
                BoLnumber = sale.BoLnumber,
                SaleDate = sale.SaleDate,
                CustomerID = sale.CustomerId,
                TotalRevenue = sale.TotalRevenue,
                Status = sale.Status

            };
        }
    }
}

