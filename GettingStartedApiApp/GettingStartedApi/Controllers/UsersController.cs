﻿using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GettingStartedApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    // GET: api/Users
    [HttpGet]
    public IEnumerable<string> Get()
    {
        List<string> output = new();

        for (int i = 0; i < Random.Shared.Next(2,10); i++)
        {
            output.Add($"Value #{i + 1}");
        }
        return output;
    }

    // GET api/Users/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return $"Value #{id}";
    }

    // POST api/Users
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/Users/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // PATCH
    // PATCH api/Users/5
    [HttpPatch("{id}")]
    public void Patch(int id, [FromBody] string value)
    {

    }

    // DELETE api/Users/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
