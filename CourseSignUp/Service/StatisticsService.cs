using CourseSignUp.Model;
using CourseSignUp.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseSignUp.Service
{
  public class StatisticsService : IStatisticsService
  {
    private ICourseRepository _courseRepository;
    private IStatisticRepository _statisticRepository;
    private IStudentRepository _studentRepository;

    public StatisticsService(ICourseRepository courseRepository, IStatisticRepository statisticRepository, IStudentRepository studentRepository)
    {
      _courseRepository = courseRepository;
      _statisticRepository = statisticRepository;
      _studentRepository = studentRepository;
    }

    public async Task<bool> Add(string courseId, int age)
    {
      if(await _statisticRepository.Exists(courseId).ConfigureAwait(false))
      {
        return await _statisticRepository.Add(courseId, age).ConfigureAwait(false);
      }

      var course = await _courseRepository.Get(courseId).ConfigureAwait(false);
      return await _statisticRepository.Add(course, age).ConfigureAwait(false);
    }

    public async Task<IEnumerable<CourseStatistic>> GetCacheStatistic()
    {
      var students = await _statisticRepository.GetAll().ConfigureAwait(false);

      return students.Select(x => new CourseStatistic(x));
    }

    public async Task<IEnumerable<CourseStatistic>> GetStatistic()
    {
      var courses = await _courseRepository.GetAll().ConfigureAwait(false);
      var students = await _studentRepository.GetStatistic().ConfigureAwait(false);

      foreach (var student in students.AsParallel())
      {
        var course = courses.FirstOrDefault(x => x.Id == student.CourseId);

        if (course != null)
          student.CourseName = course.Name;
      }

      return students;
    }
  }
}
