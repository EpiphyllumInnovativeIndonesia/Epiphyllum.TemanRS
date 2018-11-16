using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Epiphyllum.TemanRS.Repositories.Domain;

namespace Epiphyllum.TemanRS.Repositories
{
    /// <summary>
    /// Represents an entity repository
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    public partial interface IRepository<TEntity> where TEntity : BaseEntity
    {
        /// <summary>
        /// Gets a table
        /// </summary>
        IQueryable<TEntity> Table { get; }

        /// <summary>
        /// Gets a table with "no tracking" enabled (EF feature) Use it only when you load record(s) only for read-only operations
        /// </summary>
        IQueryable<TEntity> TableNoTracking { get; }

        /// <summary>
        /// Get all objects
        /// </summary>
        /// <returns>Task IEnumerable <typeparamref name="TEntity"/></returns>
        Task<IEnumerable<TEntity>> SelectAll();

        /// <summary>
        /// Get all objects included object navigation properties
        /// </summary>
        /// <param name="navigationProperties">Navigation properties of <typeparamref name="TEntity"/></param>
        /// <returns>Task IEnumerable <typeparamref name="TEntity"/></returns>
        Task<IEnumerable<TEntity>> SelectAll(params Expression<Func<TEntity, object>>[] navigationProperties);

        /// <summary>
        /// Get all objects included object serialized (string) navigation properties
        /// </summary>
        /// <param name="navigationProperties">Navigation properties of <typeparamref name="TEntity"/></param>
        /// <returns>Task IEnumerable <typeparamref name="TEntity"/></returns>
        Task<IEnumerable<TEntity>> SelectAll(params string[] navigationProperties);

        /// <summary>
        /// Get all objects that matches with given predicates
        /// </summary>
        /// <param name="predicate">The given predicates</param>
        /// <returns>Task IEnumerable <typeparamref name="TEntity"/></returns>
        Task<IEnumerable<TEntity>> SelectList(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Get all objects that matches with given predicates included object navigation properties
        /// </summary>
        /// <param name="predicate">The given predicates</param>
        /// <param name="navigationProperties">Navigation properties of <typeparamref name="TEntity"/></param>
        /// <returns>Task IEnumerable <typeparamref name="TEntity"/></returns>
        Task<IEnumerable<TEntity>> SelectList(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] navigationProperties);

        /// <summary>
        /// Get all objects that matches with given predicates included object serialized (string) navigation properties
        /// </summary>
        /// <param name="predicate">The given predicates</param>
        /// <param name="navigationProperties">Navigation properties of <typeparamref name="TEntity"/></param>
        /// <returns>Task IEnumerable <typeparamref name="TEntity"/></returns>
        Task<IEnumerable<TEntity>> SelectList(Expression<Func<TEntity, bool>> predicate, params string[] navigationProperties);

        /// <summary>
        /// Get single object that matches with given predicates
        /// </summary>
        /// <param name="predicate">The given predicates</param>
        /// <returns>Task IEnumerable <typeparamref name="TEntity"/></returns>
        Task<TEntity> Select(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Get single object that matches with given predicates included object navigation properties
        /// </summary>
        /// <param name="predicate">The given predicates</param>
        /// <param name="navigationProperties">Navigation properties of <typeparamref name="TEntity"/></param>
        /// <returns>Task IEnumerable <typeparamref name="TEntity"/></returns>
        Task<TEntity> Select(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] navigationProperties);

        /// <summary>
        /// Get single object that matches with given predicates included object serialized (string) navigation properties
        /// </summary>
        /// <param name="predicate">The given predicates</param>
        /// <param name="navigationProperties">Navigation properties of <typeparamref name="TEntity"/></param>
        /// <returns>Task IEnumerable <typeparamref name="TEntity"/></returns>
        Task<TEntity> Select(Expression<Func<TEntity, bool>> predicate, params string[] navigationProperties);

        /// <summary>
        /// Get entity by identifier
        /// </summary>
        /// <param name="id">Identifier</param>
        /// <returns>Task Entity</returns>
        Task<TEntity> SelectById(object id);

        /// <summary>
        /// Insert entities
        /// </summary>
        /// <param name="entities">Entities</param>
        /// <returns>Task</returns>
        Task Insert(params TEntity[] entities);

        /// <summary>
        /// Update entities
        /// </summary>
        /// <param name="entities">Entities</param>
        /// <returns>Task</returns>
        Task Update(params TEntity[] entities);

        /// <summary>
        /// Delete entities
        /// </summary>
        /// <param name="entities">Entities</param>
        /// <returns>Task</returns>
        Task Delete(params TEntity[] entities);
    }
}
