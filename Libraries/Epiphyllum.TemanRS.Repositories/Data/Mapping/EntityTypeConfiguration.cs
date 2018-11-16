using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text;
using Epiphyllum.TemanRS.Repositories.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Epiphyllum.TemanRS.Repositories.Data.Mapping
{
    /// <summary>
    /// Represents base entity mapping configuration
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    public partial class EntityTypeConfiguration<TEntity> : IMappingConfiguration, IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity, IAuditable, IConcurrentable
    {
        /// <summary>
        /// Developers can override this method in custom partial classes in order to add some custom configuration code
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        protected virtual void PostConfigure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasQueryFilter(entity => !entity.IsDeleted);
        }

        /// <summary>
        /// Configures the entity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(entity => entity.Id);

            builder.Property(entity => entity.IsDeleted)
                .IsRequired()
                .HasDefaultValueSql("(0)");

            builder.Property(entity => entity.CreatedBy)
                .IsRequired()
                .HasMaxLength(400)
                .HasDefaultValueSql("('')");

            builder.Property(entity => entity.CreatedTime)
                .IsRequired()
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            builder.Property(entity => entity.ModifiedBy)
                .HasMaxLength(400);

            builder.Property(entity => entity.ModifiedTime)
                .HasColumnType("datetime");

            builder.Property(entity => entity.RowVersion)
                .IsRequired()
                .IsRowVersion();

            PostConfigure(builder);
        }

        /// <summary>
        /// Apply this mapping configuration
        /// </summary>
        /// <param name="modelBuilder">The builder being used to construct the model for the database context</param>
        public virtual void ApplyConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(this);
        }
    }
}
