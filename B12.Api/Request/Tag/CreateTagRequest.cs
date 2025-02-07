namespace B12.Api.Request.Tag;

using B12.Domain.DataModels.Tag;

public class CreateTagRequest : ITagModel
{
    public string Name { get; set; }
    public string Description { get; set; }
}