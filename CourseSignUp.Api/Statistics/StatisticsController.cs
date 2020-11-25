using CourseSignUp.Repository;
using CourseSignUp.Service;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace CourseSignUp.Api.Statistics
{
  [ApiController, Route("[controller]")]
  public class StatisticsController : ControllerBase
  {
    private readonly IStatisticsService service;

    public StatisticsController(IStatisticsService statisticsService)
    {
      service = statisticsService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
      var result = await service.GetCacheStatistic().ConfigureAwait(false);

      return Ok(result.Select(x => new CourseStatistics(x)));
    }
  }
}