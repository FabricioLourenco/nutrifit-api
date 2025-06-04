using Microsoft.EntityFrameworkCore;
using Nutrifit.Domain.Entities;
using System.Reflection;

namespace nutrifit.Infra.Data.Context
{
    public class NutrifitContext : DbContext
    {
        public NutrifitContext(DbContextOptions<NutrifitContext> options) : base (options) 
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        #region DbSets

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Nutricionista> Nutricionista { get; set; }
        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<PlanoAlimentar> PlanoAlimentar { get; set; }
        public DbSet<Refeicao> Refeicao { get; set; }
        public DbSet<Alimento> Alimento { get; set; }
        public DbSet<ItemRefeicao> ItemRefeicao { get; set; }
        public DbSet<EvolucaoPaciente> EvolucaoPaciente { get; set; }
        public DbSet<ComentarioPaciente> ComentarioPaciente { get; set; }
        public DbSet<Consulta> Consulta { get; set; }
        public DbSet<AlimentoIbge> AlimentoIbge { get; set; }

        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
