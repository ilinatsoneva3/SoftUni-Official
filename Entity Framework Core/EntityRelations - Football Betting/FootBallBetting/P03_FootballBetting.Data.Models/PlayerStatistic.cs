namespace P03_FootballBetting.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    public class PlayerStatistic
    {      

        //TODO: implement PK later for player statistics
        [Required]
        public int GameId { get; set; }
        public Game Game { get; set; }

        [Required]
        public int PlayerId { get; set; }
        [Required]
        public Player Player { get; set; }

        public int ScoredGoals { get; set; }

        public int Assists { get; set; }

        public int MinutesPlayed { get; set; }       
    }
}
