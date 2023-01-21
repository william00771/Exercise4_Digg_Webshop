using Exercise4_Digg_Webshop.Data;
using Exercise4_Digg_Webshop.Models;
using Microsoft.EntityFrameworkCore.Update.Internal;

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

        public void DeleteProduct(Product product)
        {
            _context.Products.Remove(product);
            _context.SaveChanges();
        }

        public IEnumerable<Product> GetAll()
        {
            var products = _context.Products.ToList();
            return products;
        }
        public Product GetProduct(Guid id)
        {
            var result = _context.Products.FirstOrDefault(x => x.Id == id);
            return result;
        }
        public Product UpdateProduct(Guid id, Product newProduct)
        {
            _context.Update(newProduct);
            _context.SaveChanges();
            return newProduct;
        }
        public void AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }
    }
}
