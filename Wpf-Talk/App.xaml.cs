using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.Windows;
using Wpf_Talk.Repositories;
using Wpf_Talk.Services;
using Wpf_Talk.Stores;
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
            //var view = Services.GetService<LoginView>();
            //var viewModel = Services.GetService<LoginViewModel>();
            //view.DataContext = viewModel;
            //view.Show();

            Services.GetService<IViewService>()?.ShowView<MainView, MainViewModel>(7);
            //Services.GetService<IViewService>()?.ShowView<LoginView, LoginViewModel>();
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

            // Stores
            services.AddSingleton<NavigationStore>();

            // Services
            services.AddSingleton<INavigationService, NavigationService>();
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddSingleton<IViewService, ViewService>();

            // Views
            services.AddSingleton<LoginView>();
            services.AddSingleton<MainView>();

            // ViewModels
            services.AddTransient<LoginViewModel>();
            services.AddTransient<SignInViewModel>();
            services.AddTransient<SignUpViewModel>();
            services.AddTransient<ChangePwdViewModel>();

            services.AddSingleton<MainViewModel>();
            services.AddTransient<FriendViewModel>();
            services.AddTransient<ChattingViewModel>();
            services.AddTransient<MoreViewModel>();

            return services.BuildServiceProvider();
        }
    }

}
