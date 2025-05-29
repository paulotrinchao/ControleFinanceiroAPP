using controlefinanceiro.domain.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;

namespace controlefinanceiro.infrastructure.Data
{
    public class UnitOfWork(AppDbContext context) : IUnitOfWork
    {
        private readonly AppDbContext _context = context;
        private IDbContextTransaction? _transaction;

        public void BeginTransaction()
        {
            _transaction = _context.Database.BeginTransaction();
        }

        public int Commit()
        {
            try
            {
                var result = _context.SaveChanges();
                _transaction?.Commit();
                return result;
            }
            catch
            {
                _transaction?.Rollback();
                throw;
            }
            finally
            {
                _transaction?.Dispose();
                _transaction = null;
            }
        }

        public void Rollback()
        {
            _transaction?.Rollback();
            _transaction?.Dispose();
            _transaction = null;
        }

        public void Dispose()
        {
            _transaction?.Dispose();
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
