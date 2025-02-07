namespace B12.Application.Query.Product.GetById;

using AutoMapper;

using B12.Application.Response;
using B12.Domain.Interfaces;

using MediatR;

public sealed class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductQuery, ProductResponse>
{
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;

    public GetByIdProductQueryHandler(IMapper mapper, IProductRepository productRepository)
    {
        _mapper = mapper;
        _productRepository = productRepository;
    }

    public async Task<ProductResponse> Handle(GetByIdProductQuery query, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(query.Id);
        if (product == null)
        {
            throw new ArgumentException($"Product with ID {query.Id} not found.");
        }

        var productResponse = _mapper.Map<ProductResponse>(product);

        return productResponse;
    }
}