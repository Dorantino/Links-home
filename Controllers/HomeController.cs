using linkHomeApp.Data;
using linkHomeApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace linkHomeApp.Controllers
{
    public class HomeController : Controller
    {
        private linkHomeContext _context;

        public HomeController(linkHomeContext context)
        {
            _context = context;
        }

        public IActionResult PublicIndex()
        {

            var categories = _context.Categories
            .Include(c => c.Links)
            .ToList();

            // Sort links: pinned first, then alphabetical
            foreach (var cat in categories)
            {
                if (cat.Links != null)
                {
                    cat.Links = cat.Links
                        .OrderByDescending(l => l.Pinned)
                        .ThenBy(l => l.Label)
                        .ToList();
                }
            }

            return View(categories);
        }
    }
}