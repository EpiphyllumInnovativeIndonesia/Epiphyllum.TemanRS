using Epiphyllum.TemanRS.Repositories.Entity;
using Epiphyllum.TemanRS.Repositories.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Epiphyllum.TemanRS.Repositories.DbManager.MappingConfiguration
{
    /// <summary>
    /// Represents a user mapping configuration
    /// </summary>
    public partial class UserMapping : EntityTypeConfiguration<User>
    {
        /// <summary>
        /// Add user post configuration
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        protected override void PostConfigure(EntityTypeBuilder<User> builder)
        {
            builder.HasIndex(user => user.Username)
                .HasName(string.Format(MappingHelpers.UniqueIndex, nameof(User), nameof(User.Username)))
                .IsUnique();
        }

        /// <summary>
        /// Configures the user entity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(nameof(User));

            builder.Property(user => user.Username)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(user => user.Password)
                .IsRequired()
                .HasMaxLength(400);

            builder.HasMany(user => user.UserRoles)
                .WithOne()
                .HasForeignKey(userRole => userRole.UserId);

            PostConfigure(builder);
            base.Configure(builder);
        }
    }
}
