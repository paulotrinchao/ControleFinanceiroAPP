using controlefinanceiro.domain.Entities;
using controlefinanceiro.domain.Interfaces;
using controlefinanceiro.infrastructure.Data;

namespace controlefinanceiro.infrastructure.Repository
{
    public class CategoriaRepository(AppDbContext context) : Repository<Categoria>(context), ICategoriaRepository
    {
    }

}
