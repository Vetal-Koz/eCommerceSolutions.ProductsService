using eCommerce.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eCommerce.Infastructure.Configurations;

public class ProductsConfiguration : IEntityTypeConfiguration<Product>
{
    
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.
            Property(x => x.ProductName)
            .IsRequired()
            .HasColumnType("varchar(30)");
        builder
            .Property(x => x.Category)
            .IsRequired()
            .HasColumnType("varchar(30)");
    }
}