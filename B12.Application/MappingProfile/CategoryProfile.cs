namespace B12.Application.MappingProfile;

using AutoMapper;
using B12.Application.Response;
using B12.Domain.AggregateModels.CategoryAggregate;

public class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        CreateMap<Category, CategoryResponse>();
    }
}