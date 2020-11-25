using CourseSignUp.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseSignUp.Repository
{
  public class CourseRepository : ICourseRepository
  {
    readonly IList<Course> db;

    public CourseRepository()
    {
      db = new List<Course>();
    }

    public Task<string> Add(string lectureId, string name, int capacity) => Add(new Course(lectureId, name, capacity));

    public Task<string> Add(Course course)
    {
      if (course.Capacity < course.NumberOfStudents
        || string.IsNullOrWhiteSpace(course.Name))
        return Task.FromResult(string.Empty);

      db.Add(course);
      return Task.FromResult(course.Id);
    }

    public Task<Course> Get(string id) => Task.FromResult(db.FirstOrDefault(x => x.Id == id));

    public Task<IList<Course>> GetAll() => Task.FromResult(db);

    public Task<bool> SingUp(string id)
    {
      var course = db.FirstOrDefault(x => x.Id == id);

      if (course.NumberOfStudents >= course.Capacity)
        return Task.FromResult(false);

      course.NumberOfStudents++;
      return Task.FromResult(true);
    }
  }
}
