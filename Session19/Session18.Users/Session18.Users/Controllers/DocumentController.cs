using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Session18.Users.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Session18.Users.Controllers
{
    public class DocumentController : Controller
    {
        private IAuthorizationService authService;
        public DocumentController(IAuthorizationService auth)
        {
            authService = auth;
        }
        private ProtectedDocument[] docs = new ProtectedDocument[] {
            new ProtectedDocument { Title = "ASP.NET Core", Author = "Alireza",Editor = "Mahdi"},
            new ProtectedDocument { Title = "Project Plan", Author = "Iman",Editor = "Alireza"},
            new ProtectedDocument { Title = "MongoDB", Author = "Mahdi",Editor = "Alireza"}
            };
        public ViewResult Index() => View(docs);


        public async Task<IActionResult> Edit(string title)
        {
            ProtectedDocument doc = docs.FirstOrDefault(d => d.Title == title);
            AuthorizationResult authorized = await authService.AuthorizeAsync(User,doc, "AuthorsAndEditors");
            if (authorized.Succeeded)
            {
                return View("Index", doc);
            }
            else
            {
                return new ChallengeResult();
            }
        }
    }
}
