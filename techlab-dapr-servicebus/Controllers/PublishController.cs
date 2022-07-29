using Dapr.Client;
using Google.Type;
using Microsoft.AspNetCore.Mvc;
using techlab_dapr_servicebus.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace techlab_dapr_servicebus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishController : ControllerBase
    {
        // GET: api/<PublishController>
        [HttpGet]
        public async Task Get()
        {
            var cat = new Cat
            {
                Name = "Garfield",
                Color = "Orange"
            };

            var daprClient = new DaprClientBuilder().Build();

            await daprClient.PublishEventAsync("cat-pub-sub", "cat", cat);
            
        }
    }
}
