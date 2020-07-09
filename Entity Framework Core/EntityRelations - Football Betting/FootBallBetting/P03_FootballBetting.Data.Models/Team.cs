
//TeamId, Name, LogoUrl, Initials (JUV, LIV, ARS…), Budget, PrimaryKitColorId, SecondaryKitColorId, TownId
namespace P03_FootballBetting.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Team
    {
        public Team()
        {
            this.HomeGames = new HashSet<Game>();
            this.AwayGames = new HashSet<Game>();
            this.Players = new HashSet<Player>();
        }

        public int TeamId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public string LogoUrl { get; set; }

        [Required]
        [StringLength(3, MinimumLength = 3)]
        public string Initials { get; set; }

        [Required]        
        public decimal Budget { get; set; }

        [Required]
        public int PrimaryKitColorId { get; set; }

        [Required]
        public Color PrimaryKitColor { get; set; }

        [Required]
        public int SecondaryKitColorId { get; set; }

        [Required]
        public Color SecondaryKitColor { get; set; }

        [Required]
        public int TownId { get; set; }

        [Required]
        public Town Town { get; set; }

        [Required]
        public ICollection<Game> HomeGames { get; set; }

        [Required]
        public ICollection<Game> AwayGames { get; set; }

        [Required]
        public ICollection<Player> Players { get; set; }
    }
}
