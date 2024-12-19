using System;
using System.Net.Http;
using System.Threading.Tasks;
using AntDesign.ProLayout;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace IoTGame.Practice
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.Services.AddScoped(sp => new HttpClient
            {
                BaseAddress = new Uri(builder.HostEnvironment.BaseAddress),
            });

            builder.Services.AddScoped<IoTGame.Practice.Client.Services.DatabaseService>();

            AddClientServices(builder.Services);

            builder.Services.Configure<ProSettings>(
                builder.Configuration.GetSection("ProSettings")
            );

            await builder.Build().RunAsync();
        }

        public static void AddClientServices(IServiceCollection services)
        {
            services.AddAntDesign();
        }
    }
}
