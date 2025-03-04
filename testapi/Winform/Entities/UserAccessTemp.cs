namespace Winform.Entities
{
    internal class UserAccessTemp
    {
        public string Token { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public List<string> Role { get; set; }
        public Dictionary<string, string> Preferences { get; set; }
        public int RefreshTokenID { get; set; }
        public int RefreshUserID { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshCreated { get; set; }
        public DateTime RefreshExpires { get; set; }
    }
}
