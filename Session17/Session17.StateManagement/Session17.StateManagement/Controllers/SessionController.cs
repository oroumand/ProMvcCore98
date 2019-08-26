using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Session17.StateManagement.Controllers
{
    public static class SessionHelpers
    {
        public static T Get<T>(this HttpContext httpContext,string key)
        {
            return JsonConvert.DeserializeObject<T>(httpContext.Session.GetString(key));
        }
        public static void Set<T>(this HttpContext httpContext,string key,T inputValue)
        {
            httpContext.Session.SetString(key, JsonConvert.SerializeObject(inputValue));
        }
    }
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    public class SessionController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.SessionId = HttpContext.Session.Id;
            WriteToSession("MyFirstName", new Person
            {
                FirstName = "Alireza",
                LastName = "Oroumand"
            });
            return View();
        }

        private void WriteToSessionMem(string key, Person value)
        {
            BinaryFormatter bf = new BinaryFormatter();

            using (MemoryStream sr =new MemoryStream())
            {
                bf.Serialize(sr, value);
                var bytes = sr.ToArray();
                HttpContext.Session.Set(key, bytes);
            }
            
        }
        private void WriteToSession(string key, Person value)
        {
            HttpContext.Session.SetString(key, Newtonsoft.Json.JsonConvert.SerializeObject(value));
        }
        private void ReadFromSession(string key)
        {
            var result = HttpContext.Session.GetString(key);

        }
    }
}
