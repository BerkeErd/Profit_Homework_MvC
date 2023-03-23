using Microsoft.AspNetCore.Mvc;
using Profit_Homework_MvC.Models;
using Profit_Homework_MvC.Repository.CheckoutRepo;

namespace Profit_Homework_MvC.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly ICheckoutRepository _checkoutRepository;

        public CheckoutController(ICheckoutRepository checkoutRepository)
        {
            _checkoutRepository = checkoutRepository;   
        }
        public IActionResult Index(int id)
        {
            ViewBag.BookId = id;
            return View();
        }

        public IActionResult CreateCheckout(Checkout checkout) 
        {
            try
            {
                _checkoutRepository.Add(checkout);
                return Ok("Checkout Created");
            }
            catch (Exception)
            {
                //log
                throw;
            }

        }
     

    }
}
