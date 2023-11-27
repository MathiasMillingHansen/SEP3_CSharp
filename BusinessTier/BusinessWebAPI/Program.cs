using Application.Logic;
using BusinessWebAPI.Application.DaoImplementation;
using BusinessWebAPI.Application.DaoInterface;
using Logic.Interface;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped(
    sp => new HttpClient
    {
        BaseAddress = new Uri("https://localhost:7129/")
    });
builder.Services.AddScoped<IBookDao, BookDao>();
builder.Services.AddScoped<IBookLogic, BookLogic>();

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