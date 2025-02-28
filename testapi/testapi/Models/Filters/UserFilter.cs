namespace API.Models.Filters
{
    public class UserFilter
    {

        public string? UserName { get; set; }
        public string? UserLastName { get; set; }
        public string? UserEmail { get; set; }
        public List<string>? UserRoles { get; set; } = new List<string>();
        public int? UserPage { get; set; }
    }
}
