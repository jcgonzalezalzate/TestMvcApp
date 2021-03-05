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
    public class TeacherController : Controller
    {
        private readonly TestMvcAppContext _context;

        public TeacherController(TestMvcAppContext context)
        {
            _context = context;
        }

        // GET: Teacher
        public async Task<IActionResult> Index()
        {
            return View(await _context.TeacherViewModel.ToListAsync());
        }

        // GET: Teacher/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacherViewModel = await _context.TeacherViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (teacherViewModel == null)
            {
                return NotFound();
            }

            return View(teacherViewModel);
        }

        // GET: Teacher/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Teacher/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,BirthDate")] TeacherViewModel teacherViewModel)
        {
            if (ModelState.IsValid)
            {
                teacherViewModel.Age = DateTime.Now.Year - teacherViewModel.BirthDate.Year;
                _context.Add(teacherViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(teacherViewModel);
        }

        // GET: Teacher/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacherViewModel = await _context.TeacherViewModel.FindAsync(id);
            if (teacherViewModel == null)
            {
                return NotFound();
            }

            if (teacherViewModel.Age.HasValue)
            {
                teacherViewModel.BirthDate = DateTime.Now.AddYears(teacherViewModel.Age.Value * -1);
            }

            return View(teacherViewModel);
        }

        // POST: Teacher/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,BirthDate")] TeacherViewModel teacherViewModel)
        {
            if (id != teacherViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    teacherViewModel.Age = DateTime.Now.Year - teacherViewModel.BirthDate.Year;
                    _context.Update(teacherViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeacherViewModelExists(teacherViewModel.Id))
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
            return View(teacherViewModel);
        }

        // GET: Teacher/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacherViewModel = await _context.TeacherViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (teacherViewModel == null)
            {
                return NotFound();
            }

            return View(teacherViewModel);
        }

        // POST: Teacher/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var teacherViewModel = await _context.TeacherViewModel.FindAsync(id);
            _context.TeacherViewModel.Remove(teacherViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeacherViewModelExists(int id)
        {
            return _context.TeacherViewModel.Any(e => e.Id == id);
        }
    }
}
