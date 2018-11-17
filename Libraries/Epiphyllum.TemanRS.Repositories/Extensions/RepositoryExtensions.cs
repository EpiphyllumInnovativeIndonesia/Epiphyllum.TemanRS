using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Epiphyllum.TemanRS.Common.Data;
using Microsoft.EntityFrameworkCore;

namespace Epiphyllum.TemanRS.Repositories.Extensions
{
    /// <summary>
    /// Represents repository extensions
    /// </summary>
    public static class RepositoryExtensions
    {
        /// <summary>
        /// Includes navigation property related entity framework object
        /// </summary>
        /// <typeparam name="TEntity">Entity framework object</typeparam>
        /// <param name="entities">IQueryable entity framework objects</param>
        /// <param name="navigationProperties">Object params navigation property of entity framework object</param>
        /// <returns>IQueryable<typeparamref name="TEntity"/></returns>
        public static IQueryable<TEntity> IncludeProperties<TEntity>(this IQueryable<TEntity> entities, params Expression<Func<TEntity, object>>[] navigationProperties)
            where TEntity : BaseEntity
        {
            foreach (Expression<Func<TEntity, object>> navigationProperty in navigationProperties)
            {
                entities = entities.Include(navigationProperty);
            }
            return entities;
        }

        /// <summary>
        /// Includes navigation property related entity framework object
        /// </summary>
        /// <typeparam name="TEntity">Entity framework object</typeparam>
        /// <param name="dbQuery">IQueryable entity framework objects</param>
        /// <param name="navigationProperties">Object params navigation property of entity framework object</param>
        /// <returns>IQueryable<typeparamref name="TEntity"/></returns>
        public static IQueryable<TEntity> IncludeProperties<TEntity>(this IQueryable<TEntity> entities, params string[] navigationProperties)
            where TEntity : BaseEntity
        {
            foreach (string navigationProperty in navigationProperties)
            {
                entities = entities.Include(navigationProperty);
            }
            return entities;
        }
    }
}
