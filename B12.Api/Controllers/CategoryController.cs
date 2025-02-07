namespace B12.Api.Controllers;

using AutoMapper;

using B12.Api.Request.Category;
using B12.Application.Command.Category.Create;
using B12.Application.Command.Category.Update;
using B12.Application.Query.Category.GetAllCategories;
using B12.Application.Query.Category.GetById;
using B12.Domain.AggregateModels.CategoryAggregate;

using MediatR;

using Microsoft.AspNetCore.Mvc;

public class CategoryController : BaseController
{
    public CategoryController(IMediator mediator, IMapper mapper)
        : base(mediator, mapper)
    {
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCategoryByIdAsync(Guid id)
    {
        var getByIdCategoryQuery = new GetByIdCategoryQuery(id);

        var response = await Mediator.Send(getByIdCategoryQuery);

        return Ok(response);
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateCategoryAsync(CreateCategoryRequest request)
    {
        var createCategoryCommand = Mapper.Map<CreateTagCommand>(request);

        var response = await Mediator.Send(createCategoryCommand);

        return Ok(response);
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdateCategoryAsync(UpdateCategoryRequest request)
    {
        var updateCategoryCommand = Mapper.Map<UpdateCategoryCommand>(request);

        var response = await Mediator.Send(updateCategoryCommand);

        return Ok(response);
    }

    [HttpGet("search")]
    public async Task<ActionResult<IEnumerable<Category>>> SearchCategoriesAsync(int page, int pageSize)
    {
        var getAllCategories = new GetAllCategoriesQuery();

        var response = await Mediator.Send(getAllCategories);

        var userPerPage = response
           .Skip((page - 1) * pageSize)
           .Take(pageSize)
           .ToList();

        return Ok(userPerPage);
    }
}