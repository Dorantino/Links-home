using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using linkHomeApp.Data;
using linkHomeApp.Models;

namespace linkHomeApp.Controllers
{
    // [Authorize]
    public class AdminController : Controller
    {
        private readonly linkHomeContext _context;
        public AdminController(linkHomeContext context)
        {
            _context = context;
        }
        // --------------------------------------------------admin dashboard
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

        // --------------------------------------------------category management
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

        // --------------------------------------------------link management
        public IActionResult AddLink(int categoryId)
        {
            var category = _context.Categories.Find(categoryId);
            if (category == null) return NotFound();

            var link = new Link { CategoryId = categoryId };
            return View(link);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddLink(Link link)
        {
            if (ModelState.IsValid)
            {
                _context.Links.Add(link);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(AdminIndex));
            }
            return View(link);
        }


        public async Task<IActionResult> EditLink(int id)
        {
            var link = await _context.Links.FindAsync(id);
            if (link == null) return NotFound();

            ViewBag.Categories = await _context.Categories.ToListAsync();
            return View(link);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditLink(Link link)
        {
            if (ModelState.IsValid)
            {
                _context.Update(link);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(AdminIndex));
            }
            ViewBag.Categories = await _context.Categories.ToListAsync();
            return View(link);
        }

        public async Task<IActionResult> DeleteLink(int id)
        {
            var link = await _context.Links
                .Include(l => l.Category)
                .FirstOrDefaultAsync(l => l.Id == id);
            if (link == null) return NotFound();
            return View(link);
        }

        [HttpPost, ActionName("DeleteLink")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteLinkConfirmed(int id)
        {
            var link = await _context.Links.FindAsync(id);
            if (link != null)
            {
                _context.Links.Remove(link);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(AdminIndex));
        }
    }
}