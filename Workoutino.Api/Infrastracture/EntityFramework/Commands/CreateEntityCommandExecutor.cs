using Microsoft.EntityFrameworkCore;
using Workoutino.Api.Application.Commands.Abstractions;

namespace Workoutino.Api.Infrastracture.EntityFramework.Commands
{
    public class CreateEntityCommandExecutor<TCommand, TEntity> : CommandHandlerBase<TCommand>
        where TCommand : CreateEntityCommand<TEntity>
        where TEntity : class
    {
        readonly DbContext _dbContext;

        public CreateEntityCommandExecutor(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        protected override Task HandleCommand(TCommand command, CancellationToken cancellationToken)
         => _dbContext.Set<TEntity>().AddRangeAsync(command.Entities, cancellationToken);
    }
}
