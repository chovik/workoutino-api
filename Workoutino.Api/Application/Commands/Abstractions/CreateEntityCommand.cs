using MediatR;

namespace Workoutino.Api.Application.Commands.Abstractions
{
    public class CreateEntityCommand<TEntity> : IRequest where TEntity : class
    {
        public CreateEntityCommand(ICollection<TEntity> entities)
        {
            Entities = entities;
        }

        public CreateEntityCommand(TEntity entity) : this(new[] { entity })
        {

        }

        public ICollection<TEntity> Entities { get; }
    }
}
