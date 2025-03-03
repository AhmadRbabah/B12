namespace B12.Domain.AggregateModels.TagAggregate;

using B12.Domain.AggregateModels.ProductAggregate;
using B12.Domain.DataModels.Tag;

public class Tag
{
    private readonly IReadOnlyCollection<ProductTag> _productTags;

    private Tag()
    {
        _productTags = new List<ProductTag>();
    }

    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public bool IsDeleted { get; private set; }
    public string CreatedBy { get; private set; }
    public DateTime CreatedDate { get; private set; }
    public string ModifiedBy { get; private set; }
    public DateTime? ModifiedDate { get; private set; }

    public IReadOnlyCollection<ProductTag> ProductTags => ProductTags;

    public static Tag New(ITagModel model)
    {
        var instance = new Tag()
        {
            Name = model.Name,
            Description = model.Description,
            CreatedBy = "System",
            CreatedDate = DateTime.UtcNow,
            IsDeleted = false
        };

        return instance;
    }
}