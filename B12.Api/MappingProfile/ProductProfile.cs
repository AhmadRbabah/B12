namespace B12.Api.MappingProfile;

using AutoMapper;

using B12.Api.Request.Product;
using B12.Application.Command.Product.Create;
using B12.Application.Command.Product.Update;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<CreateProductRequest, CreateProductCommand>();
        CreateMap<UpdateProductRequest, UpdateProductCommand>();
    }
}