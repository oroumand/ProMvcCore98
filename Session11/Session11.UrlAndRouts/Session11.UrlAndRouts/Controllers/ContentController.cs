using Microsoft.AspNetCore.Mvc;
using Session11.UrlAndRouts.Models;

namespace Session11.UrlAndRouts.Controllers
{
    public class ContentController : Controller
    {
        public ViewResult Index()
        {
            return View("Result",
                new Result
                {
                    Controller = nameof(ContentController),
                    Action = nameof(Index)
                });
        }
    }
}