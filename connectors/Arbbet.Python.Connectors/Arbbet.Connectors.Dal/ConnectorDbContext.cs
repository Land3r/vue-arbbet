﻿using Arbbet.Connectors.Domain.Bets;
using Arbbet.Connectors.Domain.Competitions;
using Arbbet.Connectors.Domain.Countries;
using Arbbet.Connectors.Domain.Events;
using Arbbet.Connectors.Domain.Outcomes;
using Arbbet.Connectors.Domain.Platforms;
using Arbbet.Connectors.Domain.Sports;
using Arbbet.Connectors.Domain.Teams;

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

      // Enums
      modelBuilder.Entity<Team>().Property(elm => elm.TeamType).HasConversion(c => c.ToString(), c => (TeamType)Enum.Parse(typeof(TeamType), c));
      modelBuilder.Entity<Bet>().Property(elm => elm.BetType).HasConversion(c => c.ToString(), c => (BetType)Enum.Parse(typeof(BetType), c));

      // Données
      modelBuilder.Entity<Sport>().HasData(Sport_Seed.Data);
      modelBuilder.Entity<Platform>().HasData(Platform_Seed.Data);
    }

    public DbSet<Platform> Platforms { get; set; }

    public DbSet<Country> Countries { get; set; }

    public DbSet<Sport> Sports { get; set; }

    public DbSet<Team> Teams { get; set; }

    public DbSet<Competition> Competitions { get; set; }

    public DbSet<Event> Events { get; set; }

    public DbSet<Outcome> Outcomes { get; set; }
  }
}
