using FromTheFuture.Domain.Shared;
using System;
using System.Threading.Tasks;

namespace FromTheFuture.Infrastructure
{
    public abstract class BaseRepository : IBaseRepository
    {
        private readonly FutureDbContext _context;

        public BaseRepository(FutureDbContext context)
        {
            _context = context;
        }

        public async Task<CommitResult> CommitAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
                return CommitResult.Success;
            }
            catch (Exception)
            {
                //log

                return CommitResult.Fail;
            }
        }

    }
}
