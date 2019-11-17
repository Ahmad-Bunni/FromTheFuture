using MediatR;
using System;

namespace FromTheFuture.API.FutureBoxes.Commands.CreateUserFutureBox
{
    public class CreateUserFutureBoxCommand : IRequest<FutureBoxDto>
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }

        public CreateUserFutureBoxCommand(Guid userId, string name)
        {
            Name = name;
            UserId = userId;
        }
    }
}
