namespace B12.Application.Command.Product.Create;

using AutoMapper;

using B12.Application.Response;
using B12.Domain.AggregateModels.ProductAggregate;
using B12.Domain.Interfaces;

using MediatR;

using System.Threading;
using System.Threading.Tasks;

public sealed class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductResponse>
{
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;

    public CreateProductCommandHandler(IMapper mapper, IProductRepository productRepository)
    {
        _mapper = mapper;
        _productRepository = productRepository;
    }

    public async Task<ProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var isProductUnique = await _productRepository.IsUnique(request.Name);
        if (!isProductUnique)
        {
            throw new ArgumentException($"Product name {request.Name} must be unique.");
        }

        var product = Product.New(request);

        await _productRepository.AddAsync(product);
        await _productRepository.SaveChangesAsync();

        var productResponse = _mapper.Map<ProductResponse>(product);

        return productResponse;
    }
}