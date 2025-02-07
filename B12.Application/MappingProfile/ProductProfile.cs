namespace B12.Application.MappingProfile;

using AutoMapper;

using B12.Application.Response;

using B12.Domain.AggregateModels.ProductAggregate;
using B12.Domain.AggregateModels.TagAggregate;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<Product, ProductResponse>()
            .ForMember(dest => dest.ProductTags, opt => opt.MapFrom(src => src.ProductTags.Select(pt => pt.Tag)));

        CreateMap<Tag, TagResponse>();
    }
}