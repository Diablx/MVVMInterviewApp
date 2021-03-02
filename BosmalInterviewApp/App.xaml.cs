using BosmalInterviewApp.Logic.PeopleRepository;
using BosmalInterviewApp.ViewModels;
using BosmalInterviewApp.Views;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace BosmalInterviewApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IServiceProvider serviceProvider { get; private set; }

        /// <summary>
        /// Application startup method including dependency injection
        /// </summary>
        /// <param name="e"></param>
        protected override void OnStartup(StartupEventArgs e)
        {
            var serviceCollection = new ServiceCollection();
            //configuring services
            ConfigureServices(serviceCollection);
            serviceProvider = serviceCollection.BuildServiceProvider();
            //initialize start of application
            var clientWindow = serviceProvider.GetRequiredService<ClientWindow>();
            //show ClientWindow instance
            clientWindow.Show();
            //Release method
            base.OnStartup(e);
        }

        /// <summary>
        /// Configuration of services, set everyinstance of interface => <= View model
        /// </summary>
        /// <param name="services">collection of services</param>
        private void ConfigureServices(IServiceCollection services)
        {
            //services for interfaces
            services.AddScoped<IPeopleRepository, MockPeopleRepository>();
            services.AddScoped<PersonFaker>();
            //Service of MainViewModel
            services.AddSingleton<MainViewModel>(s => new MainViewModel(s.GetRequiredService<IPeopleRepository>()));
            //Include MainViewModel to ClientWindow as datacontext
            services.AddScoped<ClientWindow>(s => new ClientWindow(s.GetRequiredService<MainViewModel>()));
        }
    }
}
