using Microsoft.EntityFrameworkCore;
using Workoutino.Api.EntityFramework;
using Workoutino.Api.Infrastracture.EntityFramework.Extensions;

namespace Workoutino.Api.Infrastracture
{
    public static class Module
    {
        public static IServiceCollection AddInfrastracture(this IServiceCollection serviceCollection, IConfiguration configuration)
        => serviceCollection
                .AddDbContext<WorkoutinoDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("Workoutino")))
                .AddBaseCommandsForAllEntities<WorkoutinoDbContext>()
                .AddBaseQueriesForAllEntities<WorkoutinoDbContext>();
    }
}
