
//BetId, Amount, Prediction, DateTime, UserId, GameId
namespace P03_FootballBetting.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Bet
    {
        public int BetId { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public string Prediction { get; set; }

        public DateTime DateTime { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public User User { get; set; }

        [Required]
        public int GameId { get; set; }

        [Required]
        public Game Game { get; set; }
    }
}
