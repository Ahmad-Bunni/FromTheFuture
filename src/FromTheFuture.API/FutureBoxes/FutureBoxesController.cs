using FromTheFuture.API.FutureBoxes.Commands.CreateUserFutureBox;
using FromTheFuture.API.FutureBoxes.Commands.ModifyUserFutureBox;
using FromTheFuture.API.FutureBoxes.Queries.GetUserFutureBoxes;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace FromTheFuture.API.FutureBoxes;

[Route("api/[controller]")]
[ApiController]
public class FutureBoxesController : ControllerBase
{
    private readonly IMediator _mediator;

    public FutureBoxesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("{userId}/boxes")]
    [ProducesResponseType(typeof(List<FutureBoxDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> CreateUserFutureBox(Guid userId)
    {
        var futureBoxes = await _mediator.Send(new GetUserFutureBoxesQuery(userId));

        return Ok(futureBoxes);
    }

    [HttpPost]
    [ProducesResponseType(typeof(FutureBoxDto), (int)HttpStatusCode.Created)]
    public async Task<IActionResult> CreateUserFutureBox([FromBody] CreateUserFutureBoxRequest request)
    {
        var futureBox = await _mediator.Send(new CreateUserFutureBoxCommand(Guid.NewGuid(), request.Name));

        return Created(string.Empty, futureBox);
    }

    [Route("{boxId}")]
    [HttpPut]
    [ProducesResponseType(typeof(FutureBoxDto), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> ModifyUserFutureBox([FromBody] ModifyUserFutureBoxRequest request, Guid boxId)
    {
        var futureBox = await _mediator.Send(new ModifyUserFutureBoxCommand(boxId, Guid.NewGuid(), request.Name, request.FutureItemsIds));

        return Ok(futureBox);
    }
}
