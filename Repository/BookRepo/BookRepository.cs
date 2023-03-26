using Profit_Homework_MvC.Data;
using Profit_Homework_MvC.Models;
using Profit_Homework_MvC.Repository.CheckoutRepo;

namespace Profit_Homework_MvC.Repository.BookRepo
{
	public class BookRepository : GenericRepository<Book>, IBookRepository
	{

        public BookRepository(Appdbcontext appdbcontext, ILogger<BookRepository> logger) : base(appdbcontext, logger)
        {

        }

    }
}
