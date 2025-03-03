namespace B12.Application.Command.Category.Create;

using MediatR;

using B12.Application.Response;
using B12.Domain.DataModels.Category;

public class CreateCategoryCommand : IRequest<CategoryResponse>, ICategoryModel
{
    public string Name { get; set; }
    public string Description { get; set; }
}