namespace B12.Application.MappingProfile;

using B12.Application.Command.Category.Create;
using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B12.Domain.AggregateModels.TagAggregate;
using B12.Application.Response;

public class TagProfile : Profile
{
    public TagProfile()
    {
        CreateMap<Tag, TagResponse>();
    }
}