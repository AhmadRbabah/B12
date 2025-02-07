namespace B12.Application.Response;

public class TagResponse
{
    public Guid Id { get;  set; }
    public string Name { get;  set; }
    public string Description { get;  set; }
    public bool IsDeleted { get;  set; }
}