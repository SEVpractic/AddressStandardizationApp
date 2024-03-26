using AddressStandardizationAPI.Services;
using AutoMapper;
using Microsoft.OpenApi.Models;
using System.Reflection;

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

        /// <summary> Получение конфигурации свагера</summary>
        /// <param name="service"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection GetSwaggerConfig(this IServiceCollection service)
        {
            service.AddEndpointsApiExplorer();
            service.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "AddressStandardizationAPI",
                    Version = "v1",
                    Description = "Сервис стандартизации сырого адреса, введенного пользователем, с применением DadataApi",
                });

                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });

            return service;
        }
    }
}
