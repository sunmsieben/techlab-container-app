using Dapr.Client;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace techlab_dapr_frontend.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly DaprClient _daprClient;
    private readonly IConfiguration _configuration;

    public IndexModel(ILogger<IndexModel> logger, DaprClient daprClient, IConfiguration configuration)
    {
        _logger = logger;
        _daprClient = daprClient;
        _configuration = configuration;
    }

    public async Task OnGet()
    {
        _logger.LogInformation("Retrieving cats");
        var cats = await _daprClient.InvokeMethodAsync<IEnumerable<Cat>>(
        HttpMethod.Get,
        "techlab-dapr-backend",
        "cat");

        ViewData["catData"] = cats;

        string techlabSecret = _configuration["techlab:secret"];

        ViewData["keyvault"] = techlabSecret;
    }
}