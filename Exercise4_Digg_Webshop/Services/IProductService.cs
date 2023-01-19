using Exercise4_Digg_Webshop.Models;

namespace Exercise4_Digg_Webshop.Services
{
    public interface IProductService
    {
        Product GetProduct(Guid id);
    }
}
