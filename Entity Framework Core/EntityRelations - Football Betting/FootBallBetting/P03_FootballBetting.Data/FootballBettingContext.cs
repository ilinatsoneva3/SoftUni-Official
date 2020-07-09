namespace P03_FootballBetting.Data
{
    using Microsoft.EntityFrameworkCore;
    using P03_FootballBetting.Data.Models;
    using System;

    public class FootballBettingContext : DbContext
    {
        public FootballBettingContext()
        {

        }

        public FootballBettingContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Bet> Bets { get; set; }

        public DbSet<Color> Colors { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Game> Games { get; set; }

        public DbSet<Player> Players { get; set; }

        public DbSet<PlayerStatistic> PlayerStatistics { get; set; }

        public DbSet<Position> Positions { get; set; }

        public DbSet<Team> Teams { get; set; }

        public DbSet<Town> Towns { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.Connection);
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>(entity =>
            {
                entity
                    .HasOne(t => t.PrimaryKitColor)
                    .WithMany(c => c.PrimaryKitTeams)
                    .HasForeignKey(t => t.PrimaryKitColorId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity
                    .HasOne(t => t.SecondaryKitColor)
                    .WithMany(c => c.SecondaryKitTeams)
                    .OnDelete(DeleteBehavior.Restrict);

                entity
                    .HasOne(t => t.Town)
                    .WithMany(t => t.Teams)
                    .HasForeignKey(t => t.TownId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity
                    .Property(t => t.LogoUrl)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Town>(entity =>
            {
                entity
                    .HasOne(t => t.Country)
                    .WithMany(c => c.Towns)
                    .HasForeignKey(t => t.CountryId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Game>(entity =>
            {
                entity
                    .HasOne(g => g.HomeTeam)
                    .WithMany(ht => ht.HomeGames)
                    .HasForeignKey(g => g.HomeTeamId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity
                    .HasOne(g => g.AwayTeam)
                    .WithMany(at => at.AwayGames)
                    .HasForeignKey(g => g.AwayTeamId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity
                    .HasOne(p => p.Team)
                    .WithMany(t => t.Players)
                    .HasForeignKey(p => p.TeamId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity
                    .HasOne(p => p.Position)
                    .WithMany(p => p.Players)
                    .HasForeignKey(p => p.PositionId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Bet>(entity =>
            {
                entity
                    .HasOne(b => b.Game)
                    .WithMany(g => g.Bets)
                    .HasForeignKey(b => b.GameId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity
                    .HasOne(b => b.User)
                    .WithMany(u => u.Bets)
                    .HasForeignKey(b => b.UserId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<PlayerStatistic>(entity =>
            {
                entity
                    .HasKey(ps => new { ps.GameId, ps.PlayerId });

                entity
                    .HasOne(ps => ps.Player)
                    .WithMany(ps => ps.PlayerStatistics)
                    .HasForeignKey(ps => ps.PlayerId);

                entity
                    .HasOne(ps => ps.Game)
                    .WithMany(ps => ps.PlayerStatistics)
                    .HasForeignKey(ps => ps.GameId);

            });          
        }
    }
}
