using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Parcelxpress.Data;
using Parcelxpress.Models;

namespace Parcelxpress.Controllers
{
    public class RoutesController : Controller
    {
        private readonly LoadContext _context;

        public RoutesController(LoadContext context)
        {
            _context = context;
        }

        // GET: Routes
        public async Task<IActionResult> Index(string sortOrder)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            var routes = from r in _context.Routes.Include(r => r.Area).Include(r => r.Car).Include(r => r.Driver)
            select r;
            switch (sortOrder)
            {
                case "Date":
                    routes = routes.OrderBy(r => r.RouteDate);
                    break;
                default:
                    routes = routes.OrderBy(r => r.Driver);
                    break;
            }

            //routes = _context.Routes.Include(r => r.Area).Include(r => r.Car).Include(r => r.Driver);
            return View(await routes.AsNoTracking().ToListAsync());
        }

        // GET: Routes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var route = await _context.Routes
                .Include(r => r.Area)
                .Include(r => r.Car)
                .Include(r => r.Driver)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (route == null)
            {
                return NotFound();
            }

            return View(route);
        }

        // GET: Routes/Create
        public IActionResult Create()
        {
            ViewData["AreaID"] = new SelectList(_context.Areas, "ID", "PostNumber");
            ViewData["CarID"] = new SelectList(_context.Cars, "ID", "RegNumber");
            ViewData["DriverID"] = new SelectList(_context.Drivers, "ID", "ID");
            return View();
        }

        // POST: Routes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RouteDate,DriverID,CarID,AreaID")] Route route)
        {
            try
            {
                if (ModelState.IsValid)
                {
                _context.Add(route);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }
            ViewData["AreaID"] = new SelectList(_context.Areas, "ID", "ID", route.AreaID);
            ViewData["CarID"] = new SelectList(_context.Cars, "ID", "ID", route.CarID);
            ViewData["DriverID"] = new SelectList(_context.Drivers, "ID", "ID", route.DriverID);
            return View(route);
        }

        // GET: Routes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var route = await _context.Routes.FindAsync(id);
            if (route == null)
            {
                return NotFound();
            }
            ViewData["AreaID"] = new SelectList(_context.Areas, "ID", "PostNumber", route.AreaID);
            ViewData["CarID"] = new SelectList(_context.Cars, "ID", "RegNumber", route.CarID);
            ViewData["DriverID"] = new SelectList(_context.Drivers, "ID", "ID", route.DriverID);
            return View(route);
        }

        // POST: Routes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var routeToUpdate = await _context.Routes.FirstOrDefaultAsync(s => s.ID == id);
            if (await TryUpdateModelAsync<Route>(
                routeToUpdate,
                "",
                s => s.DriverID, s => s.CarID, s => s.AreaID, s => s.RouteDate))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException /* ex */)
                {
                    //Log the error (uncomment ex variable name and write a log.)
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists, " +
                        "see your system administrator.");
                }
            }
            return View(routeToUpdate);
        }

        // GET: Routes/Delete/5
        public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var route = await _context.Routes
                .AsNoTracking()
                .Include(r => r.Area)
                .Include(r => r.Car)
                .Include(r => r.Driver)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (route == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] =
                    "Delete failed. Try again, and if the problem persists " +
                    "see your system administrator.";
            }

            return View(route);
        }

        // POST: Routes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var route = await _context.Routes.FindAsync(id);
            _context.Routes.Remove(route);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RouteExists(int id)
        {
            return _context.Routes.Any(e => e.ID == id);
        }
    }
}
