namespace B12.Application.Query.Category.GetById;

using B12.Application.Response;

using MediatR;

public sealed class GetByIdCategoryQuery : IRequest<CategoryResponse>
{
    public GetByIdCategoryQuery(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; set; }
}