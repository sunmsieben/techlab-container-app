using Dapr;
using Microsoft.AspNetCore.Mvc;
using techlab_dapr_servicebus.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace techlab_dapr_servicebus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatController : ControllerBase
    {
        private readonly ILogger<CatController> _logger;

        public CatController(ILogger<CatController> logger)
        {
            _logger = logger;   
        }

        // GET: api/<CatController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CatController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CatController>
        [Topic("cat-pub-sub", "cat")]
        [HttpPost]
        public void Post(Cat cat)
        {
            _logger.LogInformation($"Cat recieved name: {cat.Name}");

            var color = cat.Color;
        }

        // PUT api/<CatController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CatController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
