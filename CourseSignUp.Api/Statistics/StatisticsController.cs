using CourseSignUp.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CourseSignUp.Api.Statistics
{
  [ApiController, Route("[controller]")]
  public class StatisticsController : ControllerBase
  {
    private readonly IStudentRepository repos;

    public StatisticsController(IStudentRepository studentRepository)
    {
      repos = studentRepository;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
      var result = await repos.GetStatistic().ConfigureAwait(false);

      return Ok(result.Select(x => new CourseStatistics(x)));
    }
  }
}