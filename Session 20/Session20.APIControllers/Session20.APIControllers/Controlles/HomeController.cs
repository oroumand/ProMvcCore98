using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Session20.APIControllers.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Session20.APIControllers.Controlles
{
    public class HomeController : Controller
    {
        private readonly PersonRepository personRepository;

        public HomeController(PersonRepository personRepository)
        {
            this.personRepository = personRepository;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(personRepository.GetAll());
        }
        public IActionResult AddPerson(Person person)
        {
            personRepository.Add(person);
            return RedirectToAction("Index");
        }
    }
}
