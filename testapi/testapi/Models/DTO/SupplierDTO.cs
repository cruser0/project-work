namespace testapi.Models.DTO;
public class SupplierDTO
{


    //public int SupplierId { get; set; }
    public string? SupplierName { get; set; }
    public string? Country { get; set; }


}
public class SupplierDTOGet : SupplierDTO
{
    public int? SupplierId { get; set; }
}
