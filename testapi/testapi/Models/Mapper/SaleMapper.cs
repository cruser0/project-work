using API.Models.DTO;
using API.Models.Entities;

namespace API.Models.Mapper
{
    public class SaleMapper
    {
        public static SaleDTO Map(Sale sale)
        {
            return new SaleDTO()
            {

                BookingNumber = sale.BookingNumber,
                BoLnumber = sale.BoLnumber,
                SaleDate = sale.SaleDate,
                CustomerId = sale.CustomerID,
                TotalRevenue = sale.TotalRevenue,
                Status = sale.Status!.StatusName

            };
        }
        public static Sale Map(SaleDTO sale, Status status)
        {
            return new Sale()
            {

                BookingNumber = sale.BookingNumber,
                BoLnumber = sale.BoLnumber,
                SaleDate = sale.SaleDate,
                CustomerID = sale.CustomerId,
                TotalRevenue = sale.TotalRevenue,
                Status = status,
                StatusID = status.StatusID

            };
        }

        public static SaleDTOGet MapGet(Sale sale)
        {
            return new SaleDTOGet()
            {
                SaleId = sale.SaleID,
                BookingNumber = sale.BookingNumber,
                BoLnumber = sale.BoLnumber,
                SaleDate = sale.SaleDate,
                CustomerId = sale.CustomerID,
                TotalRevenue = sale.TotalRevenue,
                Status = sale.Status!.StatusName

            };
        }
        public static Sale MapGet(SaleDTOGet sale, Status status)
        {
            return new Sale()
            {
                SaleID = (int)sale.SaleId!,
                BookingNumber = sale.BookingNumber,
                BoLnumber = sale.BoLnumber,
                SaleDate = sale.SaleDate,
                CustomerID = sale.CustomerId,
                TotalRevenue = sale.TotalRevenue,
                Status = status,
                StatusID = status.StatusID

            };
        }
    }
}

