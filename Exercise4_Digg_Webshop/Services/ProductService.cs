using Exercise4_Digg_Webshop.Data;
using Exercise4_Digg_Webshop.Models;

namespace Exercise4_Digg_Webshop.Services
{
    public class ProductService : IProductService
    {
        //Importerar Databas
        private readonly AppDbContext _context;
        public ProductService(AppDbContext context)
        {
            _context = context;
        }
        public Product GetProduct(Guid id)
        {
            var result = _context.Products.FirstOrDefault(x => x.Id == id);
            return result;
        }
    }
}
