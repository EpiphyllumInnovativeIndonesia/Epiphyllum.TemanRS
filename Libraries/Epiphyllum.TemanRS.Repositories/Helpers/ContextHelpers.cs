using System;
using System.Linq;
using Epiphyllum.TemanRS.Core;
using Epiphyllum.TemanRS.Core.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Epiphyllum.TemanRS.Repositories.Helpers
{
    /// <summary>
    /// Represents context helpers
    /// </summary>
    public static partial class ContextHelpers
    {
        /// <summary>
        /// Audit db context
        /// </summary>
        /// <param name="context">DbContext</param>
        public static void Audit(DbContext context)
        {
            var currentUsername = EngineContext.Current.UserManager.Username;
            var auditEntries = context.ChangeTracker.Entries()
                .Where(entry => entry.State == EntityState.Added || entry.State == EntityState.Modified || entry.State == EntityState.Deleted);

            foreach (var auditEntry in auditEntries)
            {
                try
                {
                    if (auditEntry.State == EntityState.Added)
                    {
                        auditEntry.CurrentValues[nameof(IAuditable.CreatedBy)] = currentUsername;
                        auditEntry.CurrentValues[nameof(IAuditable.CreatedTime)] = DateTime.Now;
                    }
                    else if (auditEntry.State == EntityState.Modified)
                    {
                        auditEntry.CurrentValues[nameof(IAuditable.ModifiedBy)] = currentUsername ?? auditEntry.CurrentValues[nameof(IAuditable.ModifiedBy)];
                        auditEntry.CurrentValues[nameof(IAuditable.ModifiedTime)] = DateTime.Now;
                    }
                    else if (auditEntry.State == EntityState.Deleted)
                    {
                        var uniqueIndexProperties = auditEntry.OriginalValues.Properties.Where(prop => prop.IsIndex());
                        var primaryKeyProperty = auditEntry.OriginalValues.Properties.Where(prop => prop.IsPrimaryKey()).SingleOrDefault();
                        var deletedKeyProperty = auditEntry.OriginalValues.Properties.Where(prop => prop.Name.Equals(nameof(IAuditable.IsDeleted))).SingleOrDefault();
                        var primaryKeyValue = auditEntry.OriginalValues[primaryKeyProperty];

                        foreach (var uniqueIndexProperty in uniqueIndexProperties)
                        {
                            var originalUniqueIndexValue = auditEntry.OriginalValues[uniqueIndexProperty];
                            auditEntry.CurrentValues[uniqueIndexProperty] = $"{originalUniqueIndexValue}-{primaryKeyValue}-{EntityState.Deleted.ToString()}";
                        }

                        auditEntry.CurrentValues[deletedKeyProperty] = true;
                        auditEntry.CurrentValues[nameof(IAuditable.ModifiedBy)] = currentUsername;
                        auditEntry.CurrentValues[nameof(IAuditable.ModifiedTime)] = DateTime.Now;
                        auditEntry.State = EntityState.Modified;
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
