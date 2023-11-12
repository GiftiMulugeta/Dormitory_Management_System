using Microsoft.EntityFrameworkCore;
using Student.Models.DBEntities;
using Student.Models;

namespace Student.DAL
{
	public class StudentsDbContext : DbContext
	{
		public StudentsDbContext(DbContextOptions options) : base(options)
		{
		}

		public DbSet<Students> Student { get; set; }
		public DbSet<Items> Item { get; set; }
		public DbSet<Admin> AdminLogin { get; set; }	
        public DbSet<Student.Models.StudentsViewModel>? StudentsViewModel { get; set; }

    }
}
