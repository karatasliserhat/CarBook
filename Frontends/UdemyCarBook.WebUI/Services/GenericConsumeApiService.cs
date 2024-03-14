using UdemyCarBook.WebUI.Abstracts;

namespace UdemyCarBook.WebUI.Services
{
    public class GenericConsumeApiService<resultDto, createDto, updateDto> : IGenericConsumeApiService<resultDto, createDto, updateDto>
        where resultDto : class
        where createDto : class
        where updateDto : class
    {
        private readonly HttpClient _client;

        public GenericConsumeApiService(HttpClient client)
        {
            _client = client;
        }

        public async Task<HttpResponseMessage> CreateAsync(string controllerName, createDto entity)
        {
            return await _client.PostAsJsonAsync<createDto>(controllerName, entity);

        }

        public async Task<HttpResponseMessage> RemoveAsync(string controllerName, int id)
        {
            return await _client.DeleteAsync($"{controllerName}/{id}");
        }

        public async Task<HttpResponseMessage> UpdateAsync(string controllerName, updateDto entity)
        {
            return await _client.PutAsJsonAsync<updateDto>(controllerName, entity);

        }

        public async Task<resultDto> GetByIdAsync(string controllerName, int id)
        {
            return await _client.GetFromJsonAsync<resultDto>($"{controllerName}/{id}");


        }

        public async Task<List<resultDto>> GetListAsync(string controllerName)
        {
            return await _client.GetFromJsonAsync<List<resultDto>>(controllerName);
        }


    }
}
