using EasyCashIdentityProject.DtoLayer.Dtos.AppUserDtos;
using EasyCashIdentityProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyCashIdentityProject.PresentationLayer.Controllers
{
	[Authorize]
	public class MyAccounts : Controller
	{
		private readonly UserManager<AppUser> _userManager;

        public MyAccounts(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

		[HttpGet]
        public async Task<IActionResult> Index()
		{
			var values = await _userManager.FindByNameAsync(User.Identity.Name);
			AppUserUpdateDto appUserUpdateDto = new();
			appUserUpdateDto.Name = values.Name;
			appUserUpdateDto.Surname = values.Surname;
			appUserUpdateDto.PhoneNumber = values.PhoneNumber;
			appUserUpdateDto.Email = values.Email;
			appUserUpdateDto.City = values.City;
			appUserUpdateDto.District = values.District;
			appUserUpdateDto.ImageUrl = values.ImageUrl;
			return View(appUserUpdateDto);
		}

		[HttpPost]
		public async Task<IActionResult> Index(AppUserUpdateDto appUserUpdateDto)
		{
			if (appUserUpdateDto.Password == appUserUpdateDto.ConfirmPassword)
			{
				var user = await _userManager.FindByNameAsync(User.Identity.Name);
				user.PhoneNumber = appUserUpdateDto.PhoneNumber;
				user.Name = appUserUpdateDto.Name;
				user.Surname = appUserUpdateDto.Surname;
				user.City = appUserUpdateDto.City;
				user.District = appUserUpdateDto.District;
				user.ImageUrl = "test";
				user.Email = appUserUpdateDto.Email;
				user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, appUserUpdateDto.Password);
				var result = await _userManager.UpdateAsync(user);
				if (result.Succeeded)
				{
					return RedirectToAction("Index", "Login");
				}
			}

			return View();

		}
	}
}
