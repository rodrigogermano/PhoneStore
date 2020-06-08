using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneStore.Service.ProductApi.Settings
{
    public static class AddAndConfigCors
    {
        public static string _PolicyName = "AllowOrigin";
        public static IServiceCollection AddCors(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddCors(option =>
            {
                option.AddPolicy(_PolicyName, policy =>
                    policy.AllowAnyOrigin()
                          .AllowAnyHeader()
                          .AllowAnyMethod()
                );
            });

            return services;
        }

        public static IApplicationBuilder UseCors(this IApplicationBuilder app,IConfiguration Configuration)
        {
            app.UseCors("AllowOrigin");

            return app;
        }
    }
}
