using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Student.DAL;
using Student.Models;

namespace Student.Controllers
{
    public class StudentsViewModelsController : Controller
    {
        private readonly StudentsDbContext _context;

        public StudentsViewModelsController(StudentsDbContext context)
        {
            _context = context;
        }

        // GET: StudentsViewModels
        public async Task<IActionResult> Index()
        {
              return _context.StudentsViewModel != null ? 
                          View(await _context.StudentsViewModel.ToListAsync()) :
                          Problem("Entity set 'StudentsDbContext.StudentsViewModel'  is null.");
        }

        // GET: StudentsViewModels/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.StudentsViewModel == null)
            {
                return NotFound();
            }

            var studentsViewModel = await _context.StudentsViewModel
                .FirstOrDefaultAsync(m => m.StuId == id);
            if (studentsViewModel == null)
            {
                return NotFound();
            }

            return View(studentsViewModel);
        }

        // GET: StudentsViewModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StudentsViewModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StuId,FirstName,LastName,Department,Year,Region,RoomNo")] StudentsViewModel studentsViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentsViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(studentsViewModel);
        }

        // GET: StudentsViewModels/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.StudentsViewModel == null)
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

        // POST: StudentsViewModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("StuId,FirstName,LastName,Department,Year,Region,RoomNo")] StudentsViewModel studentsViewModel)
        {
            if (id != studentsViewModel.StuId)
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
                    if (!StudentsViewModelExists(studentsViewModel.StuId))
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

        // GET: StudentsViewModels/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.StudentsViewModel == null)
            {
                return NotFound();
            }

            var studentsViewModel = await _context.StudentsViewModel
                .FirstOrDefaultAsync(m => m.StuId == id);
            if (studentsViewModel == null)
            {
                return NotFound();
            }

            return View(studentsViewModel);
        }

        // POST: StudentsViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.StudentsViewModel == null)
            {
                return Problem("Entity set 'StudentsDbContext.StudentsViewModel'  is null.");
            }
            var studentsViewModel = await _context.StudentsViewModel.FindAsync(id);
            if (studentsViewModel != null)
            {
                _context.StudentsViewModel.Remove(studentsViewModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentsViewModelExists(string id)
        {
          return (_context.StudentsViewModel?.Any(e => e.StuId == id)).GetValueOrDefault();
        }
    }
}
