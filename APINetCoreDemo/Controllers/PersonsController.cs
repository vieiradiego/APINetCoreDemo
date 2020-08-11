using APINetCoreDemo.Model;
using APINetCoreDemo.Services;
using Microsoft.AspNetCore.Mvc;

namespace APINetCoreDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonsController : ControllerBase
    {
        private IPersonService personService;

        public PersonsController(IPersonService personService)
        {
            this.personService = personService;
        }

        // POST /persons/
        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            if (person == null) return BadRequest();
            return new ObjectResult(this.personService.Create(person));
        }

        // PUT /persons/
        [HttpPut]
        public IActionResult Put([FromBody] Person person)
        {
            if (person == null) return BadRequest();
            return new ObjectResult(this.personService.Update(person));
        }

        // DELETE /persons/1
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            this.personService.Delete(id);
            return NoContent();
        }

        // GET /persons/
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(this.personService.FindAll());
        }

        // GET /persons/1
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var person = this.personService.FindById(id);
            if (person == null) return NotFound();
            return Ok(person);
        }
    }
}
