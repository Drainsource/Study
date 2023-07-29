using DIDemoLib;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var builder = new HostBuilder()
                .ConfigureAppConfiguration((config) =>
                {
                    config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                })
                .ConfigureServices((_, services) =>
                {
                    services
                    .AddTransient<MainWindow>()
                    .DIDemoLib();
                });

            var host = builder.Build();

            using var scope = host.Services.CreateScope();

            var services = scope.ServiceProvider;

            try
            {
                var frm = services.GetService<MainWindow>();
                frm.Show();
            }
            catch (Exception ex)
            {

                Console.WriteLine($"An erro has occured: { ex.Message }");
            }
        }
    }
}
