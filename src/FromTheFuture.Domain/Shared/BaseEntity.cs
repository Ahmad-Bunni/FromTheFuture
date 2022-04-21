using System;

namespace FromTheFuture.Domain.Shared;

public abstract class BaseEntity
{
    public Guid Id { get; protected init; }
}
