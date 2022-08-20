using MediatR;
using Microsoft.EntityFrameworkCore;
using Workoutino.Api.Application.Commands.Abstractions;
using Workoutino.Api.Application.Queries;
using Workoutino.Api.Infrastracture.EntityFramework.Commands;
using Workoutino.Api.Infrastracture.EntityFramework.Queries;

namespace Workoutino.Api.Infrastracture.EntityFramework.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBaseCommandsForAllEntities<TDbContext>(this IServiceCollection services)
            where TDbContext : DbContext
        {
            var entityTypes = GetDbContextEntityTypes<TDbContext>();
            var addBaseCommandsMethodInfo = typeof(ServiceCollectionExtensions)
                .GetMethod(nameof(ServiceCollectionExtensions.AddBaseCommands));

            foreach (var entityType in entityTypes)
            {
                addBaseCommandsMethodInfo.MakeGenericMethod(entityType, typeof(TDbContext)).Invoke(null, new[] { services });
            }

            return services;
        }

        public static IServiceCollection AddBaseQueriesForAllEntities<TDbContext>(this IServiceCollection services)
            where TDbContext : DbContext
        {
            var entityTypes = GetDbContextEntityTypes<TDbContext>();
            var addBaseCommandsMethodInfo = typeof(ServiceCollectionExtensions)
                .GetMethod(nameof(ServiceCollectionExtensions.AddBaseQueries));

            foreach (var entityType in entityTypes)
            {
                addBaseCommandsMethodInfo.MakeGenericMethod(entityType, typeof(TDbContext)).Invoke(null, new[] { services });
            }

            return services;
        }

        public static IServiceCollection AddBaseQueries<TEntity, TDbContext>(this IServiceCollection services)
            where TEntity : class
            where TDbContext : DbContext
        =>
            services
                .AddScoped<IRequestHandler<GetEntitiesByIdQuery<TEntity>, ICollection<TEntity>>>(provider =>
                {
                    var dbContext = provider.GetRequiredService<TDbContext>();

                    return new GetEntitiesByIdQueryHandler<GetEntitiesByIdQuery<TEntity>, TEntity>(dbContext);
                });

        public static IServiceCollection AddBaseCommands<TEntity, TDbContext>(this IServiceCollection services)
            where TEntity : class
            where TDbContext : DbContext
        {
            return services
                .AddScoped<
                    IRequestHandler<CreateEntityCommand<TEntity>>>(provider =>
                    {
                        var dbContext = provider.GetRequiredService<TDbContext>();

                        return new CreateEntityCommandExecutor<CreateEntityCommand<TEntity>, TEntity>(dbContext);
                    })
                .AddScoped<
                    IRequestHandler<UpdateEntityCommand<TEntity>>>(provider =>
                    {
                        var dbContext = provider.GetRequiredService<TDbContext>();

                        return new UpdateEntityCommandExecutor<UpdateEntityCommand<TEntity>, TEntity>(dbContext);
                    })
                .AddScoped<
                    IRequestHandler<DeleteEntityCommand<TEntity>>>(provider =>
                    {
                        var dbContext = provider.GetRequiredService<TDbContext>();

                        return new DeleteEntityCommandExecutor<DeleteEntityCommand<TEntity>, TEntity>(dbContext);
                    });
        }

        static Type GetQueryResultType(Type type, int maximumLevels)
        {
            if (type.BaseType.GenericTypeArguments.Any())
            {
                return type.BaseType.GetGenericArguments()[0];
            }

            if (maximumLevels <= 1)
            {
                throw new InvalidOperationException("Maximum number of levels reached");
            }

            return GetQueryResultType(type.BaseType, maximumLevels - 1);
        }

        static List<Type> GetDbContextEntityTypes<TDbContext>()
            where TDbContext : DbContext
        {
            var entityTypes = new List<Type>();
            var properties = typeof(TDbContext).GetProperties();

            foreach (var property in properties)
            {
                var setType = property.PropertyType;

                var isDbSet = setType.IsGenericType && typeof(DbSet<>).IsAssignableFrom(setType.GetGenericTypeDefinition());

                if (isDbSet)
                {
                    var entityType = setType.GetGenericArguments()[0];
                    entityTypes.Add(entityType);
                }
            }

            return entityTypes;

        }
    }

}
}
