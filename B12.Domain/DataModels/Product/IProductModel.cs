namespace B12.Domain.DataModels.Product;

using B12.Domain.AggregateModels.CategoryAggregate;

public interface IProductModel
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public Guid CategoryId { get; set; }
}