using MediatR;

namespace Workoutino.Api.Application.Queries
{
    public class GetEntityByIdQuery<TEntity> : IRequest<TEntity?> where TEntity : class
    {
        public GetEntityByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
