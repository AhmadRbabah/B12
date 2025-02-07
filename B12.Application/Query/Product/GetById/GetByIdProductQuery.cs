namespace B12.Application.Query.Product.GetById;

using MediatR;

using B12.Application.Response;

public sealed class GetByIdProductQuery : IRequest<ProductResponse>
{
    public GetByIdProductQuery(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; set; }
}