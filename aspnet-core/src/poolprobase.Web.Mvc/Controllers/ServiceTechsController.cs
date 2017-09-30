using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using poolprobase.Web.Data;
using poolprobase.Web.Models.Customer;
using poolprobase.Controllers;
using Abp.AspNetCore.Mvc.Authorization;
using poolprobase.Authorization;

namespace poolprobase.Web.Mvc.Controllers
{

    [AbpMvcAuthorize(PermissionNames.Pages_Users)]
    public class ServiceTechsController : poolprobaseControllerBase
    {
        private readonly CustomerContext _context;

        public ServiceTechsController(CustomerContext context)
        {
            _context = context;
        }

        // GET: ServiceTechs
        public async Task<IActionResult> Index()
        {
            return View(await _context.ServiceTechs.ToListAsync());
        }

        // GET: ServiceTechs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceTech = await _context.ServiceTechs
                .SingleOrDefaultAsync(m => m.ServiceTechID == id);
            if (serviceTech == null)
            {
                return NotFound();
            }

            return View(serviceTech);
        }

        // GET: ServiceTechs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ServiceTechs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ServiceTechID,FirstName,LastName")] ServiceTech serviceTech)
        {
            if (ModelState.IsValid)
            {
                _context.Add(serviceTech);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(serviceTech);
        }

        // GET: ServiceTechs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceTech = await _context.ServiceTechs.SingleOrDefaultAsync(m => m.ServiceTechID == id);
            if (serviceTech == null)
            {
                return NotFound();
            }
            return View(serviceTech);
        }

        // POST: ServiceTechs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ServiceTechID,FirstName,LastName")] ServiceTech serviceTech)
        {
            if (id != serviceTech.ServiceTechID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(serviceTech);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServiceTechExists(serviceTech.ServiceTechID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(serviceTech);
        }

        // GET: ServiceTechs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceTech = await _context.ServiceTechs
                .SingleOrDefaultAsync(m => m.ServiceTechID == id);
            if (serviceTech == null)
            {
                return NotFound();
            }

            return View(serviceTech);
        }

        // POST: ServiceTechs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var serviceTech = await _context.ServiceTechs.SingleOrDefaultAsync(m => m.ServiceTechID == id);
            _context.ServiceTechs.Remove(serviceTech);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServiceTechExists(int id)
        {
            return _context.ServiceTechs.Any(e => e.ServiceTechID == id);
        }

        public async Task<ActionResult> EditTechModal(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceTech = await _context.ServiceTechs
                .SingleOrDefaultAsync(m => m.ServiceTechID == id);
            if (serviceTech == null)
            {
                return NotFound();
            }

            return View("_EditTechModal", serviceTech);
        }
    }
}
