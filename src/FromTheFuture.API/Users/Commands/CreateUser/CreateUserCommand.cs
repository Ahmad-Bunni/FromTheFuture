using MediatR;

namespace FromTheFuture.API.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<UserDto>
    {
        public string Email { get; }

        public string Name { get; }

        public CreateUserCommand(string email, string name)
        {
            Email = email;
            Name = name;
        }
    }
}
