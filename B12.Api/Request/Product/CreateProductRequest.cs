namespace B12.Api.Request.Product;

using B12.Domain.DataModels.Product;

using System;

public class CreateProductRequest : IProductModel
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public Guid CategoryId { get; set; }
}