using Profit_Homework_MvC.Models;

namespace Profit_Homework_MvC.Repository.CheckoutRepo
{
	public interface ICheckoutRepository : IRepository<Checkout>
	{
        public Checkout GetByBookId(int Bookid);
    }
}
