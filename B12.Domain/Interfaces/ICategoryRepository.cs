namespace B12.Domain.Interfaces;

using B12.Domain.AggregateModels.CategoryAggregate;

public interface ICategoryRepository
{
    Task<Category> GetByIdAsync(Guid id);

    Task AddAsync(Category product);

    Task UpdateAsync(Category product);

    Task DeleteAsync(Category product);

    IQueryable<Category> GetAll();

    Task SaveChangesAsync();

    Task<bool> IsUnique(string name);

    Task<bool> IsUnique(Guid id, string name);
}