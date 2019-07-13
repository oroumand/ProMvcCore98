using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Session14.Validations.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Session14.Validations.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ViewResult MakeBooking(Appointment appt)
        {
            //if (string.IsNullOrEmpty(appt.ClientName))
            //{
            //    ModelState.AddModelError(nameof(appt.ClientName),"Please enter your name");
            //}
            //else if(appt.ClientName.Length <3)
            //{
            //    ModelState.AddModelError(nameof(appt.ClientName), "Please name with more tahn 3 character length");
            //}
            if (ModelState.GetValidationState("Date")
            == ModelValidationState.Valid && !(DateTime.Now.Date <= appt.Date.Date))
            {
                ModelState.AddModelError(nameof(appt.Date),
                "Please enter a date in the future");
            }

            if (!appt.TermsAccepted)
            {
                ModelState.AddModelError(nameof(appt.TermsAccepted),
                "You must accept the terms");
            }
            if(!string.IsNullOrEmpty(appt.ClientName) && ModelState.GetValidationState("Date")
            == ModelValidationState.Valid && (appt.ClientName == "Shamekhi" && appt.Date.Date == DateTime.Now.Date))
            {
                ModelState.AddModelError("", "You can not select today");
            }
            if (ModelState.IsValid)
            {
                return View("Completed", appt);
            }
            else
            {
                return View("Index");
            }
        }

        public JsonResult ValidateUserName(string userName)
        {
            return Json(true);
        }
    }
}
