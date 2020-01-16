using System.Collections.Generic;
using System.Threading.Tasks;
using EFBusinessCore;
using EFBusinessCore.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace starting_guy.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnimalController : ControllerBase
    {
        private readonly IDataRepository<Animal> _dataRepository;

        public AnimalController(IDataRepository<Animal> animalManager)
        {
            _dataRepository = animalManager;
        }

        // GET api/animal
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Animal>>> Get()
        {
            var animals = await _dataRepository.GetAll();
            return Ok(animals);
        }

        // GET api/animal/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Animal>> Get(int id)
        {
            var animal = await _dataRepository.Get(id);
 
            if (animal == null)
            {
                return NotFound("The Animal record couldn't be found.");
            }
            return Ok(animal);
        }

        // POST api/animal
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] string value)
        {
            if (value == null)
            {
                return BadRequest("Value is null.");
            }
            var animal = JsonConvert.DeserializeObject<Animal>(value);
            await _dataRepository.Add(animal);
            return CreatedAtRoute(
                    "Get", 
                    new { Id = animal.AnimalId },
                    animal);
        }

        // PUT api/animal/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Animal animal)
        {
            if (animal == null)
            {
                return BadRequest("The animal is null");
            }
            var animalToUpdate = await _dataRepository.Get(id);
            
            if (animalToUpdate == null)
            {
                return NotFound("The Animal record couldn't be found.");
            }
            await _dataRepository.Update(animal, animalToUpdate);
            return NoContent();
        }

        // DELETE api/animal/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var animal = await _dataRepository.Get(id);
            if (animal == null)
            {
                return NotFound("The Animal record couldn't be found.");
            }
            await _dataRepository.Delete(animal);
            return NoContent();
        }
    }
}
