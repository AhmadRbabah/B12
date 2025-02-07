namespace B12.Api.Controllers;

using AutoMapper;
using B12.Api.Request.Tag;
using B12.Application.Command.Tag.Create;
using B12.Domain.DataModels.Tag;
using MediatR;
using Microsoft.AspNetCore.Mvc;

public class TagController : BaseController
{
    public TagController(IMediator mediator, IMapper mapper)
        : base(mediator, mapper)
    {
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateTagAsync(CreateTagRequest request)
    {
        var createTagCommand = Mapper.Map<CreateTagCommand>(request);

        var response = await Mediator.Send(createTagCommand);

        return Ok(response);
    }
}