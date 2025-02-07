namespace B12.Application.Command.Product.Update;

using B12.Application.Response;
using B12.Domain.DataModels.Product;

using MediatR;

public class UpdateProductCommand : IRequest<ProductResponse>, IProductModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public Guid CategoryId { get; set; }
}