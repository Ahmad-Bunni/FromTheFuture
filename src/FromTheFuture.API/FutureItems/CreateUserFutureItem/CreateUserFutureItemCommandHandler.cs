﻿using FromTheFuture.Domain.Users;
using FromTheFuture.Domain.Users.FutureItems;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FromTheFuture.API.FutureItems.CreateUserFutureItem
{
    public class CreateUserFutureItemCommandHandler : IRequestHandler<CreateUserFutureItemCommand, FutureItemDto>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserFutureItemCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<FutureItemDto> Handle(CreateUserFutureItemCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserDetailsAsync(request.UserId);

            var futureItem = new FutureItem(Guid.NewGuid(), request.Name, request.StorageUri, request.ItemType);

            user.CreateFutureItem(futureItem);

            var result = await _userRepository.CommitAsync();

            return new FutureItemDto { Id = futureItem.Id, Name = futureItem.Name, ItemType = futureItem.ItemType, StorageUri = futureItem.StorageUri };

        }
    }
}
