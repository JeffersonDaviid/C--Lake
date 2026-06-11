using RestAPI.Interface;
using RestAPI.services;

var builder = WebApplication.CreateBuilder(args);

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();

// Add services to the container.
// Ciclo de vida del servicio: Transient, Scoped, Singleton
builder.Services.AddScoped<ITodoService, TodoService>(); // Crea una nueva instancia cada vez que se solicita
builder.Services.AddSingleton<IProductoService, ProductoService>();  // Crea una única instancia para toda la aplicación
// builder.Services.AddTransient<IOtherService, OtherService>(); // Crea una nueva instancia cada vez que se solicita

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapControllers();


app.Run();

