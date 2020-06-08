using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using PhoneStore.Service.ProductApi.ViewModel;
using Productsbuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneStore.Service.ProductApi.Settings
{
    public static class AutoMapperConfig
    {
        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CreateProductViewModel, ProductBuf>();
                cfg.CreateMap<UpdateProductViewModel, ProductBuf>();
            });

            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }
    }
}
