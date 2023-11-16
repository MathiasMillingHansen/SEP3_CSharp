using BusinessWebAPI.Application.DaoImplementation;
using BusinessWebAPI.Application.DaoInterface;
using Logic.Implementations;
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
builder.Services.AddScoped<IUserDao, UserDao>();
builder.Services.AddScoped<IUserLogic, UserLogic>();

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