namespace B12.Domain.AggregateModels.ProductAggregate;

using B12.Domain.AggregateModels.CategoryAggregate;
using B12.Domain.DataModels.Product;

public class Product
{
    private readonly IReadOnlyCollection<ProductTag> _productTags;

    private Product()
    {
        _productTags = new List<ProductTag>();
    }

    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public decimal Price { get; private set; }
    public bool IsDeleted { get; private set; }

    public Guid CategoryId { get; set; }
    public Category Category { get; set; }

    public IReadOnlyCollection<ProductTag> ProductTags => _productTags;

    public string CreatedBy { get; private set; }
    public DateTime CreatedDate { get; private set; }
    public string ModifiedBy { get; private set; }
    public DateTime? ModifiedDate { get; private set; }

    public static Product New(IProductModel model)
    {
        var instance = new Product()
        {
            Name = model.Name,
            Description = model.Description,
            Price = model.Price,
            IsDeleted = false,
            CreatedBy = "System",
            CreatedDate = DateTime.UtcNow,
            CategoryId = model.CategoryId
        };

        return instance;
    }

    public void Update(IProductModel model)
    {
        Name = model.Name;
        Description = model.Description;
        Price = model.Price;
        CategoryId = model.CategoryId;
        ModifiedDate = DateTime.UtcNow;
        ModifiedBy = "System";
    }

    public void Delete()
    {
        IsDeleted = true;
    }
}