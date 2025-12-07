using Mecanica.NET;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// AGREGAR: Registro del servicio CORS
builder.Services.AddCors();

var cn = builder.Configuration.GetConnectionString("cn");
builder.Services.AddDbContext<AngularDbContext>(options =>
  options.UseMySql(cn, ServerVersion.AutoDetect(cn)));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configuración del Pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// MOVER: HttpsRedirection y CORS
//app.UseHttpsRedirection();

// AHORA FUNCIONARÁ: Definición y uso del CORS (colocado antes de UseAuthorization)
app.UseCors(x => x
  .AllowAnyOrigin()
  .AllowAnyMethod()
  .AllowAnyHeader());

app.UseAuthorization();

app.MapControllers();

app.Run();