using AddressStandardizationAPI.Services;
using AutoMapper;

namespace AddressStandardizationAPI.Configs
{
    public static class ServicesConfig
    {
        /// <summary> Получение конфигурации сервисов </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection GetServicesConfig(this IServiceCollection services)
        {
            IMapper mapper = MappingConfig
                .GetMapperConfiguraton()
                .CreateMapper();
            services.AddSingleton(mapper);
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<IAddressService, AddressService>();

            return services;
        }
    }
}
