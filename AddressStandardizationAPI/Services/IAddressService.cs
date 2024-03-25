using AddressStandardizationAPI.Models.Dtos;

namespace AddressStandardizationAPI.Services
{
    public interface IAddressService
    {
        Task<AddressDto> GetStandardizedAddress(string address);
    }
}
