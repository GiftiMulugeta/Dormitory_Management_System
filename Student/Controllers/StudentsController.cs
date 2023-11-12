using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Student.DAL;
using Student.Models;
using Microsoft.AspNetCore.Session;
using Microsoft.EntityFrameworkCore;
using Student.Models.DBEntities;

namespace Student.Controllers
{
    //[Authorize]
    public class StudentsController : Controller
    {
        private readonly StudentsDbContext _context;
        public StudentsController(StudentsDbContext context)
        {
            this._context = context;
        }
        public async Task<IActionResult> Index()
        {
            List<StudentsViewModel> studentsList = new List<StudentsViewModel>();
            //var stid = Session["StuId"];
            var stid = HttpContext.Session.GetString("StuId");
            
            var students = await _context.Student.Where(s => s.StuId == stid).ToListAsync();
           
            if (students != null)
            {
                foreach (var student in students)
                {
                    var StudentsViewModel = new StudentsViewModel()
                    {
                        StuId = student.StuId,
                        FirstName = student.FirstName,
                        LastName = student.LastName,
                        Department = student.Department,
                        Year = student.Year,
                        Region = student.Region,
                        RoomNo = student.RoomNo,
                    };
                    studentsList.Add(StudentsViewModel);
                }
                return View(studentsList);
            }
            return View(studentsList);
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(Students context)
        {

            _context.Add(context);
            _context.SaveChanges();
            return View();
            //return View();
        }

    }
}
