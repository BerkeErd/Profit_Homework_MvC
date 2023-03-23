using Profit_Homework_MvC.Data;
using Profit_Homework_MvC.Models;

namespace Profit_Homework_MvC.Repository.BookRepo
{
	public class BookRepository : GenericRepository<Book>, IBookRepository
	{
		
		public BookRepository(Appdbcontext appdbcontext) : base (appdbcontext)
		{
		}
		
	}
}
