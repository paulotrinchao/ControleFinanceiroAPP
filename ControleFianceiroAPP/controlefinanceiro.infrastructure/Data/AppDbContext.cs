using controlefinanceiro.domain.Entities;
using controlefinanceiro.domain.Enuns;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace controlefinanceiro.infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Categoria> Categorias { get; set; } = null!;
        public DbSet<Lancamento> Lancamentos { get; set; } = null!;
        public DbSet<SaldoDiario> SaldosDiarios { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.CategoriaId);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(100);

                var converter = new ValueConverter<TipoLancamento, char>(
                    v => (char)v,
                    v => (TipoLancamento)v
                );

                entity.Property(e => e.Tipo)
                    .HasConversion(converter)
                    .HasMaxLength(1)
                    .IsRequired();
            });

        
            modelBuilder.Entity<Lancamento>(entity =>
            {
                entity.HasKey(e => e.LancamentoId);

                entity.Property(e => e.DataLancamento)
                    .IsRequired();

                entity.Property(e => e.Valor)
                    .HasColumnType("decimal(12,2)")
                    .IsRequired();

                entity.Property(e => e.Descricao)
                    .HasMaxLength(255);

                entity.HasOne(e => e.Categoria)
                    .WithMany()
                    .HasForeignKey(e => e.CategoriaId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

         
            modelBuilder.Entity<SaldoDiario>(entity =>
            {
                entity.HasKey(e => e.SaldoDiarioId);

                entity.HasIndex(e => e.Data).IsUnique();

                entity.Property(e => e.Data)
                    .IsRequired();

                entity.Property(e => e.SaldoInicial)
                    .HasColumnType("decimal(12,2)")
                    .IsRequired();

                entity.Property(e => e.TotalCredito)
                    .HasColumnType("decimal(12,2)")
                    .IsRequired();

                entity.Property(e => e.TotalDebito)
                    .HasColumnType("decimal(12,2)")
                    .IsRequired();

                entity.Ignore(e => e.SaldoFinal);
            });
        }
    }
}
