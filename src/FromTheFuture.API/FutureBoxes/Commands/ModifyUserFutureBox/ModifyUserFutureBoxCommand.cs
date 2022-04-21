using MediatR;
using System;
using System.Collections.Generic;

namespace FromTheFuture.API.FutureBoxes.Commands.ModifyUserFutureBox;

public class ModifyUserFutureBoxCommand : IRequest<FutureBoxDto>
{
    public Guid UserId { get; }
    public Guid BoxId { get; }
    public string Name { get; }

    public ICollection<Guid> FutureItemsIds;

    public ModifyUserFutureBoxCommand(Guid boxId, Guid userId, string name, ICollection<Guid> futureItemsIds)
    {
        BoxId = boxId;
        UserId = userId;
        Name = name;
        FutureItemsIds = futureItemsIds;
    }
}
