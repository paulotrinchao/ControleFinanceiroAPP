using controlefinanceiro.domain.Entities;
using controlefinanceiro.domain.Interfaces;
using controlefinanceiro.infrastructure.Data;

namespace controlefinanceiro.infrastructure.Repository
{
    public class SaldoDiarioRepository(AppDbContext context) : Repository<SaldoDiario>(context), ISaldoDiarioRepository
    {
    }
}
