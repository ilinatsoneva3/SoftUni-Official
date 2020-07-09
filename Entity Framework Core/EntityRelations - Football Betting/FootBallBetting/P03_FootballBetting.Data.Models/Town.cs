namespace P03_FootballBetting.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Town
    {
        public Town()
        {
            this.Teams = new HashSet<Team>();
        }

        public int TownId { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        public int CountryId { get; set; }

        [Required]
        public Country Country { get; set; }

        public virtual ICollection<Team> Teams { get; set; }
    }
}
