using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MOJECIEAPP.Controllers
{
    public class AuthenticationController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        void connectionString()
        {
            con.ConnectionString = Config.StoreConnection.GetConnection();
        }
        // GET: Authentication
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string Username , string Password)
        {
            string username = "";
            bool found = false;
            SqlDataReader dr;
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "Select * from Users where Username = '" + Username + "'and Password = '" + Password + "'";
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                found = true;
                username = dr["Username"].ToString();
                FormsAuthentication.SetAuthCookie(Username, true);
                Session["Username"] = Username.ToString();
                return RedirectToAction("Upload", "MOJECIE");
            }
            else
            {
                ViewBag.Error = "Invalid Login";
            }
            return View();
        }
    }
}