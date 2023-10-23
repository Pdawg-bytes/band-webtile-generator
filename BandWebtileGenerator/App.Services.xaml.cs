using BandWebtileGenerator.Library.Services.Environment;
using BandWebtileGenerator.Library.ViewModels;
using BandWebtileGenerator.Services.Environment;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace BandWebtileGenerator
{
    partial class App
    {
        private IServiceProvider m_serviceProvider;

        public static IServiceProvider ServiceProvider
        {
            get
            {
                IServiceProvider serviceProvider = (Current as App).m_serviceProvider ??
                    throw new InvalidOperationException("Service provider was not initialized before accessing.");

                return serviceProvider;
            }
        }

        private void ConfigureServices()
        {
            IServiceCollection collection = new ServiceCollection()
                .AddSingleton<IEnvironmentService, EnvironmentService>()
                .AddTransient<HomeViewModel>()
                .AddTransient<MainPageViewModel>();

            m_serviceProvider = collection.BuildServiceProvider(true);
        }
    }
}