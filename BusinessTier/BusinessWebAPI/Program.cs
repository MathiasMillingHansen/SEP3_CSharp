using Application.Logic;
using BusinessWebAPI.Application.DaoImplementation;
using BusinessWebAPI.Application.DaoInterface;
using Logic.Interfaces;
using RabbitMQ;


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
builder.Services.AddScoped<ISellDao, SellDao>();
builder.Services.AddScoped<ISellLogic, SellLogic>();
builder.Services.AddScoped<ICatalogLogic, CatalogLogic>();
builder.Services.AddScoped<ICatalogDao, CatalogDao>();
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.IncludeFields = true;
});

var app = builder.Build();

app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true) // allow any origin
    .AllowCredentials());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//Task.Run(BusinessConsumer.Main);

app.Run();

