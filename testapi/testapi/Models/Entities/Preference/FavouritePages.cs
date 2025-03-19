namespace API.Models.Entities.Preference
{
    public class FavouritePages
    {
        public FavouritePages()
        {
            UserFavourtitePages = new HashSet<UserFavouritePage>();
        }
        public int? FavouritePageID { get; set; }
        public string? Name { get; set; }
        public virtual ICollection<UserFavouritePage> UserFavourtitePages { get; set; }
    }
}
