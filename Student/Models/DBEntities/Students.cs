using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//using System.ComponentModel.DataAnnotations.Schema;

namespace Student.Models.DBEntities
{
	public class Students
	{

        [Key]	
        public int Id { get; set; } 
        public string StuId { get; set; }
        public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Department { get; set; }
        public string Region { get; set; }
        public string RoomNo { get; set; }
		public string Year { get; set; }
        public string Gender { get; set; }
        public string Password { get; set; }
        
    }
	public class Items
	{
        [Key]
        public int Id { get; set; }

        [ForeignKey("StuId")]
        public string StuId { get; set; }
        public string FirstName { get; set; }
		public string LastName { get; set; }
        public string Locker { get; set; }
        public string Bed { get; set; }
        public string Table { get; set; }
        public string Chair { get; set; }
        public string Mirror { get; set; }
        public string Foam { get; set; }
        public string Mop { get; set; }
       

    }
	//public class Login : Students{}
    
    public class Admin
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get;set; }
    }
     
}
