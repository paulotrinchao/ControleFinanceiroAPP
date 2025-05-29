using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace controlefinanceiro.infrastructure.Data
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

            // Aqui você pode usar a string de conexão direta
            optionsBuilder.UseSqlServer("Server=localhost,1433;Database=ControleFinanceiroDB;User Id=sa;Password=Arquitet0!PauloTrinchao;TrustServerCertificate=True;");

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
