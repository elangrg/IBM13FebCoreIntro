using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IBM13FebCoreIntro.Models;

namespace IBM13FebCoreIntro.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly Ibm25jan24DbContext _context;

        public EmployeeController(Ibm25jan24DbContext context)
        {
            _context = context;
        }

        // GET: Employee
        public async Task<IActionResult> Index()
        {
              return _context.EmployeeDepts != null ? 
                          View(await _context.EmployeeDepts.ToListAsync()) :
                          Problem("Entity set 'Ibm25jan24DbContext.EmployeeDepts'  is null.");
        }

        // GET: Employee/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EmployeeDepts == null)
            {
                return NotFound();
            }

            var employeeDept = await _context.EmployeeDepts
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (employeeDept == null)
            {
                return NotFound();
            }

            return View(employeeDept);
        }

        // GET: Employee/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeId,EmpName,Salary,DeptName")] EmployeeDept employeeDept)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeeDept);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employeeDept);
        }

        // GET: Employee/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EmployeeDepts == null)
            {
                return NotFound();
            }

            var employeeDept = await _context.EmployeeDepts.FindAsync(id);
            if (employeeDept == null)
            {
                return NotFound();
            }
            return View(employeeDept);
        }

        // POST: Employee/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeId,EmpName,Salary,DeptName")] EmployeeDept employeeDept)
        {
            if (id != employeeDept.EmployeeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeDept);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeDeptExists(employeeDept.EmployeeId))
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
            return View(employeeDept);
        }

        // GET: Employee/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EmployeeDepts == null)
            {
                return NotFound();
            }

            var employeeDept = await _context.EmployeeDepts
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (employeeDept == null)
            {
                return NotFound();
            }

            return View(employeeDept);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EmployeeDepts == null)
            {
                return Problem("Entity set 'Ibm25jan24DbContext.EmployeeDepts'  is null.");
            }
            var employeeDept = await _context.EmployeeDepts.FindAsync(id);
            if (employeeDept != null)
            {
                _context.EmployeeDepts.Remove(employeeDept);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeDeptExists(int id)
        {
          return (_context.EmployeeDepts?.Any(e => e.EmployeeId == id)).GetValueOrDefault();
        }
    }
}
