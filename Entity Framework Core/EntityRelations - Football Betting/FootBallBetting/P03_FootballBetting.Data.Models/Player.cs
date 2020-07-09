namespace P03_FootballBetting.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;   

    public class Player
    {
        public Player()
        {
            this.PlayerStatistics = new HashSet<PlayerStatistic>();
        }

        public int PlayerId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public byte SquadNumber { get; set; }
        

        [Required]
        public int TeamId { get; set; }

        [Required]
        public Team Team { get; set; }

        [Required]
        public int PositionId { get; set; }
        
        [Required]
        public Position Position { get; set; }

        [Required]
        public bool IsInjured { get; set; }

        public virtual ICollection<PlayerStatistic> PlayerStatistics { get; set; }
    }
}
