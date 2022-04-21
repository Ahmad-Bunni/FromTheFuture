using System;

namespace FromTheFuture.Domain.Users.FutureBoxes;

public record FutureBoxItem
{
    public Guid FutureBoxId { get; init; }

    public Guid FutureItemId { get; init; }
}
