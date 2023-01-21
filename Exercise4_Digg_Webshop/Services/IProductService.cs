using Exercise4_Digg_Webshop.Models;

namespace Exercise4_Digg_Webshop.Services
{
    public interface IProductService
    {
        Product GetProduct(Guid id);
        Product UpdateProduct(Guid id, Product product);
        IEnumerable<Product> GetAll();
        void DeleteProduct(Product product);
        void AddProduct(Product product);
    }
}
