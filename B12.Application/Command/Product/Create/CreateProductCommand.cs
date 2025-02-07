namespace B12.Application.Command.Product.Create;

using B12.Application.Response;
using B12.Domain.DataModels.Product;

using MediatR;

public class CreateProductCommand : IRequest<ProductResponse>, IProductModel
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string CategoryName { get; set; }
    public Guid CategoryId { get; set; }
}