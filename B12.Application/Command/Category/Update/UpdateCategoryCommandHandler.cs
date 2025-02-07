namespace B12.Application.Command.Category.Update;

using AutoMapper;

using B12.Application.Response;
using B12.Domain.Interfaces;

using MediatR;

using System.Threading;
using System.Threading.Tasks;

public sealed class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, CategoryResponse>
{
    private readonly IMapper _mapper;
    private readonly ICategoryRepository _categoryRepository;

    public UpdateCategoryCommandHandler(IMapper mapper, ICategoryRepository categoryRepository)
    {
        _mapper = mapper;
        _categoryRepository = categoryRepository;
    }

    public async Task<CategoryResponse> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetByIdAsync(request.Id);
        if (category is null)
        {
            throw new ArgumentException($"A Category with the name '{request.Name}' does not exist");
        }

        var isCategoryUnique = await _categoryRepository.IsUnique(request.Id, request.Name);
        if (!isCategoryUnique)
        {
            throw new ArgumentException($"Category name {request.Name} must be unique.");
        }

        category.Update(request);

        await _categoryRepository.SaveChangesAsync();

        var categoryResponse = _mapper.Map<CategoryResponse>(category);

        return categoryResponse;
    }
}