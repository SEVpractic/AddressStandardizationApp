using AddressStandardizationAPI.Configs;
using AddressStandardizationAPI.Models.Dtos;
using AutoMapper;
using Dadata;
using Dadata.Model;

namespace AddressStandardizationAPI.Services
{
    public class AddressService : IAddressService
    {
        private readonly IMapper mapper;
        private readonly ILogger<IAddressService> logger;

        public AddressService(IMapper mapper, ILogger<IAddressService> logger)
        {
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<AddressDto> GetStandardizedAddress(string address)
        {
            Dadata.Model.Address dadataResponse = await CallDadataApi(address);
            logger.LogInformation($"Запрос API Dadata выпонен. Строка: {address}");

            return mapper.Map<AddressDto>(dadataResponse);
        }

        /// <summary>
        /// Метод отправки http запросов к DadataAPI
        /// </summary>
        /// <param name="method"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        private async Task<Dadata.Model.Address> CallDadataApi(string addres)
        {
            var api = new CleanClientAsync(SD.DadataApiToken, SD.DadataApiSecret);
            return await api.Clean<Address>(addres);
        }
    }
}
