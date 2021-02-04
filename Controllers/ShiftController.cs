using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchedulingTool.Data;
using SchedulingTool.Models;

namespace SchedulingTool.Controllers
{
    public class ShiftController : Controller
    {
        private readonly ScheduleContext _context;

        public ShiftController(ScheduleContext context)
        {
            _context = context;
        }

        public async Task<List<Object>> getTodosEmployees()
        {
            List<Object> viewbags = new List<Object>();
            viewbags.Add(ViewBag.Employees = await _context.Employees.ToListAsync());
            viewbags.Add(ViewBag.Todos = await _context.Todos.ToListAsync());
            return viewbags;
        }

        // GET: Shift
        public async Task<IActionResult> Index()
        {
            return View(await _context.Shifts.ToListAsync());
        }

        // GET: Shift/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shift = await _context.Shifts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shift == null)
            {
                return NotFound();
            }

            return View(shift);
        }
        // GET: Shift/Create
        public async Task<IActionResult> Create()
        {
            await getTodosEmployees();
            return View();
        }

        // POST: Shift/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Shift shift, List<int> todoIds)
        {
            if (ModelState.IsValid)
            {
                var employee = await _context.Employees.FirstOrDefaultAsync(e => e.Id == shift.EmployeeId);
                var todos = await _context.Todos.Where(x => todoIds.Contains(x.Id)).ToListAsync();
                shift.ShiftTodos = new List<ShiftTodo>();
                for (int i = 0; i < todos.Count; i++)
                {
                    if (employee.getAge() < todos[i].RequiredAge)
                    {
                        await getTodosEmployees();
                        ViewBag.AgeError = "Medarbejderen er ikke gammel nok til den valgte opgave";
                        return View(shift);
                    }
                    shift.ShiftTodos.Add( new ShiftTodo { Shift = shift,  Todo = todos[i] });
                }
                _context.Add(shift);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(shift);
        }

        // GET: Shift/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shift = await _context.Shifts.FindAsync(id);
            if (shift == null)
            {
                return NotFound();
            }
            await getTodosEmployees();
            return View(shift);
        }

        // POST: Shift/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Shift shift, List<int> todoIds)
        {
            if (id != shift.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await Create(shift, todoIds);
                    var oldShift = await _context.Shifts.FirstOrDefaultAsync(s => s.Id == id);
                    _context.Shifts.Remove(oldShift);
                    await _context.SaveChangesAsync();
                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShiftExists(shift.Id))
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
            await getTodosEmployees();
            return View(shift);
        }

        // GET: Shift/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shift = await _context.Shifts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shift == null)
            {
                return NotFound();
            }

            return View(shift);
        }

        // POST: Shift/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shift = await _context.Shifts.FindAsync(id);
            _context.Shifts.Remove(shift);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShiftExists(int id)
        {
            return _context.Shifts.Any(e => e.Id == id);
        }
    }
}
