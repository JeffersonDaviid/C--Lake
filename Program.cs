using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using RestAPI.Interface;
using RestAPI.services;

var builder = WebApplication.CreateBuilder(args);

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();

// JWT - Leer Configuracion
var jwtSettings = builder.Configuration.GetSection("Jwt");
var secretKey = jwtSettings.GetValue<string>("key");
// JWT - Registrar el servicio no significa que ya funciona
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            // EMISOR
            ValidateIssuer = true, // Revisar quien creo
            ValidIssuer = jwtSettings.GetValue<string>("Issuer"), // Solo creado de este servidor

            // AUDIENCIA
            ValidateAudience = true, // Revisar para quien es
            ValidAudience = jwtSettings.GetValue<string>("Audience"), // Solo destinataroio valido (token for web, movil, ...)

            // Verifica la fecha de expiracion
            ValidateLifetime = true,

            // FIRMA CRIPTOGRAFICA
            ValidateIssuerSigningKey = true, // Verificar matematicamente si fue alterado
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)) // Key para encriptar en Bytes
        };
    });

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

// EL ORDEN IMPORTA
app.UseAuthentication(); // Verificar quien eres
app.UseAuthorization(); // Verificar si tiene permisos
app.MapControllers(); // Mapear los controladores|rutas


app.Run();

