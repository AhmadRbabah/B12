namespace B12.Domain.Interfaces;

using B12.Domain.AggregateModels.ProductAggregate;

public interface IProductRepository
{
    Task<Product> GetByIdAsync(Guid id);

    Task AddAsync(Product product);

    Task UpdateAsync(Product product);

    Task<bool> DeleteAsync(Product product);

    IQueryable<Product> GetAll();

    Task SaveChangesAsync();

    Task<bool> IsUnique(string name);

    Task<bool> IsUnique(Guid id, string name);
}