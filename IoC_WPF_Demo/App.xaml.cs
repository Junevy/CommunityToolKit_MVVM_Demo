using IoC_WPF_Demo.Services;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System.Configuration;
using System.Data;
using System.Windows;

namespace IoC_WPF_Demo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IServiceProvider Services { get; }
        public new static App Current => (App)App.Current;

        public App()
        {
            this.Services = ConfigureService();
        }

        private static IServiceProvider ConfigureService()
        {
            var services = new ServiceCollection();
            services.AddSingleton<ILogger>(_ => 
                new LoggerConfiguration().MinimumLevel
                .Debug()
                .WriteTo.File("Log.txt")
                .CreateLogger());
            services.AddTransient<MainWindowViewModel>();
            services.AddTransient<MainWindow>(sp => new MainWindow
            {
                DataContext = sp.GetService<MainWindowViewModel>()
            });
            services.AddSingleton<IWebClient, WebClient>();
            services.AddSingleton<ICatFacts, CatFacts>();

            return services.BuildServiceProvider();
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            //Services
            var mainWindow = Services.GetService<MainWindow>();
            mainWindow!.Show();
        }
    }

}
