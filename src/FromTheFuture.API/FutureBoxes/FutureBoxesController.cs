using System;
using System.Net;
using System.Threading.Tasks;
using FromTheFuture.API.FutureBoxes.CreateUserFutureBox;
using FromTheFuture.API.FutureBoxes.ModifyUserFutureBox;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FromTheFuture.API.FutureBoxes
{
    [Route("api/[controller]")]
    [ApiController]
    public class FutureBoxesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FutureBoxesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(typeof(FutureBoxDto), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> CreateUserFutureBox([FromBody] CreateUserFutureBoxRequest request)
        {
            var futureBox = await _mediator.Send(new CreateUserFutureBoxCommand(Guid.Parse("00000000-0000-0000-0000-000000000000"), request.Name));

            return Created(string.Empty, futureBox);
        }

        [Route("{boxId}")]
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> ModifyUserFutureBox([FromBody] ModifyUserFutureBoxRequest request, Guid boxId)
        {
            await _mediator.Send(new ModifyUserFutureBoxCommand(boxId,
               Guid.Parse("00000000-0000-0000-0000-000000000000"), request.Name, request.FutureItemsIds));

            return NoContent();
        }


    }
}
