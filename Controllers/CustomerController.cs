using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Profit_Homework_MvC.Models;
using Profit_Homework_MvC.Repository.BookRepo;
using Profit_Homework_MvC.Repository.CustomerRepo;
using System.Data;

namespace Profit_Homework_MvC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CustomerController : Controller
    {
       private readonly ICustomerRepo _customerRepo;

       private readonly ILogger<CustomerController> _logger;
        public CustomerController(ICustomerRepo customerRepo, ILogger<CustomerController> logger)
        {
            _customerRepo = customerRepo;
            _logger = logger;

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
                _logger.LogInformation("Deneme");
                _customerRepo.Add(customer);
                return Ok("Customer Created");
            }
            catch (Exception e)
            {
                _logger.LogInformation(e.Message);
                throw;
            }
            
        }

        [AllowAnonymous]
        [HttpGet]
        public List<Customer> GetAll()
        {
            try
            {
                return _customerRepo.GetAll();
            }
            catch (Exception e)
            {
                _logger.LogInformation(e.Message);
                throw;
            }
            
        }
    }
}
