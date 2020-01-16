using System.Collections.Generic;
using AutoMapper;
using EFBusinessCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using responsibilityPattern;
using responsibilityPattern.Models;
using starting_guy.Models;

namespace starting_guy.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProcessorController : Controller
    {
        private readonly IMapper _mapper;

        public ProcessorController(IMapper mapper)
        {
            _mapper = mapper;
        }

        // Post api/processor
        [HttpPost]
        public IActionResult Post([FromBody] object value)
        {
            if (value == null)
            {
                return BadRequest("Value is null.");
            }
            
            IEnumerable<AnimalDto> listAnimalsDto = JsonConvert.DeserializeObject<List<AnimalDto>>(value.ToString());
            var listAnimals = _mapper.Map<IEnumerable<AnimalDto>, IEnumerable<Animal>>(listAnimalsDto);
            
            var respond = AnimalClient.Processor(listAnimals);
            if (respond == "")
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return Ok(respond);
        }
    }
}