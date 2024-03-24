﻿using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Dto.Dtos;
using UdemyCarBook.WebUI.Abstracts;

namespace UdemyCarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[Controller]/[Action]")]
    public class AdminFooterAddressController : Controller
    {
        private readonly IFooterAddressConsumeApiService _FooterAddressConsumeApiService;
        private readonly IDataProtector _dataProtect;
        public AdminFooterAddressController(IFooterAddressConsumeApiService FooterAddressConsumeApiService, IDataProtectionProvider dataProtect)
        {
            _FooterAddressConsumeApiService = FooterAddressConsumeApiService;
            _dataProtect = dataProtect.CreateProtector("AdminFooterAddressController");
        }

        public async Task<IActionResult> Index()
        {
            var values = await _FooterAddressConsumeApiService.GetListAsync("FooterAddresses");
            values.ForEach(x => x.DataProtect = _dataProtect.Protect(x.FooterAddressId.ToString()));
            return View(values);
        }

        public IActionResult CreateFooterAddress()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateFooterAddress(CreateFooterAddressDto createFooterAddressDto)
        {
            var response = await _FooterAddressConsumeApiService.CreateAsync("FooterAddresses", createFooterAddressDto);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        public async Task<IActionResult> Update(string id)
        {
            var dataValue = int.Parse(_dataProtect.Unprotect(id));
            return View(await _FooterAddressConsumeApiService.GetByIdUpdateAsync("FooterAddresses", dataValue));
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateFooterAddressDto updateFooterAddressDto)
        {
            var response = await _FooterAddressConsumeApiService.UpdateAsync("FooterAddresses", updateFooterAddressDto);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public async Task<IActionResult> Delete(string id)
        {
            var dataValue = int.Parse(_dataProtect.Unprotect(id));
            var response = await _FooterAddressConsumeApiService.RemoveAsync("FooterAddresses", dataValue);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}
