namespace Nutrifit.Domain.Interfaces.Infra.Data
{
    public interface IUnitOfWork
    {
        int Commit();
        void RollBack();
    }
}
