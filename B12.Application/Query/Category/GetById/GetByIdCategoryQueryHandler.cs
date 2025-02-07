namespace B12.Application.Query.Category.GetById;

using AutoMapper;

using B12.Application.Response;
using B12.Domain.Interfaces;

using MediatR;

public sealed class GetByIdCategoryQueryHandler : IRequestHandler<GetByIdCategoryQuery, CategoryResponse>
{
    private readonly IMapper _mapper;
    private readonly ICategoryRepository _categoryRepository;

    public GetByIdCategoryQueryHandler(IMapper mapper, ICategoryRepository categoryRepository)
    {
        _mapper = mapper;
        _categoryRepository = categoryRepository;
    }

    public async Task<CategoryResponse> Handle(GetByIdCategoryQuery query, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetByIdAsync(query.Id);
        if (category is null)
        {
            throw new ArgumentException($"Category with ID {query.Id} not found.");
        }

        var categoryResponse = _mapper.Map<CategoryResponse>(category);

        return categoryResponse;
    }
}