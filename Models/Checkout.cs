using System.ComponentModel.DataAnnotations;

namespace Profit_Homework_MvC.Models
{
    public class Checkout : BaseEntity
    {
        private DateTime _checkOutDate;

       
        public DateTime CheckOutDate
        {
            get { return _checkOutDate; }
            set
            {
                _checkOutDate = value;

                ExpectedReturnDate = _checkOutDate.AddDays(15);
            }
        }

        public DateTime ExpectedReturnDate { get; set; }

        public Book Book { get; set; }

        public int BookId { get; set; }

        public Customer Customer { get; set; }

        public int CustomerId { get; set; }
    }
}
