namespace UdemyCarBook.WebUI.Abstracts
{
    public interface IGenericConsumeApiService<resultDto, createDto, updateDto>
        where createDto : class
        where updateDto : class
        where resultDto : class
    {
        Task<HttpResponseMessage> CreateAsync(string controllerName, createDto entity);
        Task<HttpResponseMessage> UpdateAsync(string controllerName, updateDto entity);
        Task<HttpResponseMessage> RemoveAsync(string controllerName, int id);
        Task<resultDto> GetByIdAsync(string controllerName, int id);

        Task<updateDto> GetByIdUpdateAsync(string controllerName, int id);
        Task<List<resultDto>> GetListAsync(string controllerName);
        Task<List<resultDto>> GetListAsync(string controllerName, string actionName);
    }
}
