using Prometheus.Client.AspNetCore;
using Prometheus.Client.DependencyInjection;
using SimonPrinz.LTE;
using SimonPrinz.LTEMonitor.Services;

WebApplicationBuilder lBuilder = WebApplication.CreateBuilder(args);

lBuilder.Services.Configure<Config>(lBuilder.Configuration.GetSection(Config.Name));

lBuilder.Services.AddMemoryCache();
lBuilder.Services.AddScoped<Client>();

lBuilder.Services.AddMetricFactory();
lBuilder.Services.AddHostedService<PrometheusService>();

WebApplication lApp = lBuilder.Build();

lApp.UseRouting();
lApp.UsePrometheusServer(pOptions => { pOptions.UseDefaultCollectors = false; });

lApp.Run();