using Microsoft.AspNetCore.Mvc;
using Profit_Homework_MvC.Migrations;
using Profit_Homework_MvC.Models;
using Profit_Homework_MvC.Repository.BookRepo;
using Profit_Homework_MvC.Repository.CheckoutRepo;
using Profit_Homework_MvC.Repository.CustomerRepo;

namespace Profit_Homework_MvC.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly ICheckoutRepository _checkoutRepository;

        private readonly IBookRepository _bookRepository;

        private readonly ICustomerRepo _customerRepo;

        private readonly ILogger<CheckoutController> _logger;
        public CheckoutController(ICheckoutRepository checkoutRepository, IBookRepository bookRepository, ICustomerRepo customerRepo, ILogger<CheckoutController> logger)
        {
            _checkoutRepository = checkoutRepository;
            _bookRepository = bookRepository;
            _customerRepo = customerRepo;
            _logger = logger;

        }
        public IActionResult Index(int id)
        {
            try
            {
                ViewBag.BookId = id;
                return View();
            }
            catch (Exception e)
            {
                _logger.LogInformation(e.Message);
                throw;
            }
           
        }

        public IActionResult CreateCheckout(Checkout checkout, int BookId) 
        {
            try
            {
                _checkoutRepository.Add(checkout);
                Book book = _bookRepository.GetById(BookId);
                book.IsCheckedOut = true;
                _bookRepository.Update(book, BookId);
                checkout.Book = book;
                return Ok("Checkout Created");
            }
            catch (Exception e)
            {
                _logger.LogInformation(e.Message);
                throw;
            }

        }

        public IActionResult CheckInView(int id)
        {
            try
            {
               
                ViewBag.BookId = id;
                
                return View();
            }
            catch (Exception e)
            {
                _logger.LogInformation(e.Message);
                throw;
            }
           
        }

        public IActionResult Checkin(int Id, int BookId)
        {
            try
            {
                Book book = _bookRepository.GetById(BookId);
                Checkout checkout = _checkoutRepository.GetById(Id);
                _checkoutRepository.Delete(checkout.Id);
                book.IsCheckedOut = false;
                _bookRepository.Update(book, BookId);

                return Ok("Checkout has been deleted");
            }
            catch (Exception e)
            {
                _logger.LogInformation(e.Message);
                throw;
            }

        }
        [HttpGet]
        public Checkout GetByBookId()
        {
            try
            {
                var id = Convert.ToInt32(Request.Query["id"]);
                return _checkoutRepository.GetByBookId(id);
            }
            catch (Exception e)
            {
                _logger.LogInformation(e.Message);
                throw;
            }
            
        }

        [HttpGet]
        public Customer GetCustomerWithCheckoutId()
        {
            try
            {
                var id = Convert.ToInt32(Request.Query["id"]);
                Checkout checkout = _checkoutRepository.GetById(id);
                return _customerRepo.GetById(checkout.CustomerId);
            }
            catch (Exception e)
            {
                _logger.LogInformation(e.Message);
                throw;
            }
           
        }

    }
}
