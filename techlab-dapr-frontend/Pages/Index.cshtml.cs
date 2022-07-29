using Dapr.Client;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace techlab_dapr_frontend.Pages;

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
        _logger.LogInformation("Retrieving cats");
        var cats = await _daprClient.InvokeMethodAsync<IEnumerable<Cat>>(
        HttpMethod.Get,
        "techlab-dapr-backend",
        "cat");

        ViewData["catData"] = cats;
    }
}