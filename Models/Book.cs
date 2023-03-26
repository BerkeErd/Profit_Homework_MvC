using System.ComponentModel.DataAnnotations;

namespace Profit_Homework_MvC.Models
{
	public class Book : BaseEntity
	{

		[Required]
		public string Title { get; set; }

		public string ISBN { get; set; }

		public DateOnly PublishDate { get; set; }

		public float Price { get; set; }

		public bool IsCheckedOut { get; set; }



	}
}
