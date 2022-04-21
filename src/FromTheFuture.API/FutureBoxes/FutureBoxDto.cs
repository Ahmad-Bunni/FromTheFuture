using FromTheFuture.Domain.Users.FutureBoxes;
using System;
using System.Collections.Generic;

namespace FromTheFuture.API.FutureBoxes;

public record FutureBoxDto
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public ICollection<FutureBoxItem> FutureItems { get; init; }
}

