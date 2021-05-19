using System;
using System.Windows;
using FestivalManager.App.Extensions;
using FestivalManager.App.Factory;
using FestivalManager.App.Services;
using FestivalManager.App.ViewModels;
using FestivalManager.App.ViewModels.Interfaces;
using FestivalManager.App.Views;
using FestivalManager.BL.Repositories;
using FestivalManager.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FestivalManager.App
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost _host;

        public App()
        {
            _host = Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration(ConfigureAppConfiguration)
                .ConfigureServices((context, services) => { ConfigureServices(context.Configuration, services); })
                .Build();
        }

        private static void ConfigureAppConfiguration(HostBuilderContext context, IConfigurationBuilder builder)
        {
            builder.AddJsonFile(@"appsettings.json", false, true);
        }

        private static void ConfigureServices(IConfiguration configuration,
            IServiceCollection services)
        {
            services.AddSingleton<MainWindow>();

            services.AddSingleton<IBandRepository, BandRepository>();
            services.AddSingleton<ISlotRepository, SlotRepository>();
            services.AddSingleton<IStageRepository, StageRepository>();

            services.AddSingleton<IMediator, Mediator>();

            services.AddSingleton<MainViewModel>();

            services.AddSingleton<IHomeViewModel, HomeViewModel>();
            services.AddSingleton<IBandsViewModel, BandsViewModel>();
            services.AddFactory<IBandDetailViewModel, BandDetailViewModel>();
            services.AddFactory<IAddBandViewModel, AddBandViewModel>();
            services.AddSingleton<IProgramViewModel, ProgramViewModel>();
            services.AddFactory<ISlotDetailViewModel, SlotDetailViewModel>();
            services.AddFactory<IAddSlotViewModel, AddSlotViewModel>();
            services.AddFactory<IAddStageViewModel, AddStageViewModel>();
            services.AddSingleton<IStagesViewModel, StagesViewModel>();
            services.AddFactory<IStageDetailViewModel, StageDetailViewModel>();

            services.AddSingleton<IDbContextFactory<FestivalManagerDbContext>>
                (provider => new SqlServerDbContextFactory(configuration.GetConnectionString("DefaultConnection")));

        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await _host.StartAsync();

            var dbContextFactory = _host.Services.GetRequiredService<IDbContextFactory<FestivalManagerDbContext>>();
            
#if DEBUG
            await using (var dbx = dbContextFactory.CreateDbContext())
            {
                await dbx.Database.MigrateAsync();
            }
#endif

            var mainWindow = _host.Services.GetRequiredService<MainWindow>();
            mainWindow.Show();

            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            using (_host)
            {
                await _host.StopAsync(TimeSpan.FromSeconds(5));
            }

            base.OnExit(e);
        }
    }
}
