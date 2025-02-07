namespace B12.Application.Query.Product.GetAllProducts;

using AutoMapper;

using B12.Application.Response;
using B12.Domain.Interfaces;

using MediatR;

public sealed class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<ProductResponse>>
{
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;

    public GetAllProductsQueryHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<List<ProductResponse>> Handle(GetAllProductsQuery query, CancellationToken cancellationToken)
    {
        var productsQuery = _productRepository.GetAll();

        if (!string.IsNullOrEmpty(query.Category))
        {
            productsQuery = productsQuery.Where(p => p.Category.Name == query.Category);
        }

        if (!string.IsNullOrEmpty(query.Tag))
        {
            productsQuery = productsQuery.Where(p => p.ProductTags.Any(pt => pt.Tag.Name == query.Tag));
        }

        var products = await Task.Run(() => productsQuery.ToList(), cancellationToken);

        var productResponse = _mapper.Map<List<ProductResponse>>(products);

        return productResponse;
    }
}