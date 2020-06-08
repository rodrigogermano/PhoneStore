using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PhoneStore.Infra.DataAccess.Contexts;
using PhoneStore.Infra.DataAccess.Repositories;
using PhoneStore.Infra.DataAccess.Transactions;
using PhoneStore.Infra.Messaging;
using PhoneStory.Domain.Interfaces.Mediator;
using PhoneStory.Domain.Interfaces.Repositories;
using PhoneStory.Domain.Interfaces.UnitOfWork;

namespace PhoneStore.Application.Settings
{
    public static class InjectionDependency
    {
        public static IServiceCollection AddInjectionDependency(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PhoneStoreContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DbContext"));
            });

            services.AddScoped<IUow, Uow>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IMediatorHandler>(x => new AzureServiceBusQueue(configuration.GetConnectionString("AzureServiceBusHomolog")));
             

            return services;
        }
    }
}
