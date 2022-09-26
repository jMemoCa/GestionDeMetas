using GestionDeMetas.Bussiness.Core;
using GestionDeMetas.Bussiness.ICore;
using GestionDeMetas.Bussiness.IRepository;
using GestionDeMetas.Bussiness.Persistence;
using GestionDeMetas.Bussiness.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.


#region Servicios de la capa Repository
builder.Services.AddScoped<IMetaRepository,MetaRepository>();
builder.Services.AddScoped<IActividadRepository, ActividadRepository>();
#endregion

#region Servicios de la capa Core
builder.Services.AddScoped<IMetaCore, MetaCore>();
builder.Services.AddScoped<IActividadCore, ActividadCore>();
#endregion

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddDbContext<ApplicationDbContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("GestionDeMetas")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
