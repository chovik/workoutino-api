using MediatR;

namespace Workoutino.Api.Application.Commands.Abstractions
{
    public class UpdateEntityCommand<TEntity> : IRequest where TEntity : class
    {
        public UpdateEntityCommand(ICollection<TEntity> entities)
        {
            Entities = entities;
        }

        public UpdateEntityCommand(TEntity entity) : this(new[] { entity })
        {

        }

        public ICollection<TEntity> Entities { get; }
    }
}
