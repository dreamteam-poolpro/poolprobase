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
        // lineitems/index
        public async Task<IActionResult> Index()
        {
            return View(await _context.LineItems.ToListAsync());
        }

        // GET: LineItems/Details/5
        //lineitems/details/workorderid
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
        //lineitems/create - loads the lineitems create page, doesn't actually create a line item
        public IActionResult Create()
        {
            return View();
        }

        //line items create modal - loads the line items modal/popup
        public async Task<ActionResult> CreateLineItemsModal(int workOrderId)
        {
            var workOrder = await _context.WorkOrders.SingleOrDefaultAsync(m => m.WorkOrderID == workOrderId);
            return View("_CreateLineItemsModal", workOrder);
        }

        // POST: LineItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        // called from lineitems/create to actually create a line item from the data being passed in
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
        // lineitems/edit/lineitemid
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
        // lineitems/delete - just displays the delete view, doesn't actually delete a line item
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
        //called from the line items page to actually delete the line item
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
