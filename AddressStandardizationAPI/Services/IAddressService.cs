using AddressStandardizationAPI.Models.Dtos;

namespace AddressStandardizationAPI.Services
{
    public interface IAddressService
    {
        Task<AddressApiDto> GetStandardizedAddress(string address);
    }
}
