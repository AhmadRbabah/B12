namespace B12.Application.Response;

public class CategoryResponse
{
    public Guid Id { get; set; }
    public string Name { get;  set; }
    public string Description { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? ModifiedDate { get; set; }
}