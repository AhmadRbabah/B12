namespace B12.Infrastructure.EntityConfiguration.ProductConfigurations;

using B12.Domain.AggregateModels.ProductAggregate;

public class ProductTagConfiguration : IEntityTypeConfiguration<ProductTag>
{
    public void Configure(EntityTypeBuilder<ProductTag> builder)
    {
        builder.HasKey(productTag => new { productTag.ProductId, productTag.TagId });

        builder.HasOne(productTag => productTag.Product)
               .WithMany(product => product.ProductTags)
               .HasForeignKey(productTag => productTag.ProductId);

        builder.HasOne(productTag => productTag.Tag)
               .WithMany(tag => tag.ProductTags)
               .HasForeignKey(productTag => productTag.TagId);
    }
}