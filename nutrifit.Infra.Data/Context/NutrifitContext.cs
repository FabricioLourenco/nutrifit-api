using Microsoft.EntityFrameworkCore;
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
        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
