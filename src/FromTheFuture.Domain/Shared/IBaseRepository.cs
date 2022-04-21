using System.Threading.Tasks;

namespace FromTheFuture.Domain.Shared;

public interface IBaseRepository
{
    Task<CommitResult> CommitAsync();
}
