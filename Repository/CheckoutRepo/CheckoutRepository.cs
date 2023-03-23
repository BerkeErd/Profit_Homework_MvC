using Profit_Homework_MvC.Data;
using Profit_Homework_MvC.Models;

namespace Profit_Homework_MvC.Repository.CheckoutRepo
{
	public class CheckoutRepository : GenericRepository<Checkout>, ICheckoutRepository
	{
		
		public CheckoutRepository(Appdbcontext appdbcontext) : base(appdbcontext)
		{
		}

	}
}
