using Arbbet.Domain.Entities;
using Arbbet.Domain.Enums;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Text;

namespace Arbbet.Connectors.Dal
{
  public class ConnectorDbContext : DbContext
  {
    public ConnectorDbContext() : base()
    {
    }

    public ConnectorDbContext(DbContextOptions<ConnectorDbContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseNpgsql("User ID=postgres;Password=postgres;Server=localhost;Port=5432;Database=Arbbet;Integrated Security=true;Pooling=true;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.HasDefaultSchema("Domain");
      
      // Enums
      modelBuilder.Entity<Bet>().Property(elm => elm.BetType).HasConversion(c => c.ToString(), c => (BetType)Enum.Parse(typeof(BetType), c));
      modelBuilder.Entity<Bet>().Property(elm => elm.UnifiedType).HasConversion(c => c.ToString(), c => (UnifiedType)Enum.Parse(typeof(UnifiedType), c));
      modelBuilder.Entity<Competition>().Property(elm => elm.UnifiedType).HasConversion(c => c.ToString(), c => (UnifiedType)Enum.Parse(typeof(UnifiedType), c));
      modelBuilder.Entity<Event>().Property(elm => elm.EventType).HasConversion(c => c.ToString(), c => (EventType)Enum.Parse(typeof(EventType), c));
      modelBuilder.Entity<Event>().Property(elm => elm.UnifiedType).HasConversion(c => c.ToString(), c => (UnifiedType)Enum.Parse(typeof(UnifiedType), c));
      modelBuilder.Entity<Outcome>().Property(elm => elm.OutcomeType).HasConversion(c => c.ToString(), c => (OutcomeType)Enum.Parse(typeof(OutcomeType), c));
      modelBuilder.Entity<Sport>().Property(elm => elm.UnifiedType).HasConversion(c => c.ToString(), c => (UnifiedType)Enum.Parse(typeof(UnifiedType), c));
      modelBuilder.Entity<Team>().Property(elm => elm.TeamType).HasConversion(c => c.ToString(), c => (TeamType)Enum.Parse(typeof(TeamType), c));
      modelBuilder.Entity<Team>().Property(elm => elm.UnifiedType).HasConversion(c => c.ToString(), c => (UnifiedType)Enum.Parse(typeof(UnifiedType), c));

      // Données
      modelBuilder.Entity<Sport>().HasData(Arbbet.Domain.Seeds.Sports.Data);
      modelBuilder.Entity<Platform>().HasData(Arbbet.Domain.Seeds.Platforms.Data);
    }

    public DbSet<Platform> Platforms { get; set; }

    public DbSet<Country> Countries { get; set; }

    public DbSet<Sport> Sports { get; set; }

    public DbSet<Team> Teams { get; set; }

    public DbSet<Competition> Competitions { get; set; }

    public DbSet<Event> Events { get; set; }

    public DbSet<Bet> Bets { get; set; }

    public DbSet<Outcome> Outcomes { get; set; }
  }
}
