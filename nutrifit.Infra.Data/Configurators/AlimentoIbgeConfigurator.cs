using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nutrifit.Domain.Entities;

namespace Nutrifit.Infra.Data.Configurators
{
    public class AlimentoIbgeConfigurator : IEntityTypeConfiguration<AlimentoIbge>
    {
        public void Configure(EntityTypeBuilder<AlimentoIbge> builder)
        {

            builder.ToTable("AlimentoIbge");

            builder.HasKey(x => x.NumeroDoAlimento);

            builder.Property(p => p.NumeroDoAlimento).IsRequired();
        }
    }
}
