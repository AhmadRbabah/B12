namespace B12.Api.Controllers;

using AutoMapper;

using B12.Api.Request.Product;
using B12.Application.Command.Product.Create;
using B12.Application.Command.Product.Delete;
using B12.Application.Command.Product.Update;
using B12.Application.Query.Product.GetAllProducts;
using B12.Application.Query.Product.GetById;
using B12.Application.Response;
using B12.Domain.AggregateModels.ProductAggregate;

using MediatR;

using Microsoft.AspNetCore.Mvc;

public class ProductController : BaseController
{
    public ProductController(IMediator mediator, IMapper mapper)
        : base(mediator, mapper)
    {
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductByIdAsync(Guid id)
    {
        var getByIdQuery = new GetByIdProductQuery(id);

        var response = await Mediator.Send(getByIdQuery);

        return Ok(response);
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateProductAsync(CreateProductRequest request)
    {
        var createProductCommand = Mapper.Map<CreateProductCommand>(request);

        var response = await Mediator.Send(createProductCommand);

        return Ok(response);
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdateProductAsync(UpdateProductRequest request)
    {
        var updateProductCommand = Mapper.Map<UpdateProductCommand>(request);

        var response = await Mediator.Send(updateProductCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> PhysicalDeleteProductAsync(Guid id)
    {
        var deleteProductCommand = new DeleteProductCommand(id);

        var productDelete = await Mediator.Send(deleteProductCommand);

        if (productDelete)
        {
            return Ok("Product deleted successfully.");
        }
        else
        {
            return NotFound($"Product with ID {id} not found.");
        }
    }

    [HttpDelete("soft-delete/{id}")]
    public async Task<IActionResult> SoftDeleteProductAsync(Guid id)
    {
        var softDeleteProductCommand = new SoftDeleteProductCommand(id);

        var productDelete = await Mediator.Send(softDeleteProductCommand);

        return Ok("Deleted");
    }

    [HttpGet("search")]
    public async Task<ActionResult<List<ProductResponse>>> SearchProductAsync(
        string category = null,
        string tag = null,
        int page = 1,
        int pageSize = 10)
    {
        var getAllProducts = new GetAllProductsQuery(category, tag);

        var response = await Mediator.Send(getAllProducts);

        var paginatedProducts = response
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToList();

        return Ok(paginatedProducts);
    }
}