using CourseSignUp.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CourseSignUp.Repository
{
  public interface ICourseRepository
  {
    Task<string> Add(string lectureId, string name, int capacity);

    Task<string> Add(Course course);

    Task<Course> Get(string id);

    Task<IList<Course>> GetAll();

    Task<bool> SingUp(string id);
  }
}
