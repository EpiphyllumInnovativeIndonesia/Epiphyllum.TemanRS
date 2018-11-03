using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
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
        public static IQueryable<T> Include<T>(this IQueryable<T> dbQuery,
            params Expression<Func<T, object>>[] navigationProperties)
            where T : class
        {
            dbQuery = navigationProperties
                .Aggregate(dbQuery, (current, navigarionProperty) => current.Include(navigarionProperty));
            return dbQuery;
        }

        /// <summary>
        /// Includes navigation property related entity framework object.
        /// </summary>
        /// <typeparam name="T">Entity framework object.</typeparam>
        /// <param name="dbQuery">IQueryable entity framework objects.</param>
        /// <param name="navigationProperties">String params navigation property of entity framework object.</param>
        /// <returns>IQueryable<typeparamref name="T"/></returns>
        public static IQueryable<T> Include<T>(this IQueryable<T> dbQuery,
            params string[] navigationProperties)
            where T : class
        {
            dbQuery = navigationProperties
                .Aggregate(dbQuery, (current, navigarionProperty) => current.Include(navigarionProperty));
            return dbQuery;
        }
    }
}
