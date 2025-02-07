namespace B12.Application.Response;

public class ProductResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public CategoryResponse Category { get; set; }
    public List<TagResponse> ProductTags { get; set; }
}