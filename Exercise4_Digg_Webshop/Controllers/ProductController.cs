using Exercise4_Digg_Webshop.Services;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Exercise4_Digg_Webshop.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _service;
        public ProductController(IProductService service)
        {
            _service = service;
        }

        public IActionResult Details(Guid id)
        {
            var productdetails = _service.GetProduct(id);

            if(productdetails == null)
            {
                return View("NotFound");
            }
            return View(productdetails);
        }
    }
}
