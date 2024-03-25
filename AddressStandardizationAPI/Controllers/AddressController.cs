using AddressStandardizationAPI.Models.Dtos;
using AddressStandardizationAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace AddressStandardizationAPI.Controllers
{
    /// <summary>
    /// Контроллер стандартизации адреса
    /// </summary>
    [ApiController]
    [Route("/addres")]
    public class AddressController : ControllerBase
    {
        private readonly ResponseDto responseDto;
        private readonly IAddressService addressService;
        private readonly ILogger<AddressController> logger;

        public AddressController(IAddressService addressService, ILogger<AddressController> logger)
        {
            responseDto = new ResponseDto();

            this.addressService = addressService ?? throw new ArgumentNullException(nameof(addressService));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Метод стандартизации адреса
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ResponseDto> GetStandardizedAddres(string address)
        {
            try
            {
                await addressService.GetStandardizedAddress(address);
            }
            catch (Exception ex)
            {
                logger.LogWarning($"Ошибка метода GET /addres: {ex.Message}");
                responseDto.IsSuccess = false;
                responseDto.ErrorMessages = new List<string>() { ex.Message };
            }

            return responseDto;
        }
    }
}
