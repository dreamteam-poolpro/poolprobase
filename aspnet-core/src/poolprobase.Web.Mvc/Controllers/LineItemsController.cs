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
    [AbpMvcAuthorize(PermissionNames.Pages_WorkOrders)]
    public class LineItemsController : poolprobaseControllerBase
    {
        private readonly CustomerContext _context;

        public LineItemsController(CustomerContext context)
        {
            _context = context;
        }

        // GET: LineItems
        public async Task<IActionResult> Index()
        {
            return View(await _context.LineItems.ToListAsync());
        }

        // GET: LineItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lineItem = await _context.LineItems
                .SingleOrDefaultAsync(m => m.LineItemID == id);
            if (lineItem == null)
            {
                return NotFound();
            }

            return View(lineItem);
        }

        // GET: LineItems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LineItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LineItemID,WordOrderID,Description,Units,UnitCost,Quantity")] LineItem lineItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lineItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lineItem);
        }

        // GET: LineItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lineItem = await _context.LineItems.SingleOrDefaultAsync(m => m.LineItemID == id);
            if (lineItem == null)
            {
                return NotFound();
            }
            return View(lineItem);
        }

        // POST: LineItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LineItemID,WordOrderID,Description,Units,UnitCost,Quantity")] LineItem lineItem)
        {
            if (id != lineItem.LineItemID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lineItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LineItemExists(lineItem.LineItemID))
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
            return View(lineItem);
        }

        // GET: LineItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lineItem = await _context.LineItems
                .SingleOrDefaultAsync(m => m.LineItemID == id);
            if (lineItem == null)
            {
                return NotFound();
            }

            return View(lineItem);
        }

        // POST: LineItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lineItem = await _context.LineItems.SingleOrDefaultAsync(m => m.LineItemID == id);
            _context.LineItems.Remove(lineItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LineItemExists(int id)
        {
            return _context.LineItems.Any(e => e.LineItemID == id);
        }
    }
}
