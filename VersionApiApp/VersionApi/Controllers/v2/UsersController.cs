using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VersionApi.Controllers.v2;

[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
[ApiVersion("2.0")]
public class UsersController : ControllerBase
{
    // GET: api/<Users>
    [HttpGet]
    public IEnumerable<string> Get()
    {
        return new string[] { "Version 2 value 1", "Version 2 value 2" };
    }

    // GET api/<Users>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    // POST api/<Users>
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/<Users>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<Users>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
