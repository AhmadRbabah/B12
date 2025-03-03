namespace B12.Infrastructure.Repositories;

using B12.Domain.AggregateModels.CategoryAggregate;
using B12.Domain.AggregateModels.ProductAggregate;
using B12.Domain.Interfaces;

public class ProductRepository : IProductRepository
{
    private readonly B12DbContext _context;

    public ProductRepository(B12DbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<Product> GetByIdAsync(Guid id)
    {
        return await _context.Set<Product>()
            .Where(product => !product.IsDeleted)
            .Include(product => product.Category)
            .Include(product => product.ProductTags)
            .SingleOrDefaultAsync(p => p.Id == id);
    }

    public async Task AddAsync(Product product)
    {
        await _context.Set<Product>().AddAsync(product);
    }

    public async Task UpdateAsync(Product product)
    {
        _context.Set<Product>().Update(product);

        await Task.CompletedTask;
    }

    public async Task<bool> DeleteAsync(Product product)
    {
        if (product == null) return false;
        _context.Set<Product>().Remove(product);

        return await _context.SaveChangesAsync() > 0;
    }

    public IQueryable<Product> GetAll()
    {
        return _context.Set<Product>()
            .Include(product => product.Category)
            .Include(product => product.ProductTags)
                .ThenInclude(pt => pt.Tag)
            .Where(product => !product.IsDeleted)
            .AsQueryable()
            .AsNoTracking();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task<bool> IsUnique(string name)
    {
        return !await _context.Products.AnyAsync(product => product.Name == name);
    }

    public async Task<bool> IsUnique(Guid id, string name)
    {
        return !await _context.Products.AnyAsync(product => product.Name == name && !product.IsDeleted && product.Id != id);
    }
}