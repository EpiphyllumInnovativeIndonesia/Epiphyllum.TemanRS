using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Epiphyllum.TemanRS.Models
{
    public interface IDbContext
    {
        /// <summary>
        /// Creates a DbSet that can be used to query and save instances of entity
        /// </summary>
        /// <typeparam name="T">Entity type</typeparam>
        /// <returns>A set for the given entity type</returns>
        DbSet<T> Set<T>() where T : class;

        /// <summary>
        /// Saves all changes made in this context to the database
        /// </summary>
        /// <returns>The number of state entries written to the database</returns>
        Task<int> SaveChangesAsync();
    }
}
