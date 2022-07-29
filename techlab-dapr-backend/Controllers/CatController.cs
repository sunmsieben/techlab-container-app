using Microsoft.AspNetCore.Mvc;

namespace techlab_dapr_backend.Controllers;

[ApiController]
[Route("[controller]")]
public class CatController : ControllerBase
{
    private static readonly string[] Names = new[]
    {
        "Puma", "Peter", "Saffron", "Mc Agile", "Mr Curiousclaws", "Mr Peculiar of Canada", "Raven", "Silhouette", "Batman"
    };

    private static readonly string[] Colors = new[]
    {
        "Orange", "Black", "Yellow", "Red", "Gray"
    };

    private readonly ILogger<CatController> _logger;

    public CatController(ILogger<CatController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetCat")]
    public IEnumerable<Cat> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new Cat
        {
            Name = Names[Random.Shared.Next(Names.Length)],
            Color = Colors[Random.Shared.Next(Colors.Length)]
        })
        .ToArray();
    }
}
