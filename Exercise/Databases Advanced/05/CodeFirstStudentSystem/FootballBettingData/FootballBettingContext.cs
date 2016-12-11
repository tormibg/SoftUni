using FootballBettingModels;

namespace FootballBettingData
{
    using System.Data.Entity;

    public class FootballBettingContext : DbContext
    {
        public FootballBettingContext()
            : base("name=FootballBettingContext")
        {
        }

        public IDbSet<Bet> Bets { get; set; }
        public IDbSet<BetGame> BetGames { get; set; }
        public IDbSet<Color> Colors { get; set; }
        public IDbSet<Competition> Competitions { get; set; }
        public IDbSet<CompetitionType> CompetitionTypes { get; set; }
        public IDbSet<Continent> Continents { get; set; }
        public IDbSet<Country> Countries { get; set; }
        public IDbSet<Game> Games { get; set; }
        public IDbSet<Player> Players { get; set; }
        public IDbSet<PlayerStatistic> PlayerStatistics { get; set; }
        public IDbSet<Position> Positions { get; set; }
        public IDbSet<ResultPrediction> ResultPredictions { get; set; }
        public IDbSet<Round> Rounds { get; set; }
        public IDbSet<Team> Teams { get; set; }
        public IDbSet<Town> Towns { get; set; }
        //public IDbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasMany(c => c.Continents).WithMany(c => c.Countries)
                .Map(config =>
                {
                    config.ToTable("CountryContinents");
                    config.MapLeftKey("CountryId");
                    config.MapRightKey("ContinentId");
                });

            modelBuilder.Entity<Country>().HasMany(c => c.Towns).WithOptional(t => t.Country).HasForeignKey(c => c.CountyId);

            modelBuilder.Entity<Town>().HasMany(t => t.Teams).WithOptional(te => te.Town).HasForeignKey(te => te.TownId);

            modelBuilder.Entity<Color>()
                .HasMany(c => c.PrimaryColorTeam)
                .WithRequired(t => t.PrimaryColor)
                .HasForeignKey(t => t.PrimaryKitColor).WillCascadeOnDelete(false);

            modelBuilder.Entity<Color>()
                .HasMany(c => c.SecondaryColorTeam)
                .WithRequired(t => t.SecondaryColor)
                .HasForeignKey(t => t.SecondaryKitColor).WillCascadeOnDelete(false);

            modelBuilder.Entity<Team>().HasMany(t => t.Players).WithOptional(p => p.Team).HasForeignKey(p => p.TeamId).WillCascadeOnDelete(false);

            modelBuilder.Entity<Position>().HasMany(p => p.Players).WithOptional(p => p.Position).HasForeignKey(p => p.PostionId).WillCascadeOnDelete(false);

            modelBuilder.Entity<Team>()
                .HasMany(t => t.Games)
                .WithRequired(g => g.AwayTeam)
                .HasForeignKey(g => g.AwayTeamId).WillCascadeOnDelete(false);

            modelBuilder.Entity<Team>().HasMany(t => t.Games).WithRequired(g => g.HomeTeam).HasForeignKey(g => g.HomeTeamId).WillCascadeOnDelete(false);

            modelBuilder.Entity<Round>().HasMany(r => r.Games).WithRequired(g => g.Round).HasForeignKey(g => g.RoundId).WillCascadeOnDelete(false);

            modelBuilder.Entity<CompetitionType>().HasMany(ct => ct.Competitions).WithRequired(c => c.CompetitionType).HasForeignKey(c => c.CompetitionTypeId).WillCascadeOnDelete(false);

            modelBuilder.Entity<Competition>().HasMany(c => c.Games).WithOptional(g => g.Competition).HasForeignKey(g => g.CompetitionId).WillCascadeOnDelete(false);

            modelBuilder.Entity<PlayerStatistic>().HasKey(p => new { p.GameId, p.PlayerId });

            modelBuilder.Entity<Game>()
                .HasMany(g => g.PlayerStatistics)
                .WithRequired(p => p.Game)
                .HasForeignKey(p => p.GameId).WillCascadeOnDelete(false);

            modelBuilder.Entity<Player>().HasMany(p => p.PlayerStatistics).WithRequired(ps => ps.Player).HasForeignKey(ps => ps.PlayerId).WillCascadeOnDelete(false);

            modelBuilder.Entity<Game>().HasMany(g => g.BetGames).WithRequired(b => b.Game).HasForeignKey(b => b.GameId).WillCascadeOnDelete(false);

            modelBuilder.Entity<ResultPrediction>().HasMany(r => r.BetGames).WithRequired(b => b.ResultPrediction).HasForeignKey(b => b.ResultPredictionId).WillCascadeOnDelete(false);

            modelBuilder.Entity<BetGame>().HasKey(b => new { b.GameId, b.BetId });

            modelBuilder.Entity<Bet>().HasMany(b => b.BetGames).WithRequired(bg => bg.Bet).HasForeignKey(bg => bg.BetId).WillCascadeOnDelete(false);

            modelBuilder.Entity<User>().HasMany(u => u.Bets).WithRequired(b => b.User).HasForeignKey(b => b.UserId).WillCascadeOnDelete(false);
        }
    }

}