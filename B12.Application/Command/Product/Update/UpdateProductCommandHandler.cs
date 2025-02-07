namespace B12.Application.Command.Product.Update;

using AutoMapper;

using B12.Application.Response;
using B12.Domain.Interfaces;

using MediatR;

using System.Threading;
using System.Threading.Tasks;

public sealed class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ProductResponse>
{
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;

    public UpdateProductCommandHandler(IMapper mapper, IProductRepository productRepository)
    {
        _mapper = mapper;
        _productRepository = productRepository;
    }

    public async Task<ProductResponse> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(request.Id);
        if (product is null)
        {
            throw new ArgumentException($"A product with the name '{request.Name}' does not exist");
        }

        var isProductUnique = await _productRepository.IsUnique(request.Id, request.Name);
        if (!isProductUnique)
        {
            throw new ArgumentException($"Product name {request.Name} must be unique.");
        }

        product.Update(request);

        await _productRepository.SaveChangesAsync();

        var productResponse = _mapper.Map<ProductResponse>(product);

        return productResponse;
    }
}