using UdemyCarBook.Dto.Dtos;

namespace UdemyCarBook.WebUI.Abstracts
{
    public interface IBlogConsumeApiService:IGenericConsumeApiService<ResultBlogDto,CreateBlogDto,UpdateBlogDto>
    {
        Task<List<ResultLastThreeBlogWithAuthorDto>> GetLastThreeBlogWithAuthorList();
    }
}
