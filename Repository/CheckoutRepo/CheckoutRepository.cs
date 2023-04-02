using Profit_Homework_MvC.CacheHelper;
using Profit_Homework_MvC.Data;
using Profit_Homework_MvC.Models;

namespace Profit_Homework_MvC.Repository.CheckoutRepo
{
	public class CheckoutRepository : GenericRepository<Checkout>, ICheckoutRepository
	{

        public CheckoutRepository(Appdbcontext appdbcontext, ILogger<CheckoutRepository> logger, Func<CacheTech, ICacheService> cacheService) : base(appdbcontext, logger, cacheService)
        {
           
        }

        public Checkout GetByBookId(int bookId)
        {
            try
            {
                return _appdbcontext.Set<Checkout>().SingleOrDefault(x => x.BookId == bookId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
    }
}
