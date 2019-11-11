using System;
using System.Net;
using System.Threading.Tasks;
using FromTheFuture.API.FutureBoxes.CreateUserFutureBox;
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
            var futureBox = await _mediator.Send(new CreateUserFutureBoxCommand(Guid.Parse(User.Identity.Name), request.Name, request.FutureItems));

            return Created(string.Empty, futureBox);
        }


    }
}
