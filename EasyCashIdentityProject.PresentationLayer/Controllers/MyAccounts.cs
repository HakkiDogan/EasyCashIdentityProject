using Microsoft.AspNetCore.Mvc;

namespace EasyCashIdentityProject.PresentationLayer.Controllers
{
	public class MyAccounts : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
