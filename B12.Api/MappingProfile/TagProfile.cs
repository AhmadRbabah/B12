using AutoMapper;
using B12.Api.Request.Tag;
using B12.Application.Command.Tag.Create;

namespace B12.Api.MappingProfile;

public class TagProfile : Profile
{
    public TagProfile()
    {
        CreateMap<CreateTagRequest, CreateTagCommand>();
    }
}