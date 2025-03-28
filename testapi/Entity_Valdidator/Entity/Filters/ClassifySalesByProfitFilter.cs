﻿using System;

namespace Entity_Valdidator.Entity.Filters
{
    public class ClassifySalesByProfitFilter
    {
        public int? TotalSpentFrom { get; set; }
        public int? TotalSpentTo { get; set; }
        public int? TotalRevenueFrom { get; set; }
        public int? TotalRevenueTo { get; set; }
        public string FilterMargin { get; set; }
        public int? ProfitFrom { get; set; }
        public int? ProfitTo { get; set; }
        public string BoLNumber { get; set; }
        public string BKNumber { get; set; }
        public int? CustomerID { get; set; }
        public string Status { get; set; }
        public string CustomerName { get; set; }
        public string CustomerCountry { get; set; }
        public string CountryRegion { get; set; }
        public int? SaleID { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
    }
}
