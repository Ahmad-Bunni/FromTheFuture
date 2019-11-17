using MediatR;
using System;
using System.Collections.Generic;

namespace FromTheFuture.API.FutureBoxes.Commands.ModifyUserFutureBox
{
    public class ModifyUserFutureBoxCommand : IRequest<FutureBoxDto>
    {
        public Guid UserId { get; set; }
        public Guid BoxId { get; set; }
        public string Name { get; set; }

        public ICollection<Guid> FutureItemsIds;

        public ModifyUserFutureBoxCommand(Guid boxId, Guid userId, string name, ICollection<Guid> futureItemsIds)
        {
            BoxId = boxId;
            UserId = userId;
            Name = name;
            FutureItemsIds = futureItemsIds;
        }
    }
}
