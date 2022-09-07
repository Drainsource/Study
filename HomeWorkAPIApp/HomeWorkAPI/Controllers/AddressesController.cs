using Microsoft.AspNetCore.Mvc;
using DemoLibrary;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HomeWorkAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private ILogger<AddressesController> _logger;

        public AddressesController(ILogger<AddressesController> logger)
        {
            _logger = logger;
        }

        // POST api/<Addresses>
        [HttpPost]
        public void Post([FromBody] AddressModel address)
        {
            _logger.LogInformation(
            "The Person name was {streetAddress} {City} {State}", 
            address.StreetAddress,
            address.City, 
            address.State);

        }
    }
}
