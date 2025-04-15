using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Infastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ProductsDbContext _dbContext;

    public ProductRepository(ProductsDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public async Task<IList<Product>> GetProducts()
    {
        return await _dbContext.Products.ToListAsync();
    }

    public async Task<Product?> GetProductById(Guid productId)
    {
        return await _dbContext.Products.FindAsync(productId);
    }

    public async Task<IList<Product>> GetProductsByCondition(string condition)
    {
        return await _dbContext.Products
            .Where(product => product.ProductName.Contains(condition) || product.Category.Contains(condition))
            .ToListAsync();
    }

    public async Task<Product> AddProduct(Product product)
    {
        await _dbContext.Products.AddAsync(product);
        await _dbContext.SaveChangesAsync();
        return product;
    }

    public async Task<Product> UpdateProduct(Product product)
    {
        await _dbContext.Products.AddAsync(product);
        await _dbContext.SaveChangesAsync();
        return product;
    }

    public async Task DeleteProduct(Guid productId)
    {
        await _dbContext.Products
            .Where(prod => prod.ProductId == productId).ExecuteDeleteAsync();
    }
}