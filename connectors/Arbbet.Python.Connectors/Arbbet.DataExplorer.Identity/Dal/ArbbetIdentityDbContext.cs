using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Design;

using Arbbet.DataExplorer.Identity.Models;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Arbbet.DataExplorer.Identity.Dal
{
  public class ArbbetIdentityDbContext : IdentityDbContext<ArbbetUser, ArbbetRole, string>
  {
    public ArbbetIdentityDbContext() : base()
    {
    }

    public ArbbetIdentityDbContext(DbContextOptions<ArbbetIdentityDbContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseNpgsql("User ID=postgres;Password=postgres;Server=localhost;Port=5432;Database=Arbbet;Integrated Security=true;Pooling=true;",
        optionsBuilder => optionsBuilder.MigrationsHistoryTable("__EFMigrationsHistory", "Identity"));

      optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTrackingWithIdentityResolution);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.HasDefaultSchema("Identity");
    }
  }
}
