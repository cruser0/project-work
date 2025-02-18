namespace API.Models.DTO
{
    public class CustomerDTO
    {
        public string? CustomerName { get; set; }
        public string? Country { get; set; }

        public bool? Deprecated { get; set; }

    }

    public class CustomerDTOGet : CustomerDTO
    {
        public int? CustomerId { get; set; }
    }
}
