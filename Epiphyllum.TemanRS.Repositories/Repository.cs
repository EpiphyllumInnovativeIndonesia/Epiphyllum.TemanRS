using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Epiphyllum.TemanRS.Common.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Epiphyllum.TemanRS.Repositories
{
    /// <summary>
    /// Generic repository implements <see cref="IRepository{T, U}"/>
    /// </summary>
    /// <typeparam name="T">Database object.</typeparam>
    /// <typeparam name="U">Database context.</typeparam>
    public class Repository<T, U> : IRepository<T, U>
        where T : class
        where U : DbContext
    {
        private readonly DbSet<T> _dbSet;
        private readonly U _context;
        
        public Repository(U context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public virtual async Task<IEnumerable<T>> SelectAll()
        {
            IQueryable<T> dbQuery = _dbSet;
            return await dbQuery.ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> SelectAll(params Expression<Func<T, object>>[] navigationProperties)
        {
            IQueryable<T> dbQuery = _dbSet;
            dbQuery = dbQuery.Include(navigationProperties);
            return await dbQuery.ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> SelectAll(params string[] navigationProperties)
        {
            IQueryable<T> dbQuery = _dbSet;
            dbQuery = dbQuery.Include(navigationProperties);
            return await dbQuery.ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> SelectList(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> dbQuery = _dbSet;
            dbQuery = dbQuery.Where(predicate);
            return await dbQuery.ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> SelectList(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] navigationProperties)
        {
            IQueryable<T> dbQuery = _dbSet;
            dbQuery = dbQuery.Include(navigationProperties);
            dbQuery = dbQuery.Where(predicate);
            return await dbQuery.ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> SelectList(Expression<Func<T, bool>> predicate, params string[] navigationProperties)
        {
            IQueryable<T> dbQuery = _dbSet;
            dbQuery = dbQuery.Include(navigationProperties);
            dbQuery = dbQuery.Where(predicate);
            return await dbQuery.ToListAsync();
        }

        public virtual async Task<T> Select(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> dbQuery = _dbSet;
            dbQuery = dbQuery.Where(predicate);
            return await dbQuery.FirstOrDefaultAsync();
        }
        
        public virtual async Task<T> Select(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] navigationProperties)
        {
            IQueryable<T> dbQuery = _dbSet;
            dbQuery = dbQuery.Include(navigationProperties);
            dbQuery = dbQuery.Where(predicate);
            return await dbQuery.FirstOrDefaultAsync();
        }

        public virtual async Task<T> Select(Expression<Func<T, bool>> predicate, params string[] navigationProperties)
        {
            IQueryable<T> dbQuery = _dbSet;
            dbQuery = dbQuery.Include(navigationProperties);
            dbQuery = dbQuery.Where(predicate);
            return await dbQuery.FirstOrDefaultAsync();
        }

        public virtual async Task Insert(params T[] entities)
        {
            await Task.Run(() => {
                foreach (T entity in entities)
                {
                    _dbSet.Add(entity);
                }
            });
        }

        public virtual async Task Update(params T[] entities)
        {
            await Task.Run(() => {
                foreach (T entity in entities)
                {
                    _dbSet.Update(entity);
                }
            });
        }

        public virtual async Task Delete(params T[] entities)
        {
            await Task.Run(() => {
                foreach (T entity in entities)
                {
                    _dbSet.Remove(entity);
                }
            });
        }

        public virtual async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
