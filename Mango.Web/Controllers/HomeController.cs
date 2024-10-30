using Common.Extensions;
using Mango.Web.Models;
using Mango.Web.Service.IService;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Mango.Web.Controllers;

public class HomeController(ILogger<HomeController> logger, ITokenProvider tokenProvider) : Controller
{

    public IActionResult Index()
    {
        string? token = tokenProvider.GetToken();
        if(token != null)
        {
             
            HomeViewModel homeView = new HomeViewModel
            {
                AccountId = JwtExtension.GetToken(token),
                pictureUrl = null
            };
			return View(homeView);
        }
        else
        {
			return View();

		}
	}

    public IActionResult Thankyou()
    {
        return View();
    }
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
