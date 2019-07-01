using System;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Session13.ControllersAndActions.Infrastructures;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Session13.ControllersAndActions.Controllers
{
    public class Home : Controller
    {
        public string Index() => "Hello From Home Controller";

        public IActionResult HeaderData()
        {

            var headers = Request.Headers.ToDictionary(c => c.Key, c => c.Value.First());
            return View("DictionaryResult", headers);
        }

        public ViewResult SimpleForm() => View("SimpleForm");

        public ViewResult ReceiveForm01()
        {
            var name = Request.Form["name"];
            var city = Request.Form["city"];
            return View("Result", $"{name} lives in {city}");
        }
        public ViewResult ReceiveForm02(string name,string city)
        {

            return View("Result", $"{name} lives in {city}");
        }


        public void ReceiveForm03(string name, string city)
        {

            Response.StatusCode = 200;
            Response.ContentType = "text/html";
            byte[] content = Encoding.ASCII
            .GetBytes($"<html><body>{name} lives in {city}</body>");
            Response.Body.WriteAsync(content, 0, content.Length);
        }

        public IActionResult ReceiveForm(string name, string city)
        {
            return new MyHtmlActionResult()
            {
                Content = $"{name} lives in {city}"
            };

        }


        public IActionResult ReceiveJson(string name, string city)
        {
            var obj = new
            {
                name,
                city
            };
            return new MyJsonResult()
            {
                Content = obj
            };

        }
    }
}
