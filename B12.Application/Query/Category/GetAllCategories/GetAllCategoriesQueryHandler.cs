namespace B12.Application.Query.Category.GetAllCategories;

using B12.Domain.AggregateModels.CategoryAggregate;
using B12.Domain.Interfaces;

using MediatR;

public sealed class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, List<Category>>
{
    private readonly ICategoryRepository _categoryRepository;

    public GetAllCategoriesQueryHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<List<Category>> Handle(GetAllCategoriesQuery query, CancellationToken cancellationToken)
    {
        return _categoryRepository.GetAll().ToList();
    }
}