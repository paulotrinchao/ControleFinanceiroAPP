using controlefinanceiro.api;

var builder = WebApplication.CreateBuilder(args);

// Instancia a classe Startup e chama ConfigureServices
var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder.Services);

var app = builder.Build();

// Chama Configure passando app e ambiente
startup.Configure(app, app.Environment);

app.Run();