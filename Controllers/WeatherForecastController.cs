using Microsoft.AspNetCore.Mvc;

namespace TestWebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }

    [HttpGet("FromUrl")]
    public IActionResult FromUrl(string teste)
    {
        return Ok(new { teste = "dd             "});
    }

    [HttpPost("FromForm")]
    public IActionResult FromForm([FromForm] WeatherForecast model)
    {
        return Ok(model);
    }    

    [HttpPost("FromBody")]
    public IActionResult FromBody([FromBody] WeatherForecast model)
    {
        return Ok(model);
    }

    [HttpPost("PostWithoutFromBody")]
    public IActionResult PostWithoutFromBody(WeatherForecast model)
    {
        return Ok(model);
    }    


    [HttpPut("FromQuery")]
    public IActionResult FromQuery([FromQuery] WeatherForecast model)
    {
        return Ok(model);
    }        
}
