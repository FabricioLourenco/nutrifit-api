using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nutrifit.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

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
                .HasForeignKey(a => a.CodigoIBGE)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
