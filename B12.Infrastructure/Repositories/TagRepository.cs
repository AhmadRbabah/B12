namespace B12.Infrastructure.Repositories;

using B12.Domain.AggregateModels.TagAggregate;
using B12.Domain.Interfaces;

using Microsoft.EntityFrameworkCore;

public class TagRepository : ITagRepository
{
    private readonly B12DbContext _context;

    public TagRepository(B12DbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task AddAsync(Tag tag)
    {
        await _context.Set<Tag>().AddAsync(tag);
    }

    public async Task<bool> IsUnique(string name)
    {
        return !await _context.Tags.AnyAsync(tag => tag.Name == name);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}