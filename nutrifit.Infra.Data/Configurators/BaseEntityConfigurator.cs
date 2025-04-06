using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using nutrifit.Domain.Entities.Base;

namespace nutrifit.Infra.Data.Configurators
{
    public abstract class BaseEntityConfigurator<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
    {

        protected abstract void InternalConfigure(EntityTypeBuilder<TEntity> builder);

        public void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(p => p.Id).IsRequired();

            InternalConfigure(builder);
        }

    }
}
