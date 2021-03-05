using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestMvcApp.Data;
using TestMvcApp.Models;

namespace TestMvcApp.Controllers
{
    public class StudentsController : Controller
    {
        private readonly TestMvcAppContext _context;

        public StudentsController(TestMvcAppContext context)
        {
            _context = context;
        }

        // GET: Students
        public async Task<IActionResult> Index()
        {
            return View(await _context.StudentsViewModel.ToListAsync());
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentsViewModel = await _context.StudentsViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studentsViewModel == null)
            {
                return NotFound();
            }

            return View(studentsViewModel);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] StudentsViewModel studentsViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentsViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(studentsViewModel);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentsViewModel = await _context.StudentsViewModel.FindAsync(id);
            if (studentsViewModel == null)
            {
                return NotFound();
            }
            return View(studentsViewModel);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] StudentsViewModel studentsViewModel)
        {
            if (id != studentsViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentsViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentsViewModelExists(studentsViewModel.Id))
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
            return View(studentsViewModel);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentsViewModel = await _context.StudentsViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studentsViewModel == null)
            {
                return NotFound();
            }

            return View(studentsViewModel);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studentsViewModel = await _context.StudentsViewModel.FindAsync(id);
            _context.StudentsViewModel.Remove(studentsViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentsViewModelExists(int id)
        {
            return _context.StudentsViewModel.Any(e => e.Id == id);
        }
    }
}
