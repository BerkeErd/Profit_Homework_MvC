using System.ComponentModel.DataAnnotations;

namespace Profit_Homework_MvC.Models
{
	public class Checkout : BaseEntity
	{

        public Checkout()
        {
            ExpectedReturnDate = CheckOutDate.AddDays(15);
		}	

		public DateOnly CheckOutDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
		public DateOnly ExpectedReturnDate { get; set; } 

		public Book Book { get; set; }

		public int BookId { get; set; }
		public Customer Customer { get; set; }

		public int CustomerId { get; set; }
	}
}
