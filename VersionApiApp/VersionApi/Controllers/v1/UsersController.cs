using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VersionApi.Controllers.v1;

[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
[ApiVersion("1.0", Deprecated = true)]
public class UsersController : ControllerBase
{
    // GET: api/<Users>
    [HttpGet]
    public IEnumerable<string> Get()
    {
        return new string[] { "Version 1 value 1", "Version 1 value 2" };
    }

}
