using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nutrifit.Domain.Entities;

namespace Nutrifit.Infra.Data.Configurators
{
    public class AlimentoConfigurator : IEntityTypeConfiguration<Alimento>
    {
        public void Configure(EntityTypeBuilder<Alimento> builder)
        {
            builder.ToTable("Alimento");

            builder.HasKey(a => a.Id);

            builder.HasOne(a => a.AlimentoIbge)
                    .WithMany()
                    .HasForeignKey(a => a.AlimentoIbgeId)
                    .HasPrincipalKey(ibge => ibge.NumeroDoAlimento)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
