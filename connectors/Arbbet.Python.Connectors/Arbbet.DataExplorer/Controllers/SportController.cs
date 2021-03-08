using Arbbet.Connectors.Dal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arbbet.DataExplorer.Controllers
{
    public class SportController : BaseController<SportController>
    {
        public SportController(ILogger<SportController> logger, ConnectorDbContext context) : base(logger, context)
        {
        }

        // GET: SportController
        public ActionResult Index()
        {
            var sports = _context.Sports.ToList();

            return View(sports);
        }

        // GET: SportController/Details/5
        public ActionResult Details(Guid id)
        {
            var sport = _context.Sports.FirstOrDefault(elm => elm.Id == id);
            
            return View(sport);
        }

        // GET: SportController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SportController/Create
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

        // GET: SportController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SportController/Edit/5
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

        // GET: SportController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SportController/Delete/5
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
