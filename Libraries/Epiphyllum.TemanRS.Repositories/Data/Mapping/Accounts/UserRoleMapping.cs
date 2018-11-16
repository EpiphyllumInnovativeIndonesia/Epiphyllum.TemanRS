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
    public partial class UserRoleMapping : EntityTypeConfiguration<UserRole>
    {
        /// <summary>
        /// Add role post configuration
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        protected override void PostConfigure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasIndex(userRole => userRole.UserId)
                .HasName(string.Format(MappingDefault.Index, nameof(UserRole), nameof(UserRole.UserId)));

            builder.HasIndex(userRole => userRole.RoleId)
                .HasName(string.Format(MappingDefault.Index, nameof(UserRole), nameof(UserRole.RoleId)));
        }

        /// <summary>
        /// Configures the role entity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.ToTable(nameof(UserRole));

            builder.HasOne(userRole => userRole.User)
                .WithMany(user => user.UserRoles)
                .HasForeignKey(userRole => userRole.UserId);

            builder.HasOne(userRole => userRole.Role)
                .WithMany(role => role.UserRoles)
                .HasForeignKey(userRole => userRole.RoleId);

            PostConfigure(builder);
            base.Configure(builder);
        }
    }
}
