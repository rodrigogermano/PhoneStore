using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using PhoneStore.Application.Protos;
using PhoneStory.Domain.Entities;
using PhoneStory.Domain.Shared.ValueObject;

namespace PhoneStore.Application.Settings
{
    public static class AutoMapperConfig
    {
        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Product, ProductBuf>();                
            });

            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }
    }
}
