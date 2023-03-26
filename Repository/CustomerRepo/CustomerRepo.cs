using Profit_Homework_MvC.Data;
using Profit_Homework_MvC.Models;
using Profit_Homework_MvC.Repository.CheckoutRepo;

namespace Profit_Homework_MvC.Repository.CustomerRepo
{
	public class CustomerRepo : GenericRepository<Customer>, ICustomerRepo
	{

        public CustomerRepo(Appdbcontext appdbcontext, ILogger<CustomerRepo> logger) : base(appdbcontext, logger)
        {

        }
    }
}
