using GestionDeMetas.Client;
using GestionDeMetas.Client.Helpers.Implementation;
using GestionDeMetas.Client.Helpers.Interface;
using GestionDeMetas.Client.Services.Implementation;
using GestionDeMetas.Client.Services.Interface;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

#region Mapeo de servicios
builder.Services.AddTransient<IMeta, Meta>();
builder.Services.AddTransient<IActividad, Actividad>();
builder.Services.AddTransient<IEventos, Eventos>();


builder.Services.AddScoped<ContextMenuService>();
builder.Services.AddScoped<TooltipService>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<DialogService>();
#endregion



await builder.Build().RunAsync();
