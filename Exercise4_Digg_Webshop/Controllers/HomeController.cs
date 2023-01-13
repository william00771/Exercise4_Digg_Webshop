using Exercise4_Digg_Webshop.Data;
using Exercise4_Digg_Webshop.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Exercise4_Digg_Webshop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        /*public HomeController(ILogger<HomeController> logger)
         
        {
            _logger = logger;
        }*/
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var Data = _context.Products.ToList();
            return View(Data);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}