using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using linkHomeApp.Data;
using linkHomeApp.Models;

namespace linkHomeApp.Controllers
{
    [Authorize] // only signed-in users (Identity)
    public class AdminController : Controller
    {
        private readonly linkHomeContext _context;
        public AdminController(linkHomeContext context)
        {
            _context = context;
        }

        // GET: /Admin
        public async Task<IActionResult> AdminIndex()
        {
            var categories = await _context.Categories
                .Include(c => c.Links)
                .OrderBy(c => c.Id)
                .ToListAsync();

            foreach (var c in categories)
            {
                c.Links = c.Links?
                    .OrderByDescending(l => l.Pinned)
                    .ThenBy(l => l.Label)
                    .ToList();
            }

            return View(categories);
        }

        public async Task<IActionResult> EditCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null) return NotFound();
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Update(category);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(AdminIndex));
            }
            return View(category);
        }
    }
}