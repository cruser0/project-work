namespace testapi.Models.DTO
{
    public class CustomerDTO
    {
        public string? CustomerName { get; set; }
        public string? Country { get; set; }

    }

    public class CustomerDTOGet : CustomerDTO
    {
        public int? CustomerId { get; set; }
    }
}
