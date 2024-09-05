using Microsoft.AspNetCore.Mvc;
using ProjetoAvaliação.Models;
using System;

namespace ProjetoAvaliação.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private List<PersonModel> persons = new List<PersonModel>();
        public PersonController(ILogger<PersonController> logger)
        {
            _logger = logger;
            persons.Add(new PersonModel(1, "Hugo", 29));
            persons.Add(new PersonModel(2, "Isabel", 52));
            persons.Add(new PersonModel(3, "Victória", 27));
            persons.Add(new PersonModel(4, "Fernanda", 28));
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(persons);
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var resposta = persons.FirstOrDefault(i => i.Id == id);
            return Ok(resposta);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var Result = persons.First(x => x.Id == id);
            persons?.Remove(Result);
            return Ok(persons);
        }

        [HttpPost]
        public IActionResult Create([FromBody] PersonModel model)
        {
            persons.Add(model);
            return StatusCode(StatusCodes.Status201Created, persons);
        }

        [HttpPut("{id:int}")]
        public IActionResult Update([FromRoute] int id, [FromBody] PersonModel model)
        {
            if (id > persons.Max(x => x.Id))
                return BadRequest("este id não pode ser utilizado");

            var resposta = persons.First(x => x.Id == id);
            persons?.Remove(resposta);
            persons?.Add(model);
            return Ok(model);
        }

        [HttpPatch("{id:int}/{name}")]
        public IActionResult Update2([FromRoute] int id, [FromRoute] string name)
        {
            if (id > persons.Max(x => x.Id))
                return BadRequest("este id não pode ser utilizado");

            var resposta = persons.First(x => x.Id == id);
            resposta.Name = name;
            return Ok(resposta);
        }
    }
}