using System.Text.Json.Serialization;
using HttpClients.ClientInterfaces;
using HttpClients.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped(
    sp => 
        new HttpClient { 
            BaseAddress = new Uri("https://localhost:7259"),
            Timeout = TimeSpan.FromMinutes(3)
        }
);

builder.Services.AddHttpClient("UserHttpClient", c =>
{
    c.BaseAddress = new Uri("http://localhost:8080");
    c.Timeout = TimeSpan.FromMinutes(3);
});

builder.Services.AddScoped<IBookService, BookHttpClient>();
builder.Services.AddScoped<IUserService, UserHttpClient>();
var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();