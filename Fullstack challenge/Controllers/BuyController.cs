using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Fullstack.Challenge.Models;
using Fullstack.Challenge.Services;

namespace Fullstack.Challenge.Controllers
{
	[Authorize]
	public class BuyController : Controller
	{
		private readonly StocksService _stocksService;
		private readonly CurrentUserService _currentUserService;

		public BuyController(StocksService stocksService,  CurrentUserService currentUserService)
		{
			_stocksService = stocksService ?? throw new ArgumentNullException(nameof(stocksService));
			_currentUserService = currentUserService ?? throw new ArgumentNullException(nameof(currentUserService));
		}

		public ActionResult Index()
		{
			List<Stock> stocks = _stocksService.GetStocksAvailable();
			return View(stocks);
		}
		[HttpPost]
		public bool Buy(List<Item> items, int totlacost)
		{
			var res = true;
			User _user = _currentUserService.GetUser();
			_user.Balance -= totlacost;
			_stocksService.UpdateList(items);
			res = _currentUserService.UpdateUser(_user);
			return res;
		}
	}
}