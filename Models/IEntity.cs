using System.ComponentModel.DataAnnotations;

namespace Profit_Homework_MvC.Models
{
	public interface IEntity
	{
		[Key]
		public int Id { get; set; }
	}

}
