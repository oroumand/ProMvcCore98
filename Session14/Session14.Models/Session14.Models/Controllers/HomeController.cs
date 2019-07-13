using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Session14.Models.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Session14.Models.Controllers
{
    public class HomeController : Controller
    {
        // GET: /<controller>/
        private readonly IRepository _repository;

        public HomeController(IRepository repository)
        {
            _repository = repository;
        }


        public ViewResult Index([FromQuery]int? id) {

            return View(_repository.GetPerson(id ?? 0));
        }
        public IActionResult Create()
        {
            return View(new Person());
        }
        [HttpPost]
        public IActionResult Create(Person person)
        {
            return View();
        }
        //public IActionResult DisplaySummary([Bind("City","Country", Prefix = "HomeAddress")] AddressSummary addressSummary)
        public IActionResult DisplaySummary([Bind(Prefix = "HomeAddress")] AddressSummary addressSummary)
        {
            return Json(addressSummary);
        }

        public IActionResult Names()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Names(List<string> fullNames,List<int> selectedValues)
        {
            return Ok(fullNames);
        }

        public IActionResult People()
        {
            return View(new PersonSummary());
        }
        [HttpPost]
        public IActionResult People(List<PersonSummary> personSummaries)
        {
            return Ok(personSummaries);
        }


        public IActionResult HeaderDate([FromHeader]string accept)
        {
            return Json(accept);
        }

    }
}
