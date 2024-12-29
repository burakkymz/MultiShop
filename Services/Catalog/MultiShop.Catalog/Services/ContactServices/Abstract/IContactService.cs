using MultiShop.Catalog.Dtos.ContactDtos;
namespace MultiShop.Catalog.Services.ContactServices.Abstract
{
    public interface IContactService
    {
        Task<List<ResultContactDto>> GettAllContactAsync();
        Task CreateContactAsync(CreateContactDto createContactDto);
        Task UpdateContactAsync(UpdateContactDto updateContactDto);
        Task DeleteContactAsync(string id);
        Task<GetByIdContactDto> GetByIdContactAsync(string id);
    }
}
