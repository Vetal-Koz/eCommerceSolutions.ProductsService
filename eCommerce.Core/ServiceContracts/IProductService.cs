using eCommerce.Core.DTO;

namespace eCommerce.Core.ServiceContracts;

public interface IProductService
{
    Task<IList<ProductResponse>> GetProducts();
    Task<ProductResponse> GetProductById(Guid productId);
    Task<IList<ProductResponse>> GetProductsByCondition(string condition);
    Task<ProductResponse> AddProduct(ProductAddRequest productAdd);
    Task<ProductResponse> UpdateProduct(Guid productId ,ProductUpdateRequest product);
    Task DeleteProduct(Guid productId);
}