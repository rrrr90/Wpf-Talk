﻿using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.Windows;
using Wpf_Talk.ViewModels;
using Wpf_Talk.Views;

namespace Wpf_Talk
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Services = ConfigureServices();
            Startup += App_Startup;
            //this.InitializeComponent();
        }

        private void App_Startup(object sender, StartupEventArgs e)
        {
            var mainWindow = Services.GetService<MainView>();
            var mainViewModel = Services.GetService<MainViewModel>();
            mainWindow.DataContext = mainViewModel;
            MainWindow.Show();
        }

        /// <summary>
        /// Gets the current <see cref="App"/> instance in use
        /// </summary>
        public new static App Current => (App)Application.Current;

        /// <summary>
        /// Gets the <see cref="IServiceProvider"/> instance to resolve application services.
        /// </summary>
        public IServiceProvider Services { get; }

        /// <summary>
        /// Configures the services for the application.
        /// </summary>
        private static ServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            // Views
            services.AddSingleton<MainView>();

            // ViewModels
            services.AddTransient<MainViewModel>();
            services.AddTransient<SignInViewModel>();
            services.AddTransient<SignUpViewModel>();
            services.AddTransient<ChangePwdViewModel>();

            return services.BuildServiceProvider();
        }
    }

}
