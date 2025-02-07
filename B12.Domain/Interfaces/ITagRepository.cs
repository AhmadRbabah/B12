namespace B12.Domain.Interfaces;

using B12.Domain.AggregateModels.TagAggregate;

public interface ITagRepository
{
    Task AddAsync(Tag tag);

    Task<bool> IsUnique(string name);

    Task SaveChangesAsync();
}