using Microsoft.EntityFrameworkCore;
using Workoutino.Api.Application.Queries;
using Workoutino.Api.Infrastracture.EntityFramework.Extensions;

namespace Workoutino.Api.Infrastracture.EntityFramework.Queries
{
    public class GetEntitiesByIdQueryHandler<TQuery, TEntity> : QueryHandlerBase<TQuery, ICollection<TEntity>> where TQuery : GetEntitiesByIdQuery<TEntity> where TEntity : class
    {
        readonly DbContext _dbContext;

        public GetEntitiesByIdQueryHandler(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<ICollection<TEntity>> Handle(TQuery request, CancellationToken cancellationToken)
        => await _dbContext.FindAllAsync<TEntity, int>(request.Ids, cancellationToken);
    }
}
