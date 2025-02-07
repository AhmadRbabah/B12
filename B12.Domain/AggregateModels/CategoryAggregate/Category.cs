namespace B12.Domain.AggregateModels.CategoryAggregate;

using B12.Domain.AggregateModels.ProductAggregate;
using B12.Domain.DataModels.Category;

public class Category
{
    private readonly IReadOnlyCollection<Product> _products;

    public Category()
    {
        _products = new List<Product>();
    }

    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public bool IsDeleted { get; private set; }

    public IReadOnlyCollection<Product> Products => _products;

    public string CreatedBy { get; private set; }
    public DateTime CreatedDate { get; private set; }
    public string ModifiedBy { get; private set; }
    public DateTime? ModifiedDate { get; private set; }

    public static Category New(ICategoryModel model)
    {
        var instance = new Category()
        {
            Name = model.Name,
            Description = model.Description,
            CreatedBy = "System",
            CreatedDate = DateTime.UtcNow,
            IsDeleted = false
        };

        return instance;
    }

    public void Update(ICategoryModel model)
    {
        Name = model.Name;
        Description = model.Description;
        ModifiedDate = DateTime.UtcNow;
        ModifiedBy = "System";
    }
}