using controlefinanceiro.domain.Enuns;

namespace controlefinanceiro.domain.Entities
{
    public class Categoria
    {
        public int CategoriaId { get; set; }
        public string Nome { get; set; } = null!;       
        public TipoLancamento Tipo { get; set; }
    }
}
