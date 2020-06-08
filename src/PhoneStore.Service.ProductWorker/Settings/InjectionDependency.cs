using Microsoft.EntityFrameworkCore;
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
using PhoneStore.Infra.SendMail;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace PhoneStore.Service.ProductWorker.Settings
{
    public static class InjectionDependency
    {
        public static void AddInjectionDependency(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IMediatorHandler, AzureServiceBusQueue>();
            services.AddSingleton<IProductRepository, ProductRepository>();
            services.AddDbContext<PhoneStoreContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DbContext"));
            });

            services.AddScoped<PhoneStoreContext>();
            services.AddSingleton<IUow, Uow>();
            services.AddSingleton<IProductService, ProductService>();
            services.AddSingleton<IProductCommandHandler, ProductCommandHandler>();
            services.AddSingleton<IProductEventHandler, ProductEventHandler>();
            services.AddSingleton<IProductWorkerApp, ProductWorkerApp>();
            services.AddScoped<IMediatorHandler>(x => new AzureServiceBusQueue(configuration.GetConnectionString("AzureServiceBusHomolog")));
            services.AddScoped<ISendMailService>(x => new SendMailService(configuration.GetValue<string>("SendMail:host"),
                configuration.GetValue<int>("SendMail:port"),
                configuration.GetValue<string>("SendMail:userName"),
                configuration.GetValue<string>("SendMail:password")));
        }
    }
}
