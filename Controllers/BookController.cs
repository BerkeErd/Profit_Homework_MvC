using Microsoft.AspNetCore.Mvc;
using Profit_Homework_MvC.Models;
using Profit_Homework_MvC.Repository.BookRepo;

namespace Profit_Homework_MvC.Controllers
{
	public class BookController : Controller
	{
		private readonly IBookRepository _bookRepository;

        private readonly ILogger<BookController> _logger;
        public BookController(IBookRepository bookRepository, ILogger<BookController> logger)
        {
			_bookRepository = bookRepository;
            _logger = logger;
		}
        public IActionResult Index()
        {
            try
            {
                var data = _bookRepository.GetAll();
                return View(data);
            }
            catch (Exception e)
            {
                _logger.LogInformation(e.Message);
                throw;
            }
          
        }

        [HttpGet]
        public Book GetById(int id) 
        {
            try
            {
                return _bookRepository.GetById(id);
            }
            catch (Exception e)
            {
                _logger.LogInformation(e.Message);
                throw;
            }
           
        
        }

        //[HttpGet]
        ////public Checkout GetCheckout(int id)
        ////{
            
        ////}
    }
}
