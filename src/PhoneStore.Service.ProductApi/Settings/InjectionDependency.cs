using Grpc.Net.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PhoneStore.Infra.BlobStorage;
using Productsbuf;
using static Productsbuf.ProductsBuf;

namespace PhoneStore.Service.ProductApi.Settings
{
    public static class InjectionDependency
    {
        public static IServiceCollection AddInjectionDependency(this IServiceCollection services, IConfiguration configuration)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:5003");
            services.AddTransient<ProductsBufClient>(x => new ProductsBuf.ProductsBufClient(channel));
            services.AddScoped<IBlobStorageService>(x => new BlobStorageService(configuration.GetConnectionString("BlobStorageHomolog")));

            return services;
        }
    }
}
