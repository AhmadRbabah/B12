namespace B12.Api.Request.Category;

using B12.Domain.DataModels.Category;

public class UpdateCategoryRequest : ICategoryModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}