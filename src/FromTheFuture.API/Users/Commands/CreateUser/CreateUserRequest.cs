namespace FromTheFuture.API.Users.Commands.CreateUser;

public record CreateUserRequest
{
    public string Name { get; init; }
    public string Email { get; init; }
}
