using FromTheFuture.API.FutureItems.CreateUserFutureItem;
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
            var futureItem = await _mediator.Send(new CreateUserFutureItemCommand(Guid.Parse("00000000-0000-0000-0000-000000000000"), request.Name, request.StorageUri, request.ItemType));

            return Created(string.Empty, futureItem);
        }
    }
}