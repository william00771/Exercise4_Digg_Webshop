using Exercise4_Digg_Webshop.Data;
using Microsoft.AspNetCore.Mvc;

namespace Exercise4_Digg_Webshop.Controllers
{
    public class AdminController : Controller
    {
        private readonly AppDbContext _context;
        public AdminController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult EditProducts()
        {
            var products = _context.Products.ToList();
            return View(products);
        }

        public IActionResult DeleteConfirm(Guid id)
        {
            var product = _context.Products.SingleOrDefault(x => x.Id == id);
            return View(product);
        }

        public IActionResult View(Guid id)
        {
            var product = _context.Products.SingleOrDefault(x => x.Id == id);
            return View(product);
        }

        public IActionResult Edit(Guid id)
        {
            var product = _context.Products.SingleOrDefault(x => x.Id == id);
            return View(product);
        }

        public IActionResult Delete(Guid id)
        {
            var product = _context.Products.SingleOrDefault(x => x.Id == id);
            if(product == null)
            {
                return View("404 not found");
            }
            _context.Products.Remove(product);
            _context.SaveChanges();

            return RedirectToAction(nameof(EditProducts));
        }
    }
}
