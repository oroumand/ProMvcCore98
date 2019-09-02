using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Session18.Users.Controllers
{
    public class RoleManagerController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public RoleManagerController(RoleManager<IdentityRole> role)
        {
            this.roleManager = role;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            var roles = roleManager.Roles.ToList();
            return View(roles);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(string name)
        {
            if (!roleManager.RoleExistsAsync(name).Result)
            {
                var result = roleManager.CreateAsync(new IdentityRole(name)).Result;
            }
            return RedirectToAction("Index");
        }
        public IActionResult Delete(string id)
        {
            
            var role = roleManager.FindByIdAsync(id).Result;
            if(role != null)
            {
                var result = roleManager.DeleteAsync(role).Result;
            }

            return RedirectToAction("Index");
        }
    }
}
