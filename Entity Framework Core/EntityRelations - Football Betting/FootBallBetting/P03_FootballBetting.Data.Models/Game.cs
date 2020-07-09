namespace P03_FootballBetting.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Game
    {
        public Game()
        {
            this.PlayerStatistics = new HashSet<PlayerStatistic>();
            this.Bets = new HashSet<Bet>();
        }

        public int GameId { get; set; }
       
        [Required]
        public int HomeTeamId { get; set; }

        [Required]
        public Team HomeTeam { get; set; }

        [Required]
        public int AwayTeamId { get; set; }

        [Required]
        public Team AwayTeam { get; set; }

        public int HomeTeamGoals { get; set; }

        public int AwayTeamGoals { get; set; }

        public DateTime DateTime { get; set; }

        public double HomeTeamBetRate { get; set; }

        public double AwayTeamBetRate { get; set; }

        public double DrawBetRate { get; set; }

        public string Result { get; set; }

        public virtual ICollection<PlayerStatistic> PlayerStatistics { get; set; }

        public virtual ICollection<Bet> Bets { get; set; }
    }
}
