using MediatR;
using Workoutino.Api.Application.Commands.Abstractions;
using Workoutino.Api.Application.Queries;

namespace Workoutino.Api.Application.Extensions
{
    public static class MediatorExtensions
    {
        public static Task<Unit> CreateEntity<TEntity>(this IMediator mediator, TEntity entity, CancellationToken cancellationToken) where TEntity : class
           => mediator.Send(new CreateEntityCommand<TEntity>(entity), cancellationToken);

        public static Task<Unit> UpdateEntity<TEntity>(this IMediator mediator, TEntity entity, CancellationToken cancellationToken) where TEntity : class
          => mediator.Send(new UpdateEntityCommand<TEntity>(entity), cancellationToken);

        public static Task<Unit> DeleteEntity<TEntity>(this IMediator mediator, TEntity entity, CancellationToken cancellationToken) where TEntity : class
          => mediator.Send(new DeleteEntityCommand<TEntity>(entity), cancellationToken);

        public static Task<Unit> CreateEntity<TEntity>(this IMediator mediator, ICollection<TEntity> entities, CancellationToken cancellationToken) where TEntity : class
           => mediator.Send(new CreateEntityCommand<TEntity>(entities), cancellationToken);

        public static Task<Unit> UpdateEntity<TEntity>(this IMediator mediator, ICollection<TEntity> entities, CancellationToken cancellationToken) where TEntity : class
           => mediator.Send(new UpdateEntityCommand<TEntity>(entities), cancellationToken);

        public static Task<Unit> DeleteEntity<TEntity>(this IMediator mediator, ICollection<TEntity> entities, CancellationToken cancellationToken) where TEntity : class
           => mediator.Send(new DeleteEntityCommand<TEntity>(entities), cancellationToken);

        public static Task<TEntity?> GetEntityById<TEntity>(this IMediator mediator, int id, CancellationToken cancellationToken) where TEntity : class
           => mediator.Send(new GetEntityByIdQuery<TEntity>(id), cancellationToken);

        public static Task<ICollection<TEntity>> GetEntitiesById<TEntity>(this IMediator mediator, ICollection<int> ids, CancellationToken cancellationToken) where TEntity : class
           => mediator.Send(new GetEntitiesByIdQuery<TEntity>(ids), cancellationToken);
    }
}
