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
    public class AddresController : ControllerBase
    {
        private readonly ResponseDto responseDto;

        public AddresController(IAddresService addresService)
        {
            responseDto = new ResponseDto();
        }

        /// <summary>
        /// Метод стандартизации адреса
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public Task<ResponseDto> GetStandardizedAddres()
        {
            return null;
        }
    }
}
