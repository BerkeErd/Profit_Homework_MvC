using Microsoft.AspNetCore.Mvc;
using Profit_Homework_MvC.Models;
using Profit_Homework_MvC.Repository.BookRepo;

namespace Profit_Homework_MvC.Controllers
{
	public class BookController : Controller
	{
		private readonly IBookRepository _bookRepository;
        public BookController(IBookRepository bookRepository)
        {
			_bookRepository = bookRepository;
		}
        public IActionResult Index()
        {
            var data = _bookRepository.GetAll();
            return View(data);
        }

        public Book GetById(int id) 
        {
           return _bookRepository.GetById(id);
        
        }
    }
}
