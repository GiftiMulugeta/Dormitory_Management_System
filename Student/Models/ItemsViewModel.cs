using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Student.Models
{
	public class ItemsViewModel
	{
		[Key]
		[DisplayName("ID")]
		public string StuId { get; set; }

		[DisplayName("Locker")]
		public string Locker { get; set; }

		[DisplayName("Bed")]
		public string Bed { get; set; }

		[DisplayName("Table")]
		public string Table { get; set; }

		[DisplayName("Chair")]
		public string Chair { get; set; }

		[DisplayName("Mirror")]
		public string Mirror { get; set; }

		[DisplayName("Foam")]
		public string Foam { get; set; }

		[DisplayName("Mop")]
		public string Mop { get; set; }
	}
}
