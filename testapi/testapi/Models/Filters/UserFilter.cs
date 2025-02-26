namespace API.Models.Filters
{
    public class UserFilter
    {

        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public List<string>? Roles { get; set; } = new List<string>();
        public int? page { get; set; }
    }
}
