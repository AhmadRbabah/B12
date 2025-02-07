namespace B12.Domain.AggregateModels.ProductAggregate;

using B12.Domain.AggregateModels.TagAggregate;

public class ProductTag
{
    public Guid ProductId { get; private set; }
    public Product Product { get; private set; }

    public Guid TagId { get; private set; }
    public Tag Tag { get; private set; }
}