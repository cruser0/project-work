using System.ComponentModel.DataAnnotations;

namespace API.Models.Entities
{
    public class Preference
    {
        [Key]
        public int PreferenceID { get; set; }

        [Required]
        [MaxLength(50)]
        public string PreferenceName { get; set; }

        public virtual ICollection<UserPreference> UserPreferences { get; set; } = new List<UserPreference>();
    }
}
