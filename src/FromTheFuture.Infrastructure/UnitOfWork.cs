using FromTheFuture.Domain.Shared;
using System;
using System.Threading.Tasks;

namespace FromTheFuture.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FutureDbContext _context;

        public UnitOfWork(FutureDbContext context)
        {
            _context = context;
        }

        public async Task<CommitResult> CommitAsync()
        {
            var result = new CommitResult { IsSuccessful = true };

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.IsSuccessful = false;
                result.Exception = ex;
            }

            return result;
        }

    }
}
