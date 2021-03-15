using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;

namespace Arbbet.Connectors.Dal.Services
{
  public class ConvergenceService
  {
    private readonly ILogger<ConvergenceService> _logger;
    private readonly ConnectorDbContext _context;

    public ConvergenceService(ILogger<ConvergenceService> logger,
      ConnectorDbContext context)
    {
      _logger = logger;
      _context = context;
    }

    public void CreateOrGetEvent()
    {

    }
  }
}
