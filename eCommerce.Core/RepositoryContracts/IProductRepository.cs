using eCommerce.Core.Entities;

namespace eCommerce.Core.RepositoryContracts;

public interface IProductRepository
{
    Task<IList<Product>> GetProducts();
    Task<Product?> GetProductById(Guid productId);
    Task<IList<Product>> GetProductsByCondition(string condition);
    Task<Product> AddProduct(Product product);
    Task<Product> UpdateProduct(Product product);
    Task DeleteProduct(Guid productId);
}