namespace B12.Application.Command.Category.Create;

using AutoMapper;

using B12.Application.Response;
using B12.Domain.AggregateModels.CategoryAggregate;
using B12.Domain.Interfaces;

using MediatR;

using System.Threading;
using System.Threading.Tasks;

public class CreateTagCommandHandler : IRequestHandler<CreateTagCommand, CategoryResponse>
{
    private readonly IMapper _mapper;
    private readonly ICategoryRepository _categoryRepository;

    public CreateTagCommandHandler(IMapper mapper, ICategoryRepository categoryRepository)
    {
        _mapper = mapper;
        _categoryRepository = categoryRepository;
    }

    public async Task<CategoryResponse> Handle(CreateTagCommand request, CancellationToken cancellationToken)
    {
        var isCategoryUnique = await _categoryRepository.IsUnique(request.Name);
        if (!isCategoryUnique)
        {
            throw new ArgumentException($"Category name {request.Name} must be unique.");
        }

        var category = Category.New(request);

        await _categoryRepository.AddAsync(category);
        await _categoryRepository.SaveChangesAsync();

        var categoryResponse = _mapper.Map<CategoryResponse>(category);

        return categoryResponse;
    }
}