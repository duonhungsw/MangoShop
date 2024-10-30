using Mango.Web.Models;
using Mango.Web.Service.IService;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Web.Controllers;

public class AccountController(IAccountService accountService, ITokenProvider tokenProvider) : Controller
{
	public IActionResult Login()
	{
		return View();
	}
	[HttpPost]
	public async Task<IActionResult?> Login(LoginDto loginDto)
	{
		ResponseDto? response = await accountService.Login(loginDto, HttpContext);

		if (response != null && response.IsSuccess)
		{

			if (response.Result.ToString() != null && !string.IsNullOrEmpty(response.Result.ToString()))
			{
				tokenProvider.SetToken(response.Result.ToString());

				return RedirectToAction("Index", "Home");
			}
		}
		TempData["error"] = response?.Message ?? "Login Failed!";
		return View();
	}

	public IActionResult Logout()
	{
		tokenProvider.ClearToken();
		return RedirectToAction("Login", "Account");
	}
}
