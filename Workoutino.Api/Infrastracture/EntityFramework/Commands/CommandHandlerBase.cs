using MediatR;

namespace Workoutino.Api.Infrastracture.EntityFramework.Commands
{
    public abstract class CommandHandlerBase<TCommand> : IRequestHandler<TCommand> where TCommand : IRequest
    {
        public async Task<Unit> Handle(TCommand request, CancellationToken cancellationToken)
        {
            await HandleCommand(request, cancellationToken);
            return Unit.Value;
        }

        protected abstract Task HandleCommand(TCommand command, CancellationToken cancellationToken);
    }
}
