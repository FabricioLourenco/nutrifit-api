using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nutrifit.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutrifit.Infra.Data.Configurators
{
    public class AlimentoIbgeConfigurator : IEntityTypeConfiguration<AlimentoIbge>
    {
        public void Configure(EntityTypeBuilder<AlimentoIbge> builder)
        {

            builder.ToTable("AlimentoIbge");

            builder.HasKey(x => x.Codigo);

            builder.Property(p => p.Codigo).IsRequired();
        }
    }
}
