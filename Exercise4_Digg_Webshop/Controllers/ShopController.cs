using Exercise4_Digg_Webshop.Data;
using Microsoft.AspNetCore.Mvc;

namespace Exercise4_Digg_Webshop.Controllers
{
    public class ShopController : Controller
    {
        private readonly AppDbContext _context;
        public ShopController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var products = _context.Products.ToList();
            return View(products);
        }
    }
}
