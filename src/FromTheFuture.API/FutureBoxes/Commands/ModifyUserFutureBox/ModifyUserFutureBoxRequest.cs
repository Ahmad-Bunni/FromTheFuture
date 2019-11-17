using System;
using System.Collections.Generic;

namespace FromTheFuture.API.FutureBoxes.Commands.ModifyUserFutureBox
{
    public class ModifyUserFutureBoxRequest
    {
        public string Name { get; set; }

        public ICollection<Guid> FutureItemsIds { get; set; }
    }
}
