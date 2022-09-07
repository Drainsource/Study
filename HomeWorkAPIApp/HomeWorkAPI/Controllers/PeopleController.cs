using Microsoft.AspNetCore.Mvc;
using DemoLibrary;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HomeWorkAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private ILogger<PeopleController> _logger;

        public PeopleController(ILogger<PeopleController> logger)
        {
            _logger = logger;
        }

        // POST api/<PeopleController>
        [HttpPost]
        public void Post([FromBody] PersonModel person)
        {
            _logger.LogInformation("The Person name was {firstName} {lastName} and active is {isActive}", person.FirstName, person.LastName, person.IsActive);
        }

    }
}
