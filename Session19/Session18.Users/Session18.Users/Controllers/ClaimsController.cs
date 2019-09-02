using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Session18.Users.Controllers
{
    public class ClaimsController : Controller
    {
        // GET: /<controller>/
        [Authorize]
        public ViewResult Index() => View(User?.Claims);


        [Authorize(Policy = "AllState")]
        public string All() => "All Location";

        [Authorize(Policy = "Tehran")]
        public string Tehran() => "Tehran Location";


        [Authorize(Policy = "DC")]
        public string DC() => "DC Location";



        [Authorize(Policy = "NotMahdi")]
        public string NotMahdi() => "NotMahdi";
    }
}
