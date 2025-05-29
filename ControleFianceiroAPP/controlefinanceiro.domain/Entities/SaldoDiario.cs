namespace controlefinanceiro.domain.Entities
{
    public class SaldoDiario
    {
        public int SaldoDiarioId { get; set; }
        public DateTime Data { get; set; }
        public decimal SaldoInicial { get; set; }
        public decimal TotalCredito { get; set; }
        public decimal TotalDebito { get; set; } 
        public decimal SaldoFinal { get; set; }
    }
}
