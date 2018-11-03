using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Epiphyllum.TemanRS.Common.Helpers;
using Epiphyllum.TemanRS.Models;
using Microsoft.EntityFrameworkCore;

namespace Epiphyllum.TemanRS.Repositories
{
    /// <summary>
    /// Generic repository implements <see cref="IRepository{T}"/>
    /// </summary>
    /// <typeparam name="T">Database object.</typeparam>
    public class Repository<T> : IRepository<T>
        where T : class
    {
        /// <summary>
        /// An object that obtained from <see cref="DbContext.Set{TEntity}"/> method.
        /// See also <seealso cref="DbSet{TEntity}"/> object.
        /// </summary>
        protected readonly DbSet<T> _dbSet;

        /// <summary>
        /// An instance represent the database.
        /// See also <seealso cref="DbContext"/>.
        /// </summary>
        protected readonly IDbContext _context;

        /// <summary>
        /// Gets a table
        /// </summary>
        public virtual IQueryable<T> Table => _dbSet;

        /// <summary>
        /// Gets a table with "no tracking" enabled (EF feature) Use it only when you load record(s) only for read-only operations
        /// </summary>
        public virtual IQueryable<T> TableNoTracking => _dbSet.AsNoTracking();

        /// <summary>
        /// A constructor that assign value of <see cref="_context"/> and <see cref="_dbSet"/> from <see cref="DbContext"/>.
        /// </summary>
        /// <param name="context"></param>
        public Repository(IDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        /// <summary>
        /// Select all objects.
        /// </summary>
        /// <returns>Task IEnumerable <typeparamref name="T"/>.</returns>
        public virtual async Task<IEnumerable<T>> SelectAll()
        {
            IQueryable<T> dbQuery = _dbSet;
            return await dbQuery.ToListAsync();
        }

        /// <summary>
        /// Select all objects included object navigation properties.
        /// </summary>
        /// <param name="navigationProperties">Navigation properties of <typeparamref name="T"/>.</param>
        /// <returns>Task IEnumerable <typeparamref name="T"/>.</returns>
        public virtual async Task<IEnumerable<T>> SelectAll(params Expression<Func<T, object>>[] navigationProperties)
        {
            IQueryable<T> dbQuery = _dbSet;
            dbQuery = dbQuery.IncludeProperties(navigationProperties);
            return await dbQuery.ToListAsync();
        }

        /// <summary>
        /// Select all objects included object serialized (string) navigation properties.
        /// </summary>
        /// <param name="navigationProperties">Navigation properties of <typeparamref name="T"/>.</param>
        /// <returns>Task IEnumerable <typeparamref name="T"/>.</returns>
        public virtual async Task<IEnumerable<T>> SelectAll(params string[] navigationProperties)
        {
            IQueryable<T> dbQuery = _dbSet;
            dbQuery = dbQuery.IncludeProperties(navigationProperties);
            return await dbQuery.ToListAsync();
        }

        /// <summary>
        /// Select all objects that matches with given predicates.
        /// </summary>
        /// <param name="predicate">The given predicates.</param>
        /// <returns>Task IEnumerable <typeparamref name="T"/>.</returns>
        public virtual async Task<IEnumerable<T>> SelectList(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> dbQuery = _dbSet;
            dbQuery = dbQuery.Where(predicate);
            return await dbQuery.ToListAsync();
        }

        /// <summary>
        /// Select all objects that matches with given predicates included object navigation properties.
        /// </summary>
        /// <param name="predicate">The given predicates.</param>
        /// <param name="navigationProperties">Navigation properties of <typeparamref name="T"/>.</param>
        /// <returns>Task IEnumerable <typeparamref name="T"/>.</returns>
        public virtual async Task<IEnumerable<T>> SelectList(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] navigationProperties)
        {
            IQueryable<T> dbQuery = _dbSet;
            dbQuery = dbQuery.IncludeProperties(navigationProperties);
            dbQuery = dbQuery.Where(predicate);
            return await dbQuery.ToListAsync();
        }

        /// <summary>
        /// Select all objects that matches with given predicates included object serialized (string) navigation properties.
        /// </summary>
        /// <param name="predicate">The given predicates.</param>
        /// <param name="navigationProperties">Navigation properties of <typeparamref name="T"/>.</param>
        /// <returns>Task IEnumerable <typeparamref name="T"/>.</returns>
        public virtual async Task<IEnumerable<T>> SelectList(Expression<Func<T, bool>> predicate, params string[] navigationProperties)
        {
            IQueryable<T> dbQuery = _dbSet;
            dbQuery = dbQuery.IncludeProperties(navigationProperties);
            dbQuery = dbQuery.Where(predicate);
            return await dbQuery.ToListAsync();
        }

        /// <summary>
        /// Select single object that matches with given predicates.
        /// </summary>
        /// <param name="predicate">The given predicates.</param>
        /// <returns>Task IEnumerable <typeparamref name="T"/>.</returns>
        public virtual async Task<T> Select(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> dbQuery = _dbSet;
            dbQuery = dbQuery.Where(predicate);
            return await dbQuery.FirstOrDefaultAsync();
        }

        /// <summary>
        /// Select single object that matches with given predicates included object navigation properties.
        /// </summary>
        /// <param name="predicate">The given predicates.</param>
        /// <param name="navigationProperties">Navigation properties of <typeparamref name="T"/>.</param>
        /// <returns>Task IEnumerable <typeparamref name="T"/>.</returns>
        public virtual async Task<T> Select(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] navigationProperties)
        {
            IQueryable<T> dbQuery = _dbSet;
            dbQuery = dbQuery.IncludeProperties(navigationProperties);
            dbQuery = dbQuery.Where(predicate);
            return await dbQuery.FirstOrDefaultAsync();
        }

