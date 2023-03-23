using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Profit_Homework_MvC.Models
{
	public class Customer : BaseEntity
	{
		[Required]
		public string FirstName { get; set; }

		[Required]
		public string LastName { get; set; }

		[Required]
		public string PhoneNum { get; set; }

		[Required]
		public string IdNumber { get; set; }

	}
}
