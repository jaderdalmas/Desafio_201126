using CourseSignUp.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CourseSignUp.Api.Lecturers
{
  [ApiController, Route("[controller]")]
  public class LecturersController : ControllerBase
  {
    readonly ILectureRepository repos;

    public LecturersController(ILectureRepository lectureRepository)
    {
      repos = lectureRepository;
    }

    [HttpPost, Route("create")]
    public async Task<IActionResult> Post([FromBody] CreateLecturerDto createStudentDto)
    {
      var result = await repos.Add(createStudentDto.Name).ConfigureAwait(false);

      return Ok(result);
    }
  }
}