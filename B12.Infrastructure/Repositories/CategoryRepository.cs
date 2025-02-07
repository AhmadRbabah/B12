namespace B12.Infrastructure.Repositories;

using B12.Domain.AggregateModels.CategoryAggregate;
using B12.Domain.Interfaces;

using Microsoft.EntityFrameworkCore;

public class CategoryRepository : ICategoryRepository
{
    private readonly B12DbContext _context;

    public CategoryRepository(B12DbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<Category> GetByIdAsync(Guid id)
    {
        return await _context.Set<Category>()
            .Where(x => !x.IsDeleted)
            .Include(category => category.Products)
            .SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task AddAsync(Category category)
    {
        await _context.Set<Category>().AddAsync(category);
    }

    public async Task UpdateAsync(Category category)
    {
        _context.Set<Category>().Update(category);

        await Task.CompletedTask;
    }

    public async Task DeleteAsync(Category category)
    {
        _context.Set<Category>().Remove(category);

        await Task.CompletedTask;
    }

    public IQueryable<Category> GetAll()
    {
        return _context.Categories.Where(x => !x.IsDeleted).AsQueryable();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task<bool> IsUnique(string name)
    {
        return !await _context.Categories.AnyAsync(category => category.Name == name);
    }

    public async Task<bool> IsUnique(Guid id, string name)
    {
        return !await _context.Categories.AnyAsync(category => category.Name == name && !category.IsDeleted && category.Id != id);
    }
}