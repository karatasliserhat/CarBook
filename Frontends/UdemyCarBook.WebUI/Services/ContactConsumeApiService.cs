using UdemyCarBook.Dto.Dtos;
using UdemyCarBook.WebUI.Abstracts;

namespace UdemyCarBook.WebUI.Services
{
    public class ContactConsumeApiService : GenericConsumeApiService<ResultContactDto, CreateContactDto, UpdateContactDto>, IContactConsumeApiService
    {
        public ContactConsumeApiService(HttpClient client) : base(client)
        {
        }
    }
}
