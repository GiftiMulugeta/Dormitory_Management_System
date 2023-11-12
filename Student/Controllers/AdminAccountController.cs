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

	public class AdminAccountController : Controller
	{
		SqlConnection con = new SqlConnection();
		SqlCommand com = new SqlCommand();
		SqlDataReader dr;

		[HttpGet]
		public IActionResult AdminLogin()
		{
			return View();
		}
		void connectionString()
		{
			con.ConnectionString = "server=.; database=student; integrated security = true; TrustServerCertificate=True";
		}
		[HttpPost]
		public IActionResult AdminVerify(Admin adm)
		{
			connectionString();
			con.Open();
			com.Connection = con;
			com.CommandText = "select * from AdminLogin where Username = '" + adm.Username + "' and Password='" + adm.Password + "'";
			dr = com.ExecuteReader();
			if (dr.Read())
			{
				con.Close();
				//HttpContext.Session.SetString("StuId", acc.StuId);
				//HttpContext.Session.SetString("user", acc.Role = "");

				return RedirectToAction("Index", "AdminDashboard");


			}
			else
			{
				con.Close();
				return View("AdminLogin");
			}
		}
		public IActionResult AdminLogout()
		{

			return RedirectToAction("AdminLogin", "AdminAccount");
		}

	}
}
