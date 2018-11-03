using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Epiphyllum.TemanRS.Models
{
    public partial class TemanRSContext : IDbContext
    {
        /// <summary>
        /// Asynchronously saves all changes made in this context to the database.
        /// </summary>
        /// <returns>The task result contains the number of state entries written to the database.</returns>
        public virtual async Task<int> SaveChangesAsync() => await base.SaveChangesAsync();

        /// <summary>
        /// Creates a DbSet that can be used to query and save instances of entity
        /// </summary>
        /// <typeparam name="T">Entity type</typeparam>
        /// <returns>A set for the given entity type</returns>
        public new virtual DbSet<T> Set<T>() where T : class => base.Set<T>();
    }
}
