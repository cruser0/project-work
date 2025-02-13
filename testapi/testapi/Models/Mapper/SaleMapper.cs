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
                CustomerId = sale.CustomerId,
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
                CustomerId = sale.CustomerId,
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
                SaleId = sale.SaleId,
                BookingNumber = sale.BookingNumber,
                BoLnumber = sale.BoLnumber,
                SaleDate = sale.SaleDate,
                CustomerId = sale.CustomerId,
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
                SaleId = (int)sale.SaleId,
                BookingNumber = sale.BookingNumber,
                BoLnumber = sale.BoLnumber,
                SaleDate = sale.SaleDate,
                CustomerId = sale.CustomerId,
                TotalRevenue = sale.TotalRevenue,
                Status = sale.Status

            };
        }
    }
}

