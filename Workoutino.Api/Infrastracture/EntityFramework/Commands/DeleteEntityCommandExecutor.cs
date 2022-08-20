using Microsoft.EntityFrameworkCore;
using Workoutino.Api.Application.Commands.Abstractions;

namespace Workoutino.Api.Infrastracture.EntityFramework.Commands
{
    public class DeleteEntityCommandExecutor<TCommand, TEntity> : CommandHandlerBase<TCommand>
        where TCommand : DeleteEntityCommand<TEntity>
        where TEntity : class
    {
        readonly DbContext _dbContext;

        public DeleteEntityCommandExecutor(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        protected override async Task HandleCommand(TCommand command, CancellationToken cancellationToken)
        {
            _dbContext.Set<TEntity>().RemoveRange(command.Entities);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
