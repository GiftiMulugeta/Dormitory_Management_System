using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Student.Models.DBEntities;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;

namespace Student.Controllers
{

    public class AccountController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        void connectionString()
        {
            con.ConnectionString = "server=.; database=student; integrated security = true; TrustServerCertificate=True";
        }
        [HttpPost]
        public IActionResult Verify(Students acc)
        {
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "select * from Student where StuId = '" + acc.StuId + "' and Password='" + acc.Password + "'";
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                con.Close();
                HttpContext.Session.SetString("StuId", acc.StuId);
                //HttpContext.Session.SetString("user", acc.Role = "");
                
                return RedirectToAction("Index", "Students");
              
                
            }
            else
            {
                con.Close();
                return View("Login");
            }
        }
        public IActionResult Logout()
        {

            return RedirectToAction("Login", "Account");
        }

    }
}
