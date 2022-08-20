using MediatR;

namespace Workoutino.Api.Infrastracture.EntityFramework.Queries
{
    public abstract class QueryHandlerBase<TQuery, TResult> : IRequestHandler<TQuery, TResult> where TQuery : IRequest<TResult>
    {
        public abstract Task<TResult> Handle(TQuery request, CancellationToken cancellationToken);
    }
}
