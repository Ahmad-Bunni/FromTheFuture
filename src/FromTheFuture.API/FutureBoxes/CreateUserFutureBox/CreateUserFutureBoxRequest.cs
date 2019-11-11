using FromTheFuture.Domain.Users.FutureItems;
using System.Collections.Generic;

namespace FromTheFuture.API.FutureBoxes.CreateUserFutureBox
{
    public class CreateUserFutureBoxRequest
    {
        public string Name { get; set; }

        public List<FutureItem> FutureItems { get; set; }
    }
}
