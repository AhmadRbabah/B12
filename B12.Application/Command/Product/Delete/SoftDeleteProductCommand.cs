namespace B12.Application.Command.Product.Delete;

using MediatR;

public sealed class SoftDeleteProductCommand : IRequest<bool>
{
    public SoftDeleteProductCommand(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; set; }
}