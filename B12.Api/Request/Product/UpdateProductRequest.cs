namespace B12.Api.Request.Product;

using B12.Domain.DataModels.Product;

public class UpdateProductRequest : IProductModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public Guid CategoryId { get; set; }
}