using System;
using System.Windows;
using Microsoft.Extensions.Configuration;
using _0901_API_AI_app.Models;
using _0901_API_AI_app.Services;
using _0901_API_AI_app.Controllers;
using _0901_API_AI_app.ViewModels;
using _0901_API_AI_app.Views;


namespace _0901_API_AI_app
{
    public partial class App : Application
    {
        public static IConfiguration Configuration { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Load appsettings.json
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            Configuration = builder.Build();

            // Bind OpenAiSettings section
            var settings = Configuration.GetSection("OpenAiSettings").Get<OpenAiSettings>();

            // Create services
            var service = new OpenAiService(settings);
            var controller = new MainController(service);
            var viewModel = new MainViewModel(controller);

            // Show MainView
            var mainView = new MainView
            {
                DataContext = viewModel
            };
            mainView.Show();
        }
    }
}
