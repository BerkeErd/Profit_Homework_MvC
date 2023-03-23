using Microsoft.AspNetCore.Mvc;
using Profit_Homework_MvC.Models;
using Profit_Homework_MvC.Repository.BookRepo;
using Profit_Homework_MvC.Repository.CustomerRepo;

namespace Profit_Homework_MvC.Controllers
{
    public class CustomerController : Controller
    {
       private readonly ICustomerRepo _customerRepo;

        public CustomerController(ICustomerRepo customerRepo)
        {
            _customerRepo = customerRepo;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateCustomerView()
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult CreateCustomer(Customer customer) 
        {
            try
            {
                _customerRepo.Add(customer);
                return Ok("Customer Created");
            }
            catch (Exception)
            {
                //log
                throw;
            }
            
        }

        [HttpGet]
        public List<Customer> GetAll()
        {
            return _customerRepo.GetAll();
        }
    }
}
