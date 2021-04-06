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
    private readonly BetService _betService;
    private readonly CountryService _countryService;

    public ConvergenceService(ILogger<ConvergenceService> logger,
      CountryService countryService,
      BetService betService)
    {
      _logger = logger;
      _countryService = countryService;
      _betService = betService;
    }

    public void CreateOrGetEvent()
    {

    }
  }
}
