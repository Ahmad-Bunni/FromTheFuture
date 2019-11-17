﻿using MediatR;
using System;
using System.Collections.Generic;

namespace FromTheFuture.API.FutureBoxes.Queries.GetUserFutureBoxes
{
    public class GetUserFutureBoxesQuery : IRequest<List<FutureBoxDto>>
    {
        public Guid UserID { get; }

        public GetUserFutureBoxesQuery(Guid userId)
        {
            UserID = userId;
        }
    }
}
