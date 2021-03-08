using Arbbet.Connectors.Dal;
using Arbbet.DataExplorer.Models.Platform;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arbbet.DataExplorer.Controllers
{
    public class PlatformController : BaseController<PlatformController>
    {
        public PlatformController(ILogger<PlatformController> logger, ConnectorDbContext context) : base(logger, context)
        {
        }

        // GET: PlatformController
        public ActionResult Index()
        {
            var platforms = _context.Platforms.ToList();

            return View(platforms);
        }

        // GET: PlatformController/Details/5
        public ActionResult Details(Guid id)
        {
            var platform = _context.Platforms.FirstOrDefault(elm => elm.Id == id);

            PlatformViewModel vm = new PlatformViewModel()
            {
                Id = platform.Id,
                Code = platform.Code,
                Name = platform.Name,
                NbOfSports = _context.Sports.Count(elm => elm.PlatformId == platform.Id),
                NbOfCompetitions = _context.Competitions.Count(elm => elm.PlatformId == platform.Id),
                NbOfEvents = _context.Events.Count(elm => elm.PlatformId == platform.Id),
                NbOfBets = _context.Bets.Count(elm => elm.PlatformId == platform.Id),
                NbOfOutcomes = _context.Outcomes.Count(elm => elm.Bet.PlatformId == platform.Id)
            };

            return View(vm);
        }

        // GET: PlatformController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PlatformController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PlatformController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PlatformController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PlatformController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PlatformController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
