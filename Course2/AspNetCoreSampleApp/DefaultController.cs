using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;

namespace AspNetCoreSampleApp;

[Controller]
[Route("[controller]")]
public class DefaultController: Controller
{
    private readonly ITimeService _timeService;

    public DefaultController(ITimeService timeService)
    {
        _timeService = timeService;
    }
    
    [HttpGet("index")]
    public IActionResult Index()
    {
        return Ok(_timeService.GetCurrentTime());
    }
}