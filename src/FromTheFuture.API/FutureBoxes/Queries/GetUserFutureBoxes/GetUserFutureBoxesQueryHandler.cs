using Dapper;
using FromTheFuture.Domain.Shared;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FromTheFuture.API.FutureBoxes.Queries.GetUserFutureBoxes;

public class GetUserFutureBoxesQueryHandler : IRequestHandler<GetUserFutureBoxesQuery, List<FutureBoxDto>>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public GetUserFutureBoxesQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<List<FutureBoxDto>> Handle(GetUserFutureBoxesQuery request, CancellationToken cancellationToken)
    {
        var connection = _sqlConnectionFactory.GetOpenConnection();

        const string sql = "SELECT [Id], [Name] FROM [user].[FutureBoxes] WHERE UserID = @UserID";
        var boxes = await connection.QueryAsync<FutureBoxDto>(sql, new { request.UserId });

        return boxes.AsList();
    }
}
