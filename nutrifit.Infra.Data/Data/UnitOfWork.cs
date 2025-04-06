using nutrifit.Infra.Data.Context;
using Nutrifit.Domain.Interfaces.Infra.Data;

namespace Nutrifit.Infra.Data.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly NutrifitContext _dbcontext;

        public UnitOfWork(NutrifitContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public int Commit()
        {
            return _dbcontext.SaveChanges();
        }

        public void RollBack()
        {
            _dbcontext.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
        }
    }
}
