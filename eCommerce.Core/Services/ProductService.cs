using AutoMapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.Exceptions;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Core.ServiceContracts;

namespace eCommerce.Core.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ProductService(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }
    
    public async Task<IList<ProductResponse>> GetProducts()
    {
        var products = await _productRepository.GetProducts();
        
        return products.Select((product) => _mapper.Map<ProductResponse>(product)).ToList();
    }

    public async Task<ProductResponse> GetProductById(Guid productId)
    {
        var product = await _productRepository.GetProductById(productId);
        if (product == null)
        {
            throw new EntityNotFoundException($"Product with id: {productId} doesn't exist.");
        }
        return _mapper.Map<ProductResponse>(product);
    }

    public async Task<IList<ProductResponse>> GetProductsByCondition(string condition)
    {
        var products = await _productRepository.GetProductsByCondition(condition);
        return products.Select(product => _mapper.Map<ProductResponse>(product)).ToList();
    }

    public async Task<ProductResponse> AddProduct(ProductAddRequest productAdd)
    {
        var createdProduct = await _productRepository.AddProduct(_mapper.Map<Product>(productAdd));
        return _mapper.Map<ProductResponse>(createdProduct);
    }

    public async Task<ProductResponse> UpdateProduct(Guid productId, ProductUpdateRequest product)
    {
        var existingProduct = await _productRepository.GetProductById(productId);
        if (existingProduct == null)
        {
            throw new EntityNotFoundException($"Product with id: {productId} doesn't exist.");
        }
        
        UpdateProductFields(existingProduct, product);
        var updatedProduct = await _productRepository.UpdateProduct(existingProduct);
        
        return _mapper.Map<ProductResponse>(updatedProduct);
    }

    public async Task DeleteProduct(Guid productId)
    {
        await _productRepository.DeleteProduct(productId);
    }

    private void UpdateProductFields(Product product, ProductUpdateRequest productUpdateRequest)
    {
        product.ProductName = productUpdateRequest.ProductName;
        product.Category = productUpdateRequest.Category;
        product.QuantityInStock = productUpdateRequest.QuantityInStock;
        product.UnitPrice = productUpdateRequest.UnitPrice;
    }
}