using Arbbet.Connectors.Domain.Platforms;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arbbet.Connectors.Dal
{
    public class ConnectorDbContext : DbContext
    {
        public DbSet<Platform> Platforms { get; set; }

    }
}
