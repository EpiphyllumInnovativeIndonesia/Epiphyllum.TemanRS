using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Epiphyllum.TemanRS.Common.Helpers
{
    /// <summary>
    /// Queryable helpers static class
    /// </summary>
    public static class QueryableHelpers
    {
        /// <summary>
        /// Includes navigation property related entity framework object.
        /// </summary>
        /// <typeparam name="T">Entity framework object.</typeparam>
        /// <param name="dbQuery">IQueryable entity framework objects.</param>
        /// <param name="navigationProperties">Object params navigation property of entity framework object.</param>
        /// <returns>IQueryable<typeparamref name="T"/></returns>
        public static IQueryable<T> IncludeProperties<T>(this IQueryable<T> dbQuery,
            params Expression<Func<T, object>>[] navigationProperties)
            where T : class
        {
            foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
            {
                dbQuery = dbQuery.Include(navigationProperty);
            }
            return dbQuery;
        }

        /// <summary>
        /// Includes navigation property related entity framework object.
        /// </summary>
        /// <typeparam name="T">Entity framework object.</typeparam>
        /// <param name="dbQuery">IQueryable entity framework objects.</param>
        /// <param name="navigationProperties">String params navigation property of entity framework object.</param>
        /// <returns>IQueryable<typeparamref name="T"/></returns>
        public static IQueryable<T> IncludeProperties<T>(this IQueryable<T> dbQuery,
            params string[] navigationProperties)
            where T : class
        {
            foreach (string navigationProperty in navigationProperties)
            {
                dbQuery = dbQuery.Include(navigationProperty);
            }
            return dbQuery;
        }
    }
}
