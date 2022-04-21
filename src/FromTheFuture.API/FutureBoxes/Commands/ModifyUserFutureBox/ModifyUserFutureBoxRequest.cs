using System;
using System.Collections.Generic;

namespace FromTheFuture.API.FutureBoxes.Commands.ModifyUserFutureBox;

public record ModifyUserFutureBoxRequest
{
    public string Name { get; init; }

    public ICollection<Guid> FutureItemsIds { get; init; }
}
