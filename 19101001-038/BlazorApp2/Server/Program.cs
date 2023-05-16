using BlazorApp2.Server.Data;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ContactContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultString")));

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.Host.BaseAddress) });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
}

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
