using MessageWallAPI.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MessageWallAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageWallController : ControllerBase
    {
        private readonly ILogger<MessageWallController> _logger;

        public MessageWallController(ILogger<MessageWallController> logger)
        {
            _logger = logger;
        }
        // GET: api/<MessageWallController>
        [HttpGet]
        public string Get(string firstName = "", string lastName = "")
        {
            return $"Hi {firstName} {lastName}";
        }


        // POST api/<MessageWallController>
        [HttpPost]
        public void Post([FromBody] MessageModel message)
        {
            _logger.LogInformation("Our message was {Message}", message.Message);
        }

        // PUT api/<MessageWallController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MessageWallController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
