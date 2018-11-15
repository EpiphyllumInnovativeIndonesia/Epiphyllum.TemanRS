using System;
using System.Collections.Generic;
using System.Text;
using Epiphyllum.TemanRS.Repositories.Data.Mapping;
using Epiphyllum.TemanRS.Repositories.Domain.Departments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Epiphyllum.TemanRS.Repositories.Data.Seeding
{
    /// <summary>
    /// Represents a department mapping configuration
    /// </summary>
    public partial class DepartmentMapping : EntityTypeConfiguration<Department>
    {
        /// <summary>
        /// Configures the department entity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasData(
                new { Id = 1, DepartmentCode = "DEP0001", DepartmentName = "SEED DEPARTMENT 1", DepartmentDescription = "SEED DEPARTMENT 1", IsDeleted = false, CreatedBy = "MIGRATION", CreatedTime = DateTime.Now, RowVersion = new byte[1] },
                new { Id = 2, DepartmentCode = "DEP0002", DepartmentName = "SEED DEPARTMENT 2", DepartmentDescription = "SEED DEPARTMENT 2", IsDeleted = false, CreatedBy = "MIGRATION", CreatedTime = DateTime.Now, RowVersion = new byte[1] },
                new { Id = 3, DepartmentCode = "DEP0003", DepartmentName = "SEED DEPARTMENT 3", DepartmentDescription = "SEED DEPARTMENT 3", IsDeleted = false, CreatedBy = "MIGRATION", CreatedTime = DateTime.Now, RowVersion = new byte[1] },
                new { Id = 4, DepartmentCode = "DEP0004", DepartmentName = "SEED DEPARTMENT 4", DepartmentDescription = "SEED DEPARTMENT 4", IsDeleted = false, CreatedBy = "MIGRATION", CreatedTime = DateTime.Now, RowVersion = new byte[1] },
                new { Id = 5, DepartmentCode = "DEP0005", DepartmentName = "SEED DEPARTMENT 5", DepartmentDescription = "SEED DEPARTMENT 5", IsDeleted = false, CreatedBy = "MIGRATION", CreatedTime = DateTime.Now, RowVersion = new byte[1] }
                );

            base.Configure(builder);
        }
    }
}
