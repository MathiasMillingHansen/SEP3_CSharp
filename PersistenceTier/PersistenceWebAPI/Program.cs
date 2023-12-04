using System.Text.Json;
using System.Text.Json.Serialization;
using Application.Logic;
using EFC_DataAccess;
using EFC_DataAccess.DAOs;
using Logic.Interfaces;
using Logic.LogicImplemtation;
using Logic.LogicInterface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<DatabaseContext>();
builder.Services.AddScoped<IEfcBookDao, EfcBookDao>();
builder.Services.AddScoped<ISellLogic, SellLogic>();
builder.Services.AddScoped<IEfcBookForSaleDao, EfcBookForSaleDao>();
builder.Services.AddScoped<ICatalogLogic, CatalogLogic>();

builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    });

var app = builder.Build();


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