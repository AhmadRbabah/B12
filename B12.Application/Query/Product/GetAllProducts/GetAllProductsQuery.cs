namespace B12.Application.Query.Product.GetAllProducts;

using B12.Application.Response;

using MediatR;

using System.Collections.Generic;

public sealed class GetAllProductsQuery : IRequest<List<ProductResponse>>
{
    public string Category { get; }
    public string Tag { get; }

    public GetAllProductsQuery(string? category = null, string? tag = null)
    {
        Category = category;
        Tag = tag;
    }
}