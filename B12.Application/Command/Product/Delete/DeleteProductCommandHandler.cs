namespace B12.Application.Command.Product.Delete;

using B12.Domain.Interfaces;

using MediatR;

public sealed class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, bool>
{
    private readonly IProductRepository _productRepository;

    public DeleteProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<bool> Handle(DeleteProductCommand query, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(query.Id);
        if (product is null)
        {
            throw new ArgumentException($"Product with ID {query.Id} not found.");
        }

        bool deletionSuccessful = await _productRepository.DeleteAsync(product);
        if (!deletionSuccessful)
        {
            throw new Exception($"Failed to delete product with ID {query.Id}.");
        }

        await _productRepository.SaveChangesAsync();

        return deletionSuccessful;
    }
}