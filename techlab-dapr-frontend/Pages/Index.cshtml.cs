using Microsoft.AspNetCore.Mvc;
using Dapr.Client;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace techlab_dapr_frontend.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly DaprClient _daprClient;
        public IndexModel(ILogger<IndexModel> logger, DaprClient daprClient)
        {
            _logger = logger;
            _daprClient = daprClient;
        }

        public async Task OnGet()
        {
            _logger.LogInformation("Retrieving weatherforcast");
            var forecasts = await _daprClient.InvokeMethodAsync<IEnumerable<WeatherForecast>>(
            HttpMethod.Get,
            "techlab-dapr-backend",
            "weatherforecast");

            ViewData["WeatherForecastData"] = forecasts;
        }
    }
}