using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Arbbet.DataExplorer.Identity.Models;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Arbbet.DataExplorer.Identity.Dal
{
  public class ArbbetIdentityDbContext : IdentityDbContext<ArbbetUser, ArbbetRole, string>
  {
    public ArbbetIdentityDbContext(DbContextOptions<ArbbetIdentityDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.HasDefaultSchema("Domain");
    }
  }
}
