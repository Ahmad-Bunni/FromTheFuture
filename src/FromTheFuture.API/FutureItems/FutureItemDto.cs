using FromTheFuture.Domain.Users.FutureItems;
using System;

namespace FromTheFuture.API.FutureItems;

public record FutureItemDto
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public Uri StorageUri { get; init; }
    public FutureItemTypes ItemType { get; init; }
    public bool IsActive { get; init; }
}
