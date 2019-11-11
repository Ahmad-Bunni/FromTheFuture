using FromTheFuture.Domain.Users.FutureItems;
using MediatR;
using System;
using System.Collections.Generic;

namespace FromTheFuture.API.FutureBoxes.CreateUserFutureBox
{
    public class CreateUserFutureBoxCommand : IRequest<FutureBoxDto>
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public List<FutureItem> FutureItems { get; set; }

        public CreateUserFutureBoxCommand(Guid userId, string name, List<FutureItem> futureItems)
        {
            Name = name;
            FutureItems = futureItems;
            UserId = userId;
        }
    }
}
