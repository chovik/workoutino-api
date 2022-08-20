using Microsoft.EntityFrameworkCore;
using Workoutino.Api.Application.Queries;

namespace Workoutino.Api.Infrastracture.EntityFramework.Queries
{
    public class GetEntityByIdQueryHandler<TQuery, TEntity> : QueryHandlerBase<TQuery, TEntity?> where TQuery : GetEntityByIdQuery<TEntity> where TEntity : class
    {
        readonly DbContext _dbContext;

        public GetEntityByIdQueryHandler(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<TEntity?> Handle(TQuery request, CancellationToken cancellationToken)
        => await _dbContext.Set<TEntity>().FindAsync(request.Id, cancellationToken);
    }
}
