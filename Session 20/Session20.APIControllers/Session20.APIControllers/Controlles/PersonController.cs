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
    public class PersonController : Controller
    {
        private readonly PersonRepository personRepo;

        public PersonController(PersonRepository person)
        {
            this.personRepo = person;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = personRepo.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = personRepo.Get(id);
            if (result == null || result?.Id < 1)
                return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Person value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            personRepo.Add(value);
            return Created("api/Person/"+ value.Id, value);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Person value)
        {
           
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
