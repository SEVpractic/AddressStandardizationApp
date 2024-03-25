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

        public async Task<AddressApiDto> GetStandardizedAddress(string address)
        {
            await CallDadataApi(address);

            return null;
        }

        /// <summary>
        /// Метод отправки http запросов к DadataAPI
        /// </summary>
        /// <param name="method"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        private async Task<ResponseDto> CallDadataApi(string addres)
        {
            var token = "2e6e93ba21cfc49768cb62855685c253bb56ae67";
            var secret = "3e7d048de831a8f4a284edbd6dcbf7fe30641722";

            var api = new CleanClientAsync(token, secret);

            var result = await api.Clean<Address>("воронеж патриотов 34 29");
            return null;
        }
    }
}
