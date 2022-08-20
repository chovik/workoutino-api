using EnsureThat;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection;

namespace Workoutino.Api.Infrastracture.EntityFramework.Extensions
{
    public static class DbContextExtensions
    {
        static MethodInfo ContainsMethod<TKey>() => typeof(Enumerable).GetMethods()
           .FirstOrDefault(mi => mi.Name == "Contains" && mi.GetParameters().Length == 2)
           .MakeGenericMethod(typeof(TKey));

        public static Task<TEntity[]> FindAllAsync<TEntity, TKey>(
            this DbContext dbContext, IEnumerable<TKey> keyValues, CancellationToken cancellationToken) where TEntity : class
        {
            EnsureArg.IsNotNull(dbContext, nameof(dbContext));
            EnsureArg.IsNotNull(keyValues, nameof(keyValues));

            var entityType = dbContext.Model.FindEntityType(typeof(TEntity));
            var primaryKey = entityType.FindPrimaryKey();

            if (primaryKey.Properties.Count != 1)
                throw new NotSupportedException("Only a single primary key is supported");

            var pkProperty = primaryKey.Properties[0];
            var pkPropertyType = pkProperty.ClrType;

            // validate passed key values
            foreach (var keyValue in keyValues)
            {
                if (!pkPropertyType.IsInstanceOfType(keyValue))
                    throw new ArgumentException($"Key value '{keyValue}' is not of the right type");
            }

            // retrieve member info for primary key
            var pkMemberInfo = typeof(TEntity).GetProperty(pkProperty.Name);

            if (pkMemberInfo == null)
                throw new ArgumentException("Type does not contain the primary key as an accessible property");

            // build lambda expression
            var parameter = Expression.Parameter(typeof(TEntity), "e");
            var body = Expression.Call(null, ContainsMethod<TKey>(),
                Expression.Constant(keyValues),
                Expression.Convert(Expression.MakeMemberAccess(parameter, pkMemberInfo), typeof(TKey)));
            var predicateExpression = Expression.Lambda<Func<TEntity, bool>>(body, parameter);

            return dbContext.Set<TEntity>().Where(predicateExpression).ToArrayAsync(cancellationToken);
        }

    }
}
