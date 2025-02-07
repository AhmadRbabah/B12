using B12.Domain.DataModels.Category;

namespace B12.Api.Request.Category;

public class CreateCategoryRequest : ICategoryModel
{
    public string Name { get; set; }
    public string Description { get; set; }
}