namespace API.Models.DTO;
public class SupplierDTO
{


    //public int SupplierId { get; set; }
    public string? SupplierName { get; set; }
    public string? Country { get; set; }
    public bool? Deprecated { get; set; }
    public DateTime? CreatedAt { get; set; }

}
public class SupplierDTOGet : SupplierDTO
{
    public int? SupplierId { get; set; }
    public int? OriginalID { get; set; }
}
