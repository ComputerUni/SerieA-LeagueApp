using Microsoft.EntityFrameworkCore;
using SerieA.API.Entities;

namespace SerieA.API.Context
{
    public class ApiContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-213H3J8\\SQLEXPRESS;Database=SerieADb;Integrated Security=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Match>()
                .HasOne(m => m.HomeTeam)
                .WithMany(t => t.HomeMatches)
                .HasForeignKey(m => m.HomeTeamId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Match>()
                .HasOne(m => m.AwayTeam)
                .WithMany(t => t.AwayMatches)
                .HasForeignKey(m => m.AwayTeamId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<MatchGoal>()
                .HasOne(m => m.Team)
                .WithMany(t => t.MatchGoals)
                .HasForeignKey(m => m.TeamId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<MatchCard>()
                .HasOne(m => m.Team)
                .WithMany(t => t.MatchCards)
                .HasForeignKey(m => m.TeamId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Substitution>()
                .HasOne(m => m.Team)
                .WithMany(t => t.Substitutions)
                .HasForeignKey(m => m.TeamId)
                .OnDelete(DeleteBehavior.Restrict);



        }

        public DbSet<Match> Matches { get; set; }
        public DbSet<MatchCard> MatchCards { get; set; }
        public DbSet<MatchGoal> MatchGoals { get; set; }
        public DbSet<Substitution> Substitutions { get; set; }
        public DbSet<Team> Teams { get; set; }


    }
}
