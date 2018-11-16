using System;
using System.Collections.Generic;
using System.Text;
using Epiphyllum.TemanRS.Repositories.Domain.Accounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Epiphyllum.TemanRS.Repositories.Data.Mapping.Accounts
{
    /// <summary>
    /// Represents a role mapping configuration
    /// </summary>
    public partial class RoleMapping : EntityTypeConfiguration<Role>
    {
        /// <summary>
        /// Add role post configuration
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        protected override void PostConfigure(EntityTypeBuilder<Role> builder)
        {
            builder.HasIndex(role => role.RoleCode)
                .HasName(string.Format(MappingDefault.UniqueIndex, nameof(Role), nameof(Role.RoleCode)))
                .IsUnique();

            builder.HasIndex(role => role.RoleName)
                .HasName(string.Format(MappingDefault.UniqueIndex, nameof(Role), nameof(Role.RoleName)))
                .IsUnique();
        }

        /// <summary>
        /// Configures the role entity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable(nameof(Role));

            builder.Property(role => role.RoleCode)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(role => role.RoleName)
                .IsRequired()
                .HasMaxLength(400);

            builder.Property(role => role.RoleDescription)
                .IsRequired()
                .HasMaxLength(400);

            builder.HasMany(role => role.UserRoles)
                .WithOne()
                .HasForeignKey(userRole => userRole.RoleId);

            PostConfigure(builder);
            base.Configure(builder);
        }
    }
}
