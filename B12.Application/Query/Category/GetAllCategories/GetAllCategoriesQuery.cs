namespace B12.Application.Query.Category.GetAllCategories;

using B12.Domain.AggregateModels.CategoryAggregate;

using MediatR;

using System.Collections.Generic;

public sealed class GetAllCategoriesQuery : IRequest<List<Category>>
{
}