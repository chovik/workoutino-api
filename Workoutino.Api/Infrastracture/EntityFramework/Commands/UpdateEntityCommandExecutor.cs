using Microsoft.EntityFrameworkCore;
using Workoutino.Api.Application.Commands.Abstractions;

namespace Workoutino.Api.Infrastracture.EntityFramework.Commands
{
    public class UpdateEntityCommandExecutor<TCommand, TEntity> : CommandHandlerBase<TCommand>
        where TCommand : UpdateEntityCommand<TEntity>
        where TEntity : class
    {
        readonly DbContext _dbContext;

        public UpdateEntityCommandExecutor(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        protected override async Task HandleCommand(TCommand command, CancellationToken cancellationToken)
        {
            _dbContext.Set<TEntity>().UpdateRange(command.Entities);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
