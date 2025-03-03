namespace B12.Api.MappingProfile;

using AutoMapper;

using B12.Api.Request.Category;
using B12.Application.Command.Category.Create;
using B12.Application.Command.Category.Update;

public class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        CreateMap<CreateCategoryRequest, CreateCategoryCommand>();
        CreateMap<UpdateCategoryRequest, UpdateCategoryCommand>();
    }
}