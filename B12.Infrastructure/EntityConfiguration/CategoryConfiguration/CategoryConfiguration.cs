namespace B12.Infrastructure.EntityConfiguration.CategoryConfiguration;

using B12.Domain.AggregateModels.CategoryAggregate;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(category => category.Id);

        builder.Property(category => category.Name)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(category => category.Description)
            .HasMaxLength(1000)
            .IsRequired(false);

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

        builder.HasMany(category => category.Products)
            .WithOne(product => product.Category)
            .HasForeignKey(product => product.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}