namespace B12.Application.Command.Category.Update;

using MediatR;

using B12.Domain.DataModels.Category;
using B12.Application.Response;

public class UpdateCategoryCommand : IRequest<CategoryResponse>, ICategoryModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}