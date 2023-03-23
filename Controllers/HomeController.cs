using Microsoft.AspNetCore.Mvc;
using Profit_Homework_MvC.Models;
using Profit_Homework_MvC.Repository.BookRepo;
using System.Diagnostics;

namespace Profit_Homework_MvC.Controllers
{
	public class HomeController : Controller
	{
  //      private readonly IBookRepository _bookRepository;
  //      public HomeController(IBookRepository bookRepository)
  //      {
  //          _bookRepository = bookRepository;
  //      }
      

		//public IActionResult Index()
		//{
  //          var data = _bookRepository.GetAll();
  //          return View(data);
		//}

		//public IActionResult Privacy()
		//{
		//	return View();
		//}

		//[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		//public IActionResult Error()
		//{
		//	return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		//}
	}
}