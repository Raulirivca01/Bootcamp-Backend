using Bootcamp.Queries.Person;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bootcamp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonQueries _personQueries;
        public PersonController(IPersonQueries personQueries)
        {
            _personQueries = personQueries;
        }

        [HttpGet]
        [Route("ReadAll")]
        public async Task<ActionResult> ReadAll()
        {
            var result = await _personQueries.ReadAll();
            return Ok(result);
        }
        [HttpGet]
        [Route("ReadById")]
        public async Task<ActionResult> ReadById([FromQuery] int id)
        {
            var result = await _personQueries.ReadById(id);
            return Ok(result);
        }
    }
}
