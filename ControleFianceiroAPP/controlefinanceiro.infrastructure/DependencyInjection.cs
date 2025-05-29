using controlefinanceiro.domain.Interfaces;

using controlefinanceiro.infrastructure.Data;
using controlefinanceiro.infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace controlefinanceiro.infrastructure
{
    public static class DependencyInjection
    {
        private static void InjectRepositories(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<ILancamentoRepository, LancamentoRepository>();
            services.AddScoped<ISaldoDiarioRepository, SaldoDiarioRepository>();
        }

        public static IServiceCollection AddSqlServer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                            sqlOptions => sqlOptions.EnableRetryOnFailure()));

            InjectRepositories(services);

            return services;
        }

        public static IServiceCollection AddDBImemory(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseInMemoryDatabase("ControleFinanceiroDB"));
            InjectRepositories(services);
            return services;
        }

    }
}
