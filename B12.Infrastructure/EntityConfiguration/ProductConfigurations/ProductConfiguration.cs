namespace B12.Infrastructure.EntityConfiguration.ProductConfigurations;

using B12.Domain.AggregateModels.ProductAggregate;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(product => product.Id);

        builder.Property(product => product.Name)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(product => product.Price)
            .IsRequired();

        builder.Property(product => product.Description)
            .IsRequired(false)
            .HasMaxLength(1000);

        builder.Property(product => product.IsDeleted)
            .IsRequired();

        builder.Property(product => product.CreatedBy)
            .IsRequired(false)
            .HasMaxLength(100);

        builder.Property(product => product.CreatedDate)
            .IsRequired();

        builder.Property(product => product.ModifiedBy)
            .IsRequired(false)
            .HasMaxLength(100);

        builder.Property(product => product.ModifiedDate)
            .IsRequired(false);
    }
}