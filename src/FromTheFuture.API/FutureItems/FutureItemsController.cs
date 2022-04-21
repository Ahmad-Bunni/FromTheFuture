using FromTheFuture.API.FutureItems.Commands.CreateUserFutureItem;
using FromTheFuture.API.FutureItems.Commands.ModifyUserFutureItem;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace FromTheFuture.API.FutureItems;

[Route("api/[controller]")]
[ApiController]
public class FutureItemsController : ControllerBase
{
    private readonly IMediator _mediator;

    public FutureItemsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType(typeof(FutureItemDto), (int)HttpStatusCode.Created)]
    public async Task<IActionResult> CreateFutureItem(CreateUserFutureItemRequest request)
    {
        var command = new CreateUserFutureItemCommand(
            UserId,
            request.Name,
            request.StorageUri,
            request.ItemType,
            request.IsActive);

        var futureItem = await _mediator.Send(command);

        return Created(string.Empty, futureItem);
    }

    [Route("item/{itemId:guid}")]
    [HttpPut]
    [ProducesResponseType(typeof(FutureItemDto), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> ModifyFutureItem(ModifyUserFutureItemRequest request, Guid itemId)
    {
        var command = new ModifyUserFutureItemCommand(itemId, UserId, request.Name, request.StorageUri, request.ItemType, request.IsActive);

        var futureItem = await _mediator.Send(command);

        return Ok(futureItem);
    }

    static Guid UserId => Guid.NewGuid();
}
