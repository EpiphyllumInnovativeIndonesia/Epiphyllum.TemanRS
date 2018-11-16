using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Epiphyllum.TemanRS.Repositories.Data;
using Epiphyllum.TemanRS.Repositories.Domain;
using Epiphyllum.TemanRS.Repositories.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Epiphyllum.TemanRS.Repositories
{
    /// <summary>
    /// Represents the Entity Framework repository
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    public partial class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly IDbContext _context;
        private DbSet<TEntity> _entities;

        /// <summary>
        /// Gets a table
        /// </summary>
        public virtual IQueryable<TEntity> Table => _entities;

        /// <summary>
        /// Gets a table with "no tracking" enabled (EF feature) Use it only when you load record(s) only for read-only operations
        /// </summary>
        public virtual IQueryable<TEntity> TableNoTracking => _entities.AsNoTracking();

        public Repository(IDbContext context)
        {
            _context = context;
            _entities = _context.Set<TEntity>();
        }

        /// <summary>
        /// Get all objects
        /// </summary>
        /// <returns>Task IEnumerable <typeparamref name="TEntity"/></returns>
        public virtual async Task<IEnumerable<TEntity>> SelectAll()
        {
            return await TableNoTracking
                .ToListAsync();
        }

        /// <summary>
        /// Get all objects included object navigation properties
        /// </summary>
        /// <param name="navigationProperties">Navigation properties of <typeparamref name="TEntity"/></param>
        /// <returns>Task IEnumerable <typeparamref name="TEntity"/></returns>
        public virtual async Task<IEnumerable<TEntity>> SelectAll(params Expression<Func<TEntity, object>>[] navigationProperties)
        {
            return await TableNoTracking
                .IncludeProperties(navigationProperties)
                .ToListAsync();
        }

        /// <summary>
        /// Get all objects included object serialized (string) navigation properties
        /// </summary>
        /// <param name="navigationProperties">Navigation properties of <typeparamref name="TEntity"/></param>
        /// <returns>Task IEnumerable <typeparamref name="TEntity"/></returns>
        public virtual async Task<IEnumerable<TEntity>> SelectAll(params string[] navigationProperties)
        {
            return await TableNoTracking
                .IncludeProperties(navigationProperties)
                .ToListAsync();
        }

        /// <summary>
        /// Get all objects that matches with given predicates
        /// </summary>
        /// <param name="predicate">The given predicates</param>
        /// <returns>Task IEnumerable <typeparamref name="TEntity"/></returns>
        public virtual async Task<IEnumerable<TEntity>> SelectList(Expression<Func<TEntity, bool>> predicate)
        {
            return await TableNoTracking
                .Where(predicate)
                .ToListAsync();
        }

        /// <summary>
        /// Get all objects that matches with given predicates included object navigation properties
        /// </summary>
        /// <param name="predicate">The given predicates</param>
        /// <param name="navigationProperties">Navigation properties of <typeparamref name="TEntity"/></param>
        /// <returns>Task IEnumerable <typeparamref name="TEntity"/></returns>
        public virtual async Task<IEnumerable<TEntity>> SelectList(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] navigationProperties)
        {
            return await TableNoTracking
                .Where(predicate)
                .IncludeProperties(navigationProperties)
                .ToListAsync();
        }

        /// <summary>
        /// Get all objects that matches with given predicates included object serialized (string) navigation properties
        /// </summary>
        /// <param name="predicate">The given predicates</param>
        /// <param name="navigationProperties">Navigation properties of <typeparamref name="TEntity"/></param>
        /// <returns>Task IEnumerable <typeparamref name="TEntity"/></returns>
        public virtual async Task<IEnumerable<TEntity>> SelectList(Expression<Func<TEntity, bool>> predicate, params string[] navigationProperties)
        {
            return await TableNoTracking
                .Where(predicate)
                .IncludeProperties(navigationProperties)
                .ToListAsync();
        }

        /// <summary>
        /// Get single object that matches with given predicates
        /// </summary>
        /// <param name="predicate">The given predicates</param>
        /// <returns>Task IEnumerable <typeparamref name="TEntity"/></returns>
        public virtual async Task<TEntity> Select(Expression<Func<TEntity, bool>> predicate)
        {
            return await TableNoTracking
                .Where(predicate)
                .SingleOrDefaultAsync();
        }

        /// <summary>
        /// Get single object that matches with given predicates included object navigation properties
        /// </summary>
        /// <param name="predicate">The given predicates</param>
        /// <param name="navigationProperties">Navigation properties of <typeparamref name="TEntity"/></param>
        /// <returns>Task IEnumerable <typeparamref name="TEntity"/></returns>
        public virtual async Task<TEntity> Select(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] navigationProperties)
        {
            return await TableNoTracking
                .Where(predicate)
                .IncludeProperties(navigationProperties)
                .SingleOrDefaultAsync();
        }

        /// <summary>
        /// Get single object that matches with given predicates included object serialized (string) navigation properties
        /// </summary>
        /// <param name="predicate">The given predicates</param>
        /// <param name="navigationProperties">Navigation properties of <typeparamref name="TEntity"/></param>
        /// <returns>Task IEnumerable <typeparamref name="TEntity"/></returns>
        public virtual async Task<TEntity> Select(Expression<Func<TEntity, bool>> predicate, params string[] navigationProperties)
        {
            return await TableNoTracking
                .Where(predicate)
                .IncludeProperties(navigationProperties)
                .SingleOrDefaultAsync();
        }

        /// <summary>
        /// Get entity by identifier
        /// </summary>
        /// <param name="id">Identifier</param>
        /// <returns>Task Entity</returns>
        public virtual async Task<TEntity> SelectById(object id)
        {
            return await _entities.FindAsync(id);
        }

        /// <summary>
        /// Insert entities
        /// </summary>
        /// <param name="entities">Entities</param>
        /// <returns>Task</returns>
        public virtual async Task Insert(params TEntity[] entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException(nameof(entities));
            }

            try
            {
                foreach (TEntity entity in entities)
                {
                    _entities.Add(entity);
                }

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException exception)
            {
                string errorText = await GetFullErrorTextAndRollbackEntityChanges(exception);
                throw new Exception(errorText, exception);
            }
        }

        /// <summary>
        /// Update entities
        /// </summary>
        /// <param name="entities">Entities</param>
        /// <returns>Task</returns>
        public virtual async Task Update(params TEntity[] entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException(nameof(entities));
            }

            try
            {
                foreach (TEntity entity in entities)
                {
                    _entities.Update(entity);
                }

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException exception)
            {
                string errorText = await GetFullErrorTextAndRollbackEntityChanges(exception);
                throw new Exception(errorText, exception);
            }
        }

        /// <summary>
        /// Delete entities
        /// </summary>
        /// <param name="entities">Entities</param>
        /// <returns>Task</returns>
        public virtual async Task Delete(params TEntity[] entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException(nameof(entities));
            }

            try
            {
                foreach (TEntity entity in entities)
                {
                    _entities.Remove(entity);
                }

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException exception)
            {
                string errorText = await GetFullErrorTextAndRollbackEntityChanges(exception);
                throw new Exception(errorText, exception);
            }
        }

        /// <summary>
        /// Rollback of entity changes and return full error message
        /// </summary>
        /// <param name="exception">Exception</param>
        /// <returns>Error message</returns>
        protected virtual async Task<string> GetFullErrorTextAndRollbackEntityChanges(DbUpdateException exception)
        {
            if (_context is DbContext dbContext)
            {
                var entries = dbContext.ChangeTracker.Entries()
                    .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified).ToList();

                entries.ForEach(entry =>
                {
                    try
                    {
                        entry.State = EntityState.Unchanged;
                    }
                    catch (InvalidOperationException)
                    {
                    }
                });
            }

            await _context.SaveChangesAsync();
            return exception.ToString();
        }
    }
}
