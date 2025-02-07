namespace B12.Application.Command.Product.Delete;

using B12.Domain.AggregateModels.ProductAggregate;

using MediatR;

public sealed class DeleteProductCommand : IRequest<bool>
{
    public DeleteProductCommand(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; set; }
}