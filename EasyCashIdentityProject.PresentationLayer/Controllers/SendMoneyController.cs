using EasyCashIdentityProject.BusinessLayer.Abstract;
using EasyCashIdentityProject.DataAccessLayer.Concrete;
using EasyCashIdentityProject.DtoLayer.Dtos.CustomerAccountProcessDtos;
using EasyCashIdentityProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyCashIdentityProject.PresentationLayer.Controllers
{
	public class SendMoneyController : Controller
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly ICustomerAccountProcessService _customerAccountProcessService;

		public SendMoneyController(UserManager<AppUser> userManager, ICustomerAccountProcessService customerAccountProcessService)
        {
            _userManager = userManager;
			_customerAccountProcessService = customerAccountProcessService;
		}

        [HttpGet]
		public IActionResult Index(string mycurrency)
		{
			ViewBag.currency = mycurrency;
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Index(SendMoneyCustomerAccountProcessDto sendMoneyCustomerAccountProcessDto)
		{
			var context = new Context();
			var user = await _userManager.FindByNameAsync(User.Identity.Name);
			var receiverAccountNumberID = context.CustomerAccounts
				.Where(x => x.CustomerAccountNumber == sendMoneyCustomerAccountProcessDto.ReceiverAccountNumber)
				.Select(y => y.CustomerAccountID).FirstOrDefault();

			//CustomerAccountCurrency -> enum olarak çekilsin Türk Lirası yerine kod tablosundaki idsi yazılacak. 
			//Bunun gibi değerleri çekmek için projeye kod tablosu eklenecek.
			var senderAccountNumberID = context.CustomerAccounts.Where(x => x.AppUserID == user.Id)
				.Where(y => y.CustomerAccountCurrency == "Türk Lirası").Select(z => z.CustomerAccountID).FirstOrDefault();

			var values = new CustomerAccountProcess()
			{
				ProcessDate = Convert.ToDateTime(DateTime.Now.ToShortDateString()),
				SenderID = senderAccountNumberID,
				ProcessType = "Havale",
				ReceiverID = receiverAccountNumberID,
				Amount = sendMoneyCustomerAccountProcessDto.Amount,
				Description = sendMoneyCustomerAccountProcessDto.Description,
			};
			_customerAccountProcessService.Insert(values);
			
			return RedirectToAction("Index","MyAccounts");

		}


	}
}
