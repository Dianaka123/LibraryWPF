using Library.App.Models.Repositories;
using Library.App.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.Windows;

namespace Library.App
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IServiceProvider ServiceProvider { get; private set; }

        public App()
        {
            var services = new ServiceCollection();

            services.AddSingleton<ReaderRepository>();

            services.AddTransient<ReaderViewModel>();
            services.AddTransient<AddReaderViewModel>();

            ServiceProvider = services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var readerVM = ServiceProvider.GetRequiredService<ReaderViewModel>();
            var mainWindow = new MainWindow();
            mainWindow.DataContext = readerVM;
            mainWindow.Show();
        }
    }
}
