namespace controlefinanceiro.domain.Entities
{
    public class Lancamento
    {
        public int LancamentoId { get; set; }

        public DateTime DataLancamento { get; set; }

        public int CategoriaId { get; set; }

        public decimal Valor { get; set; }

        public string? Descricao { get; set; }  
        public Categoria? Categoria { get; set; }
    }
}
