using CoreApplication.Models;

namespace CoreApplication.Services
{
    public interface IProductService
    {
        List<Product> GetProducts();
    }
}