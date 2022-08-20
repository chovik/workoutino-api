using MediatR;

namespace Workoutino.Api.Application.Queries
{
    public class GetEntitiesByIdQuery<TEntity> : IRequest<ICollection<TEntity>> where TEntity : class
    {
        public GetEntitiesByIdQuery(ICollection<int> ids)
        {
            Ids = ids;
        }

        public ICollection<int> Ids { get; }
    }
}
