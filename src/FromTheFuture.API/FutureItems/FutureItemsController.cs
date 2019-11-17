using FromTheFuture.API.FutureItems.Commands.CreateUserFutureItem;
using FromTheFuture.API.FutureItems.Commands.ModifyUserFutureItem;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace FromTheFuture.API.FutureItems
{
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
            var futureItem = await _mediator.Send(new CreateUserFutureItemCommand(Guid.Parse("00000000-0000-0000-0000-000000000000"), request.Name, request.StorageUri, request.ItemType, request.IsActive));

            return Created(string.Empty, futureItem);
        }

        [Route("{itemId}")]
        [HttpPut]
        [ProducesResponseType(typeof(FutureItemDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> ModifyFutureItem(ModifyUserFutureItemRequest request, Guid itemId)
        {
            var futureItem = await _mediator.Send(new ModifyUserFutureItemCommand(itemId, Guid.Parse("00000000-0000-0000-0000-000000000000"), request.Name, request.StorageUri, request.ItemType, request.IsActive));

            return Ok(futureItem);
        }
    }
}