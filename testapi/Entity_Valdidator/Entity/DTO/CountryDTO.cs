namespace Entity_Validator.Entity.DTO
{
    public class CountryDTO
    {
        public string CountryName { get; set; }
        public string ISOCountry { get; set; }
    }
    public class CountryDTOGet:CountryDTO
    {
        public int CountryID { get; set; }
    }
}
