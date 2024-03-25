using AddressStandardizationAPI.Models.Dtos;
using AutoMapper;

namespace AddressStandardizationAPI.Configs
{
    public class MappingConfig
    {
        public static MapperConfiguration GetMapperConfiguraton()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Dadata.Model.Address, AddressDto>().ReverseMap();
                cfg.CreateMap<Dadata.Model.AddressMetro, MetroDto>();
            });
        }
    }
}
