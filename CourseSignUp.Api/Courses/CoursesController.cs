using CourseSignUp.Handler;
using CourseSignUp.Repository;
using CourseSignUp.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CourseSignUp.Api.Courses
{
  [ApiController, Route("[controller]")]
  public class CoursesController : ControllerBase
  {
    private readonly ISignUpService service;

    private readonly ICourseRepository repos;

    public CoursesController(ISignUpService signUpService, ICourseRepository courseRepository)
    {
      service = signUpService;

      repos = courseRepository;
    }

    [HttpGet, Route("{id}")]
    public async Task<IActionResult> Get(string id)
    {
      var result = await repos.Get(id).ConfigureAwait(false);
      if (result is null)
        return NotFound();

      return Ok(new CourseDto(result));
    }

    [HttpPost, Route("create")]
    public async Task<IActionResult> Post([FromBody] CreateCourseDto createCourseDto)
    {
      var result = await repos.Add(createCourseDto.LecturerId, createCourseDto.Name, createCourseDto.Capacity).ConfigureAwait(false);

      return Ok(result);
    }

    [HttpPost, Route("sign-up")]
    public async Task<IActionResult> Post([FromBody] SignUpToCourseDto signUpToCourseDto)
    {
      if (signUpToCourseDto?.Student is null)
        return NoContent();

      EventBus.Instance.PostEvent(service.OnEvent(signUpToCourseDto.GetEvent()));

      return Ok(Guid.NewGuid().ToString());
    }
  }
}
