using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.CQRS.Commands;
using UdemyCarBook.Application.Features.CQRS.Handlers.BannerHandlers;
using UdemyCarBook.Application.Features.CQRS.Queries;

namespace UdemyCarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannersConroller : ControllerBase
    {
        private readonly CreateBannerCommandHandler _createBannerCommand;
        private readonly GetBannerByIdQueryHandler _getBannerByIdQueryHandler;
        private readonly GetBannerQueryHandler _getBannerQueryHandler;
        private readonly RemoveBannerCommandHandler _removeBannerCommandHandler;
        private readonly UpdateBannerCommandHandler _updateBannerCommandHandler;

        public BannersConroller(CreateBannerCommandHandler createBannerCommand, GetBannerByIdQueryHandler getBannerByIdQueryHandler, GetBannerQueryHandler getBannerQueryHandler, RemoveBannerCommandHandler removeBannerCommandHandler, UpdateBannerCommandHandler updateBannerCommandHandler)
        {
            _createBannerCommand = createBannerCommand;
            _getBannerByIdQueryHandler = getBannerByIdQueryHandler;
            _getBannerQueryHandler = getBannerQueryHandler;
            _removeBannerCommandHandler = removeBannerCommandHandler;
            _updateBannerCommandHandler = updateBannerCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> BannerList()
        {
            var values = await _getBannerQueryHandler.Handle();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBanner(int id)
        {
            var values = await _getBannerByIdQueryHandler.Handle(new GetBannerByIdQuery(id));
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBanner(CreateBannerCommand createBannerCommand)
        {
            await _createBannerCommand.Handle(createBannerCommand);
            return Ok("Banner bilgisi Eklendi");
        }
        [HttpDelete("{id}")]

        public async Task<IActionResult> RemoveBanner(int id)
        {
            await _removeBannerCommandHandler.Handle(new RemoveBannerCommand(id));
            return Ok("Banner bilgisi silindi");
        }

        [HttpPut]
        public async Task<IActionResult> BannerUpdate(UpdateBannerCommand updateBannerCommand)
        {
            await _updateBannerCommandHandler.Handle(updateBannerCommand);
            return Ok("Banner bilgisi güncellendi");
        }
    }
}
