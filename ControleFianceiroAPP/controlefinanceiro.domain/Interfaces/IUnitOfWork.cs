namespace controlefinanceiro.domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        void BeginTransaction();
        int Commit();
        void Rollback();
    }
}
