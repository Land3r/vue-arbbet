using Arbbet.Connectors.Dal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arbbet.DataExplorer.Controllers
{
    public abstract class BaseController<TController> : Controller
    {
        protected readonly ILogger<TController> _logger;
        protected readonly ConnectorDbContext _context;

        public BaseController(ILogger<TController> logger,
            ConnectorDbContext context)
        {
            _logger = logger;
            _context = context;
        }
    }
}
