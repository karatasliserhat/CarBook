using UdemyCarBook.Dto.Dtos;
using UdemyCarBook.WebUI.Abstracts;

namespace UdemyCarBook.WebUI.Services
{
    public class CategoryConsumeApiService : GenericConsumeApiService<ResultCategoryDto, CreateCategoryDto, UpdateCategoryDto>, ICategoryConsumeApiService
    {
        public CategoryConsumeApiService(HttpClient client) : base(client)
        {
        }
    }
}
