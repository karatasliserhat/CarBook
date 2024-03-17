using UdemyCarBook.WebUI.Abstracts;
using UdemyCarBook.WebUI.Services;

namespace UdemyCarBook.WebUI.CustomAddServices
{
    public static class CustomAddBuilderService
    {
        public static void AddBuilderService(this IServiceCollection Services, IConfiguration configuration)
        {
            Services.AddScoped(typeof(IGenericConsumeApiService<,,>), typeof(GenericConsumeApiService<,,>));

            Services.AddHttpClient<IAboutConsumeApiService, AboutConsumeApiService>(opts =>
            {
                opts.BaseAddress = new Uri(configuration["ApiConsumes:BaseAddress"]);
            });
            Services.AddHttpClient<ITestimonialConsumeApiService, TestimonialConsumeApiService>(opts =>
            {
                opts.BaseAddress = new Uri(configuration["ApiConsumes:BaseAddress"]);
            });
            Services.AddHttpClient<IServiceConsumeApiService, ServiceConsumeApiService>(opts =>
            {
                opts.BaseAddress = new Uri(configuration["ApiConsumes:BaseAddress"]);
            });
            Services.AddHttpClient<ICarConsumeApiService, CarConsumeApiService>(opts =>
            {
                opts.BaseAddress = new Uri(configuration["ApiConsumes:BaseAddress"]);
            });
            Services.AddHttpClient<IFooterAddressConsumeApiService, FooterAddressConsumeApiService>(opts =>
            {
                opts.BaseAddress = new Uri(configuration["ApiConsumes:BaseAddress"]);
            });
            Services.AddHttpClient<IContactConsumeApiService, ContactConsumeApiService>(opts =>
             {
                 opts.BaseAddress = new Uri(configuration["ApiConsumes:BaseAddress"]);
             });
            Services.AddHttpClient<IBannerConsumeApiService, BannerConsumeApiService>(opts =>
            {
                opts.BaseAddress = new Uri(configuration["ApiConsumes:BaseAddress"]);
            });
            Services.AddHttpClient<IBlogConsumeApiService, BlogConsumeApiService>(opts =>
            {
                opts.BaseAddress = new Uri(configuration["ApiConsumes:BaseAddress"]);
            });
            Services.AddHttpClient<ICarPricingConsumeApiServe, CarPricingConsumeApiService>(opts =>
            {
                opts.BaseAddress = new Uri(configuration["ApiConsumes:BaseAddress"]);
            });

        }
    }
}
