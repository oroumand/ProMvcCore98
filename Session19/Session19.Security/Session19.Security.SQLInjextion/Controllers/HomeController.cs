using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Session19.Security.SQLInjextion.Models;

namespace Session19.Security.SQLInjextion.Controllers
{
    public class HomeController : Controller
    {
        public object Index(string userName,string password)
        {
            userName = "alireza' or 1=1 --";
            string sql = "Select * from Users where userName = '" + userName + "' and password = '"
                + password + "'";
            SqlConnection connection = new SqlConnection("Server=.\\SQL2017;Database=InjectionTest" +
                ";Trusted_Connection=True;MultipleActiveResultSets=true");

            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();
            var id = command.ExecuteScalar();
            if(id != null)
            {
                return id;
            }
            return "NotFound";

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
