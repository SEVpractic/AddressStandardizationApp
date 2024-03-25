using AddressStandardizationAPI.Models.Dtos;
using AddressStandardizationAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace AddressStandardizationAPI.Controllers
{
    [ApiController]
    [Route("/addres")]
    public class AddresController : ControllerBase
    {
        private readonly ResponseDto responseDto;

        public AddresController(IAddresService addresService)
        {
            responseDto = new ResponseDto();
        }

        public Task<ResponseDto> GetStandardizedAddres()
        {
            return null;
        }
    }
}
