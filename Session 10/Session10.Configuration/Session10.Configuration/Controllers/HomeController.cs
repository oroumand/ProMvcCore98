using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Session10.Configuration.Infrastructures;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Session10.Configuration.Controllers
{
    public class HomeController : Controller
    {
        private readonly UptimeService uptimeService;
        private readonly IConfiguration configuration;
        private readonly ILogger<HomeController> logger;

        public HomeController(UptimeService uptimeService,IConfiguration configuration,ILogger<HomeController> logger)
        {
            this.uptimeService = uptimeService;
            this.configuration = configuration;
            this.logger = logger;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            logger.LogInformation("---------------------------------");
            logger.LogInformation($"Request start at {DateTime.Now}");

            Dictionary<string, string> valuePairs = new Dictionary<string, string>
            {
                ["Message"] = "Hello world from index action",
                ["Uptime"] = $"Service uptime i: {uptimeService.GetUptime} ms",
                ["ConfigValue"] = configuration["MyUserName"],
                ["PersonalData"] = configuration["PersonalData:FirstName"]
            };
            logger.LogInformation("---------------------------------");
            logger.LogInformation($"Request finished at {DateTime.Now}");
            logger.LogInformation("---------------------------------");

            return View(valuePairs);
        }
    }
}
