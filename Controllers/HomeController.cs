using linkHomeApp.Data;
using linkHomeApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace linkHomeApp.Controllers
{
    public class HomeController : Controller
    {
        private  linkHomeContext _context;

        public HomeController(linkHomeContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {

            return View(_context);
        }
    }
}