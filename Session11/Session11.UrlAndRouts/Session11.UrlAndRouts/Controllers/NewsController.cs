using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Session11.UrlAndRouts.Models;

namespace Session11.UrlAndRouts.Controllers
{
    public class NewsController : Controller
    {
        public ViewResult Default(int id)
        {
            var result = new Result
            {
                Controller = nameof(NewsController),
                Action = nameof(Default),
            };
            result.Data["id"] = id;

            return View("Result", result);
        }
    }
}