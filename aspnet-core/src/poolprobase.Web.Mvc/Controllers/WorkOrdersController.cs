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

namespace poolprobase.Web.Mvc.Controllers
{
    public class WorkOrdersController : poolprobaseControllerBase
    {
        private readonly CustomerContext _context;

        public WorkOrdersController(CustomerContext context)
        {
            _context = context;
        }

        // GET: WorkOrders
        public async Task<IActionResult> Index()
        {
            var customerContext = _context.WorkOrders.Include(w => w.WO_Customer).Include(w => w.WO_ServiceTech);
            return View(await customerContext.ToListAsync());
        }

        // GET: WorkOrders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var workOrder = await _context.WorkOrders
                .Include(w => w.WO_Customer)
                .Include(w => w.WO_ServiceTech)
                .Include(w => w.WO_LineItems)
                .SingleOrDefaultAsync(m => m.WorkOrderID == id);
            if (workOrder == null)
            {
                return NotFound();
            }
            return View(workOrder);
        }

        // GET: WorkOrders/Create
        public IActionResult Create()
        {
            ViewData["CustomerID"] = new SelectList(_context.Customers, "CustomerID", "CustomerID");
            ViewData["ServiceTechID"] = new SelectList(_context.ServiceTechs, "ServiceTechID", "ServiceTechID");
            return View();
        }

        public IActionResult Create(int Id)
        {
            ViewData["CustomerID"] = Id;
            ViewData["ServiceTechID"] = new SelectList(_context.ServiceTechs, "ServiceTechID", "ServiceTechID");
            return View();
        }
        // POST: WorkOrders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WorkOrderID,CustomerID,ServiceTechID")] WorkOrder workOrder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workOrder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerID"] = new SelectList(_context.Customers, "CustomerID", "CustomerID", workOrder.CustomerID);
            ViewData["ServiceTechID"] = new SelectList(_context.ServiceTechs, "ServiceTechID", "ServiceTechID", workOrder.ServiceTechID);
            return View(workOrder);
        }

        // GET: WorkOrders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workOrder = await _context.WorkOrders.SingleOrDefaultAsync(m => m.WorkOrderID == id);
            if (workOrder == null)
            {
                return NotFound();
            }
            ViewData["CustomerID"] = new SelectList(_context.Customers, "CustomerID", "CustomerID", workOrder.CustomerID);
            ViewData["ServiceTechID"] = new SelectList(_context.ServiceTechs, "ServiceTechID", "ServiceTechID", workOrder.ServiceTechID);
            return View(workOrder);
        }

        // POST: WorkOrders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WorkOrderID,CustomerID,ServiceTechID")] WorkOrder workOrder)
        {
            if (id != workOrder.WorkOrderID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workOrder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkOrderExists(workOrder.WorkOrderID))
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
            ViewData["CustomerID"] = new SelectList(_context.Customers, "CustomerID", "CustomerID", workOrder.CustomerID);
            ViewData["ServiceTechID"] = new SelectList(_context.ServiceTechs, "ServiceTechID", "ServiceTechID", workOrder.ServiceTechID);
            return View(workOrder);
        }

        // GET: WorkOrders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workOrder = await _context.WorkOrders
                .Include(w => w.WO_Customer)
                .Include(w => w.WO_ServiceTech)
                .SingleOrDefaultAsync(m => m.WorkOrderID == id);
            if (workOrder == null)
            {
                return NotFound();
            }

            return View(workOrder);
        }

        // POST: WorkOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var workOrder = await _context.WorkOrders.SingleOrDefaultAsync(m => m.WorkOrderID == id);
            _context.WorkOrders.Remove(workOrder);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // the modal / popup for editing a work order

        public async Task<ActionResult> EditWordOrderModal(int id)
        {
            var workorder = await _context.WorkOrders.SingleOrDefaultAsync(w => w.WorkOrderID == id);
            if(workorder == null)
            {
                return NotFound();
            }

            return View("_EditWorkOrderModal", workorder);
        }

        private bool WorkOrderExists(int id)
        {
            return _context.WorkOrders.Any(e => e.WorkOrderID == id);
        }

        public async Task<ActionResult> CreateWorkOrdersModal(int id)
        {
            var workOrder = await _context.WorkOrders.SingleOrDefaultAsync(m => m.CustomerID == id);
            if(workOrder == null)
            {
                return NotFound();
            }
            return View("_CreateWorkOrdersModal", workOrder);
        }
    }
}
