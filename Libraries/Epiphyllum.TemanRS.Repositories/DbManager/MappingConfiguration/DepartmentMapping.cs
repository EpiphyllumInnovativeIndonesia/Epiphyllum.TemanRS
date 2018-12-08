using Epiphyllum.TemanRS.Repositories.Entity;
using Epiphyllum.TemanRS.Repositories.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Epiphyllum.TemanRS.Repositories.DbManager.MappingConfiguration
{
    /// <summary>
    /// Represents a department mapping configuration
    /// </summary>
    public partial class DepartmentMapping : EntityTypeConfiguration<Department>
    {
        /// <summary>
        /// Add department post configuration
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        protected override void PostConfigure(EntityTypeBuilder<Department> builder)
        {
            builder.HasIndex(department => department.DepartmentCode)
                .HasName(string.Format(MappingHelpers.UniqueIndex, nameof(Department), nameof(Department.DepartmentCode)))
                .IsUnique();

            builder.HasIndex(department => department.DepartmentName)
                .HasName(string.Format(MappingHelpers.UniqueIndex, nameof(Department), nameof(Department.DepartmentName)))
                .IsUnique();
        }

        /// <summary>
        /// Configures the department entity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable(nameof(Department));

            builder.Property(department => department.DepartmentCode)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(department => department.DepartmentName)
                .IsRequired()
                .HasMaxLength(400);

            builder.Property(department => department.DepartmentDescription)
                .IsRequired()
                .HasMaxLength(400);

            PostConfigure(builder);
            base.Configure(builder);
        }
    }
}
