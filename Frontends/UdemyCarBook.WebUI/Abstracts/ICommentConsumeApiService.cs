using UdemyCarBook.Dto.Dtos;

namespace UdemyCarBook.WebUI.Abstracts
{
    public interface ICommentConsumeApiService:IGenericConsumeApiService<ResultCommentDto,CreateCommentDto,UpdateCommentDto>
    {
        Task<List<GetCommentByBlogIdDto>> GetCommentByBlogIdListAsync(int id);
        Task<ResultCommentBlogCountDto> GetBlogCommentCountAsync(int id);
    }
}
