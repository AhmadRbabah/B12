namespace B12.Application.Command.Product.Delete;

using B12.Domain.Interfaces;

using MediatR;

public sealed class SoftDeleteProductCommandHandler : IRequestHandler<SoftDeleteProductCommand, bool>
{
    private readonly IProductRepository _productRepository;

    public SoftDeleteProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<bool> Handle(SoftDeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(request.Id);
        if (product is null)
        {
            throw new ArgumentException($"A product with the Id '{request.Id}' does not exist");
        }

        product.Delete();

        await _productRepository.SaveChangesAsync();

        return true;
    }
}