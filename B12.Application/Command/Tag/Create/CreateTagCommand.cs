namespace B12.Application.Command.Tag.Create;

using MediatR;

using B12.Application.Response;
using B12.Domain.DataModels.Category;
using B12.Domain.DataModels.Tag;

public class CreateTagCommand : IRequest<TagResponse>, ITagModel
{
    public string Name { get; set; }
    public string Description { get; set; }
}