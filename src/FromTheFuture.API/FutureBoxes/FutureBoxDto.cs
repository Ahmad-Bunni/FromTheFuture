using FromTheFuture.Domain.Users.FutureBoxes;
using System;
using System.Collections.Generic;

namespace FromTheFuture.API.FutureBoxes
{
    public class FutureBoxDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<FutureBoxItem> FutureItems { get; set; }
    }

}
