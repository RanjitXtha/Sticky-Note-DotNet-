using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StickyNote.Models;
using System.Diagnostics;
using System.Threading.Tasks;

namespace StickyNote.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var notes = await _context.Notes
                .OrderByDescending(n => n.CreatedAt)
                .ToListAsync();

            return View(notes);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(Note note)
        {
            if (ModelState.IsValid)
            {
                await _context.Notes.AddAsync(note);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(note);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var note = await _context.Notes.FindAsync(id);
            if (note == null)
                return NotFound();

            return View(note);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Note note)
        {
            if (ModelState.IsValid)
            {
                _context.Notes.Update(note);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(note);
        }

    
        public async Task<IActionResult> Delete(int id)
        {
            var note = await _context.Notes.FindAsync(id);
            if (note == null)
                return NotFound();

            return View(note); 
        }

 
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var note = await _context.Notes.FindAsync(id);
            if (note != null)
            {
                _context.Notes.Remove(note);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

    }
}
