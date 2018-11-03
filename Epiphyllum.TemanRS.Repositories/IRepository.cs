using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Epiphyllum.TemanRS.Repositories
{
    /// <summary>
    /// Generic repository interface.
    /// </summary>
    /// <typeparam name="T">Database object.</typeparam>
    public interface IRepository<T>
        where T : class
    {
        /// <summary>
        /// Gets a table
        /// </summary>
        IQueryable<T> Table { get; }

        /// <summary>
        /// Gets a table with "no tracking" enabled (EF feature) Use it only when you load record(s) only for read-only operations
        /// </summary>
        IQueryable<T> TableNoTracking { get; }

        /// <summary>
        /// Select all objects.
        /// </summary>
        /// <returns>Task IEnumerable <typeparamref name="T"/>.</returns>
        Task<IEnumerable<T>> SelectAll();

        /// <summary>
        /// Select all objects included object navigation properties.
        /// </summary>
        /// <param name="navigationProperties">Navigation properties of <typeparamref name="T"/>.</param>
        /// <returns>Task IEnumerable <typeparamref name="T"/>.</returns>
        Task<IEnumerable<T>> SelectAll(params Expression<Func<T, object>>[] navigationProperties);

        /// <summary>
        /// Select all objects included object serialized (string) navigation properties.
        /// </summary>
        /// <param name="navigationProperties">Navigation properties of <typeparamref name="T"/>.</param>
        /// <returns>Task IEnumerable <typeparamref name="T"/>.</returns>
        Task<IEnumerable<T>> SelectAll(params string[] navigationProperties);

        /// <summary>
        /// Select all objects that matches with given predicates.
        /// </summary>
        /// <param name="predicate">The given predicates.</param>
        /// <returns>Task IEnumerable <typeparamref name="T"/>.</returns>
        Task<IEnumerable<T>> SelectList(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Select all objects that matches with given predicates included object navigation properties.
        /// </summary>
        /// <param name="predicate">The given predicates.</param>
        /// <param name="navigationProperties">Navigation properties of <typeparamref name="T"/>.</param>
        /// <returns>Task IEnumerable <typeparamref name="T"/>.</returns>
        Task<IEnumerable<T>> SelectList(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] navigationProperties);

        /// <summary>
        /// Select all objects that matches with given predicates included object serialized (string) navigation properties.
        /// </summary>
        /// <param name="predicate">The given predicates.</param>
        /// <param name="navigationProperties">Navigation properties of <typeparamref name="T"/>.</param>
        /// <returns>Task IEnumerable <typeparamref name="T"/>.</returns>
        Task<IEnumerable<T>> SelectList(Expression<Func<T, bool>> predicate, params string[] navigationProperties);

        /// <summary>
        /// Select single object that matches with given predicates.
        /// </summary>
        /// <param name="predicate">The given predicates.</param>
        /// <returns>Task IEnumerable <typeparamref name="T"/>.</returns>
        Task<T> Select(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Select single object that matches with given predicates included object navigation properties.
        /// </summary>
        /// <param name="predicate">The given predicates.</param>
        /// <param name="navigationProperties">Navigation properties of <typeparamref name="T"/>.</param>
        /// <returns>Task IEnumerable <typeparamref name="T"/>.</returns>
        Task<T> Select(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] navigationProperties);

        /// <summary>
        /// Select single object that matches with given predicates included object serialized (string) navigation properties.
        /// </summary>
        /// <param name="predicate">The given predicates.</param>
        /// <param name="navigationProperties">Navigation properties of <typeparamref name="T"/>.</param>
        /// <returns>Task IEnumerable <typeparamref name="T"/>.</returns>
        Task<T> Select(Expression<Func<T, bool>> predicate, params string[] navigationProperties);

        /// <summary>
        /// Insert <typeparamref name="T"/> objects.
        /// </summary>
        /// <param name="objects"><typeparamref name="T"/> object params.</param>
        /// <returns>Task</returns>
        Task Insert(params T[] objects);

        /// <summary>
        /// Update <typeparamref name="T"/> objects.
        /// </summary>
        /// <param name="objects"><typeparamref name="T"/> object params.</param>
        /// <returns>Task</returns>
        Task Update(params T[] objects);

        /// <summary>
        /// Delete <typeparamref name="T"/> objects.
        /// </summary>
        /// <param name="objects"><typeparamref name="T"/> object params.</param>
        /// <returns>Task</returns>
        Task Delete(params T[] objects);
    }
}
