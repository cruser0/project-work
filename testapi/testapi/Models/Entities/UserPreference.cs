namespace API.Models.Entities
{
    public class UserPreference
    {

        public int UserID { get; set; }
        public int PreferenceID { get; set; }
        public string Value { get; set; }


        public virtual User? User { get; set; }
        public virtual Preference? Preference { get; set; }
    }
}
