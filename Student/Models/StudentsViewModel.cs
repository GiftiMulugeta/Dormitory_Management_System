using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace Student.Models
{
	public class StudentsViewModel
	{
		[Key]
		[DisplayName("ID")]
		public string StuId { get; set; }

		[DisplayName("First Name")]
		public string FirstName { get; set; }

		[DisplayName("last Name")]
		public string LastName { get; set; }
        
        [DisplayName("Department")]
		public string Department { get; set; }

        [DisplayName("Year")]
        public string Year { get; set; }
        [DisplayName("Region")]
		public string Region { get; set; }

		[DisplayName("RoomNo")]
		public string RoomNo { get; set; }


		[DisplayName("Name")]
		public string FullName
		{
			get {return  FirstName + " " + LastName;}
		}

	}
}
