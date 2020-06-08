using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace PhoneStore.Application.Settings
{
    public static class gRPC
    {
        public static IServiceCollection AddgRPC(this IServiceCollection services)
        {
            services.AddGrpc(options => {
                options.EnableDetailedErrors = true;
                options.MaxReceiveMessageSize = 1 * 1024 * 1024; // 1 megabytes; 
                options.MaxSendMessageSize = 5 * 1024 * 1024; // 5 megabytes;
                options.ResponseCompressionLevel = System.IO.Compression.CompressionLevel.Optimal;
            });

            return services;
        }

        public static IApplicationBuilder UsegRPC(this IApplicationBuilder app)
        {
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<ProductAppService>();

                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
                });
            });

            return app;
        }
    }
}