        /// <summary>
        /// Select single object that matches with given predicates included object serialized (string) navigation properties.
        /// </summary>
        /// <param name="predicate">The given predicates.</param>
        /// <param name="navigationProperties">Navigation properties of <typeparamref name="T"/>.</param>
        /// <returns>Task IEnumerable <typeparamref name="T"/>.</returns>
        public virtual async Task<T> Select(Expression<Func<T, bool>> predicate, params string[] navigationProperties)
        {
            IQueryable<T> dbQuery = _dbSet;
            dbQuery = dbQuery.IncludeProperties(navigationProperties);
            dbQuery = dbQuery.Where(predicate);
            return await dbQuery.FirstOrDefaultAsync();
        }

        /// <summary>
        /// Insert <typeparamref name="T"/> objects.
        /// </summary>
        /// <param name="objects"><typeparamref name="T"/> object params.</param>
        /// <returns>Task</returns>
        public virtual async Task Insert(params T[] entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException(nameof(entities));
            }

            try
            {
                foreach (T entity in entities)
                {
                    _dbSet.Add(entity);
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
        /// Update <typeparamref name="T"/> objects.
        /// </summary>
        /// <param name="objects"><typeparamref name="T"/> object params.</param>
        /// <returns>Task</returns>
        public virtual async Task Update(params T[] entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException(nameof(entities));
            }

            try
            {
                foreach (T entity in entities)
                {
                    _dbSet.Update(entity);
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
        /// Delete <typeparamref name="T"/> objects.
        /// </summary>
        /// <param name="objects"><typeparamref name="T"/> object params.</param>
        /// <returns>Task</returns>
        public virtual async Task Delete(params T[] entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException(nameof(entities));
            }

            try
            {
                foreach (T entity in entities)
                {
                    _dbSet.Remove(entity);
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
        /// Rollback of objects changes and return full error message
        /// </summary>
        /// <param name="exception">Exception</param>
        /// <returns>Error message</returns>
        protected virtual async Task<string> GetFullErrorTextAndRollbackEntityChanges(DbUpdateException exception)
        {
            if (_context is DbContext dbContext)
            {
                var entries = dbContext.ChangeTracker.Entries()
                    .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified).ToList();

                entries.ForEach(entry => entry.State = EntityState.Unchanged);
            }

            await _context.SaveChangesAsync();
            return exception.ToString();
        }
    }
}
