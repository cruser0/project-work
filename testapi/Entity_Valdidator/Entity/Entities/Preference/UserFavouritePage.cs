namespace Entity_Validator.Entity.Entities.Preference
{
    public class UserFavouritePage
    {
        public int? UserID { get; set; }
        public int? FavouritePageID { get; set; }
        public virtual FavouritePages FavouritePage { get; set; }
        public virtual User User { get; set; }
    }
}
