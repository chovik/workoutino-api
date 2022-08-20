using MediatR;

namespace Workoutino.Api.Application.Commands.Abstractions
{
    public class DeleteEntityCommand<TEntity> : IRequest where TEntity : class
    {
        public DeleteEntityCommand(ICollection<TEntity> entities)
        {
            Entities = entities;
        }

        public DeleteEntityCommand(TEntity entity) : this(new[] { entity })
        {

        }

        public ICollection<TEntity> Entities { get; }
    }
}
