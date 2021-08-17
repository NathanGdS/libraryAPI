using LibraryAPI.Business;
using Microsoft.AspNetCore.Mvc;
using LibraryAPI.Data.VO;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace LibraryAPI.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Authorize("Bearer")]
    [Route("api/v{version:ApiVersion}/[controller]")]
    public class PersonController : ControllerBase
    {
  
        private readonly IPersonBusiness _personBusiness;

        public PersonController(IPersonBusiness personBusiness)
        {
            _personBusiness = personBusiness;
        }

        [HttpGet]
        [ProducesResponseType((200), Type = typeof(List<PersonVO>))]
        [ProducesResponseType((204))]
        [ProducesResponseType((400))]
        [ProducesResponseType((401))]
        public IActionResult GetPeople()
        {
            return Ok(_personBusiness.FindAll());
        }
        
        [HttpGet("{id}")]
        [ProducesResponseType((200), Type = typeof(PersonVO))]
        [ProducesResponseType((204))]
        [ProducesResponseType((400))]
        [ProducesResponseType((401))]
        public IActionResult FindOne(long id)
        {
            var person = _personBusiness.FindByID(id);

            if(person == null) return NotFound();

            return Ok(person);
        }
        
        [HttpPost]
        [ProducesResponseType((200), Type = typeof(PersonVO))]
        [ProducesResponseType((400))]
        [ProducesResponseType((401))]
        public IActionResult Create([FromBody] PersonVO person)
        {
            if (person == null) return BadRequest("Invalid Input!");
            return Ok(_personBusiness.Create(person));
        }        

        [HttpPut]
        [ProducesResponseType((200), Type = typeof(PersonVO))]
        [ProducesResponseType((400))]
        [ProducesResponseType((401))]
        public IActionResult Update([FromBody] PersonVO person)
        {
            if (person == null) return BadRequest("Invalid Input!");
            return Ok(_personBusiness.Update(person));
        }

        [HttpPatch("{id}")]
        [ProducesResponseType((200), Type = typeof(PersonVO))]
        [ProducesResponseType((204))]
        [ProducesResponseType((400))]
        [ProducesResponseType((401))]
        public IActionResult Disable(long id)
        {
            var person = _personBusiness.Disable(id);

            if (person == null) return NotFound();

            return Ok(person);
        }


        [HttpDelete("{id}")]
        [ProducesResponseType((204))]
        [ProducesResponseType((400))]
        [ProducesResponseType((401))]
        public IActionResult Delete(long id)
        {
            var person = _personBusiness.FindByID(id);

            if (person == null) return NotFound();

            _personBusiness.Delete(id);

            return NoContent();
        }
    }
}
