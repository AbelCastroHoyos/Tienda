//using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
//using System.Globalization;
using Tienda.Backend.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer("name=localConnection"));

// Agrega estas líneas dentro del método Main:
//builder.Services.AddLocalization();

// ... (resto de tu código)

var app = builder.Build();

//app.UseRequestLocalization(options =>
//{
//    options.DefaultRequestCulture = new RequestCulture("es-CO"); // Establece la cultura predeterminada a español de Colombia
//    options.SupportedCultures = CultureInfo.GetCultures(CultureTypes.AllCultures).ToList();
//});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
