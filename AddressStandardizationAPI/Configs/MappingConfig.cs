using AutoMapper;

namespace AddressStandardizationAPI.Configs
{
    public class MappingConfig
    {
        public static MapperConfiguration GetMapperConfiguraton()
        {
            return new MapperConfiguration(cfg =>
            {
                //cfg.CreateMap<источник, цель>().ReverseMap();
            });
        }
    }
}
