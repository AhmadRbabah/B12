namespace B12.Infrastructure.EntityConfiguration.TagConfiguration;

using B12.Domain.AggregateModels.TagAggregate;

public class TagConfiguration : IEntityTypeConfiguration<Tag>
{
    public void Configure(EntityTypeBuilder<Tag> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(p => p.Description)
            .HasMaxLength(1000)
        .IsRequired(false);

        builder.Property(p => p.IsDeleted)
            .IsRequired();

        builder.Property(p => p.CreatedBy)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(p => p.CreatedDate)
            .IsRequired();

        builder.Property(p => p.ModifiedBy)
            .HasMaxLength(100);

        builder.Property(p => p.ModifiedDate)
            .IsRequired(false);
    }
}