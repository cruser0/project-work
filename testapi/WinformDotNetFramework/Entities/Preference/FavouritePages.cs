using System.Collections.Generic;

namespace WinformDotNetFramework.Entities.Preference
{
    public class FavouritePages
    {
        public int FavouritePageID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<UserFavouritePage> UserFavourtitePages { get; set; }
    }
}
