using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Session20.APIControllers.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Session20.APIControllers.Controlles
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public string Get()
        {
            return "HelloWorld";
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        [Produces(contentType: "application/json")]
        public Person Get(int id)
        {
            return new Person
            {
                Id = id,
                FirstName = "Alireza",
                LastName = "Oroumand"
            };
        }

        // POST api/<controller>
        [HttpPost]
        public int Post()
        {
            return 1;
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
