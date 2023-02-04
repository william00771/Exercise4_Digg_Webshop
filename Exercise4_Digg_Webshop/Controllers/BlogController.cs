using Exercise4_Digg_Webshop.Data;
using Exercise4_Digg_Webshop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Exercise4_Digg_Webshop.Controllers
{
    public class BlogController : Controller
    {
        private readonly AppDbContext _context;
        public BlogController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            
            var data = _context.BlogArticles.ToList();
            //How to get all the other models In? = BlogArticle -> Sections -> SectionImageModules -> Images = ?

            return View(data);
        }
    }
}
