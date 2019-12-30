using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using startingTestconsoleApp.Models;
using responsibilityPattern;

namespace starting_guy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(new[] { "value1", "value2" });
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return Ok("value");
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] string value)
        {
            if (value == null)
            {
                return BadRequest("Value is null.");
            }
            var listAnimals = JsonConvert.DeserializeObject<List<Animal>>(value);

            var respond = AnimalClient.Processor(listAnimals);

            return Ok(respond);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string value)
        {
            return NoContent();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return NoContent();
        }
    }
}
