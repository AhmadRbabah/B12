namespace B12.Infrastructure;

using B12.Domain.AggregateModels.CategoryAggregate;
using B12.Domain.AggregateModels.ProductAggregate;
using B12.Domain.AggregateModels.TagAggregate;

using B12.Infrastructure.EntityConfiguration.CategoryConfiguration;
using B12.Infrastructure.EntityConfiguration.ProductConfigurations;
using B12.Infrastructure.EntityConfiguration.TagConfiguration;

public class B12DbContext : DbContext
{
    public B12DbContext(DbContextOptions<B12DbContext> options)
        : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Tag> Tags { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
        modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        modelBuilder.ApplyConfiguration(new TagConfiguration());
        modelBuilder.ApplyConfiguration(new ProductTagConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}