using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FromTheFuture.Domain.Shared
{
    public interface IUnitOfWork
    {
        Task<CommitResult> CommitAsync();
    }
}
