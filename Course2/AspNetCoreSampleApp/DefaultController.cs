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

    [HttpGet("time/tomorrow")]
    public ActionResult<DateTime> Time()
    {
        return Ok(DateTime.Now + TimeSpan.FromDays(1));
    }
}