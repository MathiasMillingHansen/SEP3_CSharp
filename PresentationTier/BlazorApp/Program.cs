using System.Text.Json.Serialization;
using BlazorApp.Pages;
using BlazorApp.Shared;
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

builder.Services.AddScoped<IBookService, BookHttpClient>();
builder.Services.AddScoped<Radzen.DialogService>();
builder.Services.AddScoped<EditingCard>();
builder.Services.AddScoped<CurrentlySelectedBookForSale>();
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