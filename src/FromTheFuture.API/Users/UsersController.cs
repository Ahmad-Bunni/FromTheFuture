using System.Net;
using System.Threading.Tasks;
using FromTheFuture.API.Users.CreateUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FromTheFuture.API.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
           _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(typeof(UserDto), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> CreateUser([FromBody]CreateUserRequest request)
        {
            var customer = await _mediator.Send(new CreateUserCommand(request.Email, request.Name));

            return Created(string.Empty, customer);
        }
    }
}