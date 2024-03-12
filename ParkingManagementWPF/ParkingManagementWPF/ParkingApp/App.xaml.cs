using _Repository;
using _Repository.Implements;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ParkingApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ServiceProvider serviceProvider;

        public App()
        {
            ServiceCollection services = new ServiceCollection();
            ConfigureService(services);
            serviceProvider = services.BuildServiceProvider();
        }

        private void ConfigureService(ServiceCollection services)
        {
            services.AddTransient(typeof(IUserRepository), typeof(UserRepository));
            services.AddTransient(typeof(IVehicleRepository), typeof(VehicleRepository));
            services.AddTransient(typeof(IVehicleTypeRepository), typeof(VehicleTypeRepository));
            services.AddTransient(typeof(ILotRepository), typeof(LotRepository));
            services.AddTransient(typeof(IInvoiceRepository), typeof(InvoiceRepository));
            services.AddSingleton<MainWindow>();
            services.AddSingleton<SignInUpWindow>();
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            var window = serviceProvider.GetService<SignInUpWindow>();
            window.Show();
        }
    }
}
