using System;

namespace FromTheFuture.Domain.Shared
{
    public class CommitResult
    {
        public bool IsSuccessful { get; set; }
        public Exception Exception { get; set; }
    }
}
