using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Markup;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DotnetMvc.Data;
using DotnetMvc.Models;
using DotnetMvc.ViewModels;

namespace DotnetMvc.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _context;
        
        // Create private field to store mapper object
        private readonly IMapper _mapper;

        // public OrdersController(ApplicationDbContext context)
        // {
        //     _context = context;
        // }

        public OrdersController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {

            return View(await _context.Order.Select(m => new OrderViewModel
            {
                Id = m.Id,
                CreatedAt = m.CreatedAt,
                ExpiryDateTime = m.ExpiryDateTime,
                UpdatedAt = m.UpdatedAt,
                Expired = DateTime.UtcNow > m.ExpiryDateTime,
                Items = null
            }).ToListAsync());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // var order = _context.Order
            //     .Where(m => m.Id == id)
            //     .Select(m => new OrderViewModel
            //     {
            //         Id = m.Id,
            //         CreatedAt = m.CreatedAt,
            //         ExpiryDateTime = m.ExpiryDateTime,
            //         UpdatedAt = m.UpdatedAt,
            //         Expired = DateTime.UtcNow > m.ExpiryDateTime,
            //         Items = m.OrderItems.Select(oi => oi.Item).ToList()
            //     }).First();

            var order = _context.Order.Where(o => o.Id == id)
                .Include(o => o.OrderItems)
                .ThenInclude(orderItem => orderItem.Item)
                .First();
            
            if (order == null)
            {
                return NotFound();  
            }

            var return_order = _mapper.Map<OrderViewModel>(order);

            return View(return_order);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CreatedAt,UpdatedAt,ExpiryDateTime")] Order order)
        {
            if (ModelState.IsValid)
            {
                order.Id = Guid.NewGuid();
                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(order);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        // TODO: Razor view passes in the raw object instead of the actual object in the database
        public async Task<IActionResult> Edit(Guid id)
        {
            var order = await _context.Order.FindAsync(id);
            if (ModelState.IsValid)
            {
                
                try
                {
                    // TODO: Do not update the order item directly, update by taking from the DB first.
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.Id))
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
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var order = await _context.Order.FindAsync(id);
            _context.Order.Remove(order);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(Guid id)
        {
            return _context.Order.Any(e => e.Id == id);
        }
    }
}
