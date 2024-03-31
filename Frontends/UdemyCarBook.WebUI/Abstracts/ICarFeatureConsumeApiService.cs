using UdemyCarBook.Dto.Dtos;

namespace UdemyCarBook.WebUI.Abstracts
{
    public interface ICarFeatureConsumeApiService:IGenericConsumeApiService<ResultCarFeatureListByCarIdDto,CreateCarFeatureDto,UpdateCarFeatureDto>
    {
        Task<List<ResultCarFeatureListByCarIdDto>> GetCarFeatureListByCarId(int CarId);
        Task ChangeAvailableFalse(int CarFeatureId);
        Task ChangeAvailableTrue(int CarFeatureId);
    }
}
