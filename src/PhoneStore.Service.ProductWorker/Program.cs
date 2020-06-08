using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PhoneStore.Application.Cqrs.CommandHandlers;
using PhoneStore.Application.Cqrs.EventHandlers;
using PhoneStore.Application.Interfaces;
using PhoneStore.Application.Interfaces.Handlers;
using PhoneStore.Application.Services;
using PhoneStore.Infra.DataAccess.Contexts;
using PhoneStore.Infra.DataAccess.Repositories;
using PhoneStore.Infra.DataAccess.Transactions;
using PhoneStore.Infra.Messaging;
using PhoneStory.Domain.Interfaces.Mediator;
using PhoneStory.Domain.Interfaces.Repositories;
using PhoneStory.Domain.Interfaces.Services;
using PhoneStory.Domain.Interfaces.UnitOfWork;
using PhoneStory.Domain.Services;
using PhoneStory.PhoneStore.Application.Interfaces.Events;
using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using PhoneStore.Infra.SendMail;

namespace PhoneStore.Service.ProductWorker
{
    class Program
    {
        public static IConfigurationRoot Configuration;
        static async Task Main(string[] args)
        {
            ServiceCollection serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);            

            var builder = new HostBuilder();
            builder.ConfigureWebJobs(b =>
            {
                b.AddAzureStorageCoreServices();
                b.AddServiceBus(c => c.ConnectionString = Configuration.GetConnectionString("AzureServiceBusHomolog"));
            }).ConfigureLogging((context, b) =>
            {
                b.AddConsole();
            }).ConfigureServices(services =>
            {
                services.AddSingleton<IMediatorHandler, AzureServiceBusQueue>();
                services.AddSingleton<IProductRepository, ProductRepository>();
                services.AddDbContext<PhoneStoreContext>(options =>
                {                    
                    options.UseSqlServer(Configuration.GetConnectionString("DbContext"));
                });
                                
                //services.AddScoped<PhoneStoreContext>();
                services.AddSingleton<IUow, Uow>();
                services.AddSingleton<IProductService, ProductService>();
                services.AddSingleton<IProductCommandHandler, ProductCommandHandler>();
                services.AddSingleton<IProductEventHandler, ProductEventHandler>();
                services.AddSingleton<IProductWorkerApp, ProductWorkerApp>();
                services.AddScoped<IMediatorHandler>(x => new AzureServiceBusQueue(Configuration.GetConnectionString("AzureServiceBusHomolog")));
                services.AddScoped<ISendMailService>(x => new SendMailService(
                    Configuration.GetValue<string>("SendMail:host"),
                    Configuration.GetValue<int>("SendMail:port"),
                    Configuration.GetValue<string>("SendMail:userName"),
                    Configuration.GetValue<string>("SendMail:password")));                 
            });
            var host = builder.Build();
            using (host)
            {
                await host.RunAsync();
            }
        }

        private static void ConfigureServices(IServiceCollection serviceCollection)
        {
            // Build configuration
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("appsettings.json", false)
                .Build();

            // Add access to generic IConfigurationRoot
            serviceCollection.AddSingleton<IConfigurationRoot>(Configuration);
        }
    }
}
